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
4. Privacy information utility - hash sensitive information for external users.
5. Dynamic Telemetry - disable events on the fly.
6. Support different channels (i.e., receivers)

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
1. All events go to a queue. Every minute we store all events in the queue to a local file in temp folder. Question: do we keep generating new files if the machine is offline forever? 
