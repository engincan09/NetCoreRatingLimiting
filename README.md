<b> What is rate limiting? </b>
<p>Users may accidentally or intentionally consume these resources in a way that affects others, and this will prevent our application from working properly on the server because there is constant CPU and ram usage. We use rating limitation to avoid these undesirable situations.</p>

<p>For example: A maximum of 900 requests can be made to Twitter's APIs within 15 minutes.</p>

<b>Benefits</b>
<p>By limiting the number of requests to the server, it prevents heavy use of the resource and thus provides protection against DoS (Denial of Service) attacks (a form of cyber attack by sending multiple requests to render the service unusable).
It reduces the cost as the number of requests to the server is limited. </p>


<b>Types of rate limiters </b> <br>
In our example, we’ve used the FixedWindowLimiter to limit the number of requests in a time window.

There are more rate limiting algorithms available in .NET that you can use:<br><br>
<b>Concurrency limit:</b> is the simplest form of rate limiting. It doesn’t look at time, just at number of concurrent requests. “Allow 10 concurrent requests”.<br><br>
<b>Fixed window limit:</b> lets you apply limits such as “60 requests per minute”. Every minute, 60 requests can be made. One every second, but also 60 in one go.<br><br>
<b>Sliding window limit:</b> is similar to the fixed window limit, but uses segments for more fine-grained limits. Think “60 requests per minute, with 1 request per second”.<br><br>
<b>Token bucket limit:</b> lets you control flow rate, and allows for bursts. Think “you are given 100 requests every minute”. If you make all of them over 10 seconds, you’ll have to wait for 1 minute before you are allowed more requests.
