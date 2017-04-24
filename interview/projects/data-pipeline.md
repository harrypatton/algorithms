The following document discusses a data pipeline I'm going to design for client applications with 1 million users.

A data pipeline is a system from `collecting data on client machines` to `sending back to backend` 
and `transforming them in a good shape for further analysis`.

Here's a great architecture from [Azure Event Hubs document](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-what-is-event-hubs).

![Data Pipe](https://docs.microsoft.com/en-us/azure/event-hubs/media/event-hubs-what-is-event-hubs/event_hubs_full_pipeline.png)

There're 4 parts in my project,

1. Event Producer on client side (Telemetry Client Library)
2. Event Receiver
3. Data Platform (Storage and Processor)
4. Data Apps (Presentation)

# Event Producer
Telemetry client library is required to simply sending event work for each product.

1. **Web api wrapper**. A wrapper to handle web api calling including retry and batching.
2. Every event has the same **common schema**, e.g., user id, machine id, OS information.
3. **Offline scenario**.
4. **Privacy information utility** - hash sensitive information for external users.
5. **Dynamic Telemetry** - disable events on the fly.
6. Support **multiple channels** (i.e., receivers)

## Web API Wrapper
* When API call failed, use exponential rety (or [exponential backoff](https://en.wikipedia.org/wiki/Exponential_backoff))
* It doesn't make a call for each event (otherwise it may take down the server).
  * The API takes at most 256kb content. 
  * Because we use g-zip, so it is around 2mb content. It is roughly 1k events.
  * Around one million users are online at the same time. In average, every minute makes a call, so QPS is 17k requests per second.
    There're 60 machines for now. Each machine handles around 300 calls per second. (we can use 64 units in Event Hub case.)
    
## Common Schema
1. first version - we have a few core properties regarding the user, machine, OS and product.
2. second version - introduce 3 parts schema. core + Data Model + custom.

## Offline Scenario
1. All events go to a queue. Every minute we store all events in the queue to a local file in temp folder. Question: do we keep generating new files if the machine is offline forever? We need to introduce a cap. If the folder has more than `60*24` files, we just delete them.
2. A background thread will check file and call the web api to upload. We use mutex here for multiple instances to upload these files. Only one active uploader at a time. That's why we use mutex. It is the best locking solution in this scenario. (if we use read lock, we have to release it before delete it. In that case, there's a race condition that another instance may read it. so duplicate events).
3. If app crashes before flush to disk, we lose the events; but it is a fine trade-off.

## Privacy Information
1. Ok to send sensitive information for internal/test users; Have to hash it for external users.
2. It also detects if the user is external or not. A few complicated logics (check company domain or whitelist).
3. Need to handle opted-out users. Don't send any events.

## Dynamic Telemetry
1. Disable events based on a blacklist on server. It means every time we have to download it. Why? Patching client apps is not easy; but disabling sensitive event becomes an urgent requirement (to avoid lawsuit)
2. Disable unused or crappy events.
3. How big is the blacklist? less than 1 hundred so far.
4. The client needs to download the blacklist every time. Both API and the file content have version information.

## Multiple Channels
1. Decouple event producer and receiver.
2. Use multiple channels to verify data completeness.
3. Enable test channel for unit testing.

# Others
The following topics are something we need to think about in the future,

1. Telemetry Quality - how to make sure every one send data in good quality? Is there a good/quick way for them to validate?
2. Volume Control - unused or less freqent used events? We should introduce some tiers concept. More data causes scalability challenge and waste money.
