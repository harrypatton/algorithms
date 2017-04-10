## Source
* http://blog.gainlo.co/index.php/2016/03/08/system-design-interview-question-create-tinyurl-system/
* http://n00tc0d3r.blogspot.com/2013/09/big-data-tinyurl.html?view=magazine
* Flicker: http://code.flickr.net/2010/02/08/ticket-servers-distributed-unique-primary-keys-on-the-cheap/
* Twitter: http://blog.gainlo.co/index.php/2016/06/07/random-id-generator/
* Tweet id: https://dev.twitter.com/overview/api/twitter-ids-json-and-snowflake

## A few design points

1. Guid is not a good candidate due to big size and randomization. Indexing on guid is not efficient at all.
2. Hash a string (long url) to fixed string (md5 - 128bits). It works but the length is still 16 bytes and may have collision.
3. Common way is to increase an id (via database).

## Database incremental id

1. the incremenal id could be 32 or 64 bit integer. Flicker shows a simple command to always get new id from DB.
2. fault: what if the server is down? Flicker uses two machines. Each machine increase by 2; one starts with 1, and the other starts with 2. 
In this case, it can avoid one machine down. We can keep add more machines if necessary and the gap becomes `machine count`.

## Twitter way

1. a few machines generates random id. Each machine has a server id.
2. In that machine, it generates an id made of time stamp and sequence number.
