# How to Design Twitter?

## Step 1 - List a few scenarios to start with. Always start with simple ones and MVP (minimum viable product)

1. I can follow other people.
2. I can post a tweet.
3. I can see tweets from my followers.

## Step 2 - start the design of object model. I can see main objects here,

1. Users
2. Tweets

## Step 3 - What're relationships in object models?

1. User can post a tweet and see tweets from followers.
2. User can follow/unfollow other users

## Step 4 - Go back to DB and here's the table we can design,

1. Users - user id, name, profile information.
2. User follow-relationship -> followee, follower.
3. Tweet - tweet id, user id, content

## Step 5 - Go back to scenario and check how the db work,

1. I can follow other people. Yes, update the user follow-relationship table.
2. I can post a tweet.  Yes, update tweet table.
3. I can see tweets from my followers. Yes, we have to join two tables follow-relationship and tweet table.

## Step 6 - Identify the bottleneck

1. Apparently the #3 scenario might be an issue because it needs a join-operation. Both tables could be very big. It has billions of users and much more tweets. 

## Step 7 - Solve the bottleneck

1. we need partitions by users in both tables.
	* can we put users and followers in the same partitions? probably not because people graph could be very big across different regions.
2. In average, a user has a few followers. Tweets from these followers may come from different partitions. Joining could be still expensive. To improve it, we can do,
	* when follower sends a tweet, we keep a copy for every followee. It means we can read the user record only to get all feeds (assume we use document DB). The performance for reading feeds could be very good.
	* when follower update/delete the tweet, all of copies need the same change.
	* when follow or un-follow a user, we need to handle these copies too.
3. The above strategy doesn't work for celebrity who has millions users so many follow-relationship rows are about it. A single tweet involves too many copies. In that case, joining is probably fine because tweets table for celebrity is much smaller than regular one. 
4. The workflow for user to read feeds is, check user table itself to get tweets from normal followers and then use a join to get feeds from celebrity.

## Summary
I believe there are a lot of problems I missed in above analysis. Hope this article is a good start. 

## References
1. [The Architecture Twitter Uses To Deal With 150M Active Users, 300K QPS, A 22 MB/S Firehose, And Send Tweets In Under 5 Seconds](http://highscalability.com/blog/2013/7/8/the-architecture-twitter-uses-to-deal-with-150m-active-users.html)
2. [Twitter By The Numbers - 460,000 New Accounts And 140 Million Tweets Per Day](http://highscalability.com/blog/2011/3/14/twitter-by-the-numbers-460000-new-accounts-and-140-million-t.html)
3. [How Twitter Stores 250 Million Tweets A Day Using MySQL](http://highscalability.com/blog/2011/12/19/how-twitter-stores-250-million-tweets-a-day-using-mysql.html)
4. [How Twitter Handles 3,000 Images Per Second](http://highscalability.com/blog/2016/4/20/how-twitter-handles-3000-images-per-second.html)
5. [How Twitter Uses Redis To Scale - 105TB RAM, 39MM QPS, 10,000+ Instances](http://highscalability.com/blog/2014/9/8/how-twitter-uses-redis-to-scale-105tb-ram-39mm-qps-10000-ins.html)
