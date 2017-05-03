source: https://leetcode.com/problems/trips-and-users/#/description

Interesting. This is to test Sql knowledge. The logic is simple but syntax is strange to me. 
Learned the `case when .. then .. else .. end below`

```mysql
# Write your MySQL query statement below
select t.Request_at Day,
round(sum(case when t.Status like 'cancelled_by_%' then 1 else 0 end) / count(*), 2) 'Cancellation Rate'
from Trips t
inner join Users u
on t.Client_ID = u.Users_Id and u.Banned = 'No'
where t.Request_at between '2013-10-01' and '2013-10-03'
group by t.Request_at;
```
