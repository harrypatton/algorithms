source: https://my.oschina.net/eonezhang/blog/125199

For latitude, it is [-90, 90]. 

* Divide the range into two sub-ranges, if fall in first one, the value is 0; otherwise 1.
* Divide the subrange into 2, and first range is 0 and the second range is 1.
* keep dividing until the pricise requirement is met.
* we'll get an array of bits.

For longtitue, it is [0, 180]. use the same logic to get an array of bits.

Combine both bit array to a bigger array and then use base32 or base64 to get the encoding value.
