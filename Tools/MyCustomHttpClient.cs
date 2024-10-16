using System.Collections.Concurrent;
using System.Diagnostics;
using Models;

namespace Tools
{
    public class MyCustomHttpClient
    {
        private readonly HttpClient _httpClient;
        private Random random = new Random();
        private ConcurrentQueue<RequestMetrics> requestMetricsQueue = new ConcurrentQueue<RequestMetrics>();

        public MyCustomHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var thisRGuid = Guid.NewGuid().ToString();
            if (requestMetricsQueue.TryDequeue(out var requestMetrics))
            {
                requestMetrics.RequestId = thisRGuid;
                Console.WriteLine($"[{DateTime.Now}] Starting GetAsync request for {url} with request {thisRGuid}. Request metrics: {requestMetrics.PrevRequestId} - {requestMetrics.PrevRequestDurationMs}ms");
            }
            else
            {
                Console.WriteLine($"[{DateTime.Now}] Starting GetAsync request for {url} with request {thisRGuid}. No Metrics");
            }
            await Task.Delay(random.Next(1, 50));
            Console.WriteLine($"Queue size {requestMetricsQueue.Count}");
            sw.Stop();
            //Console.WriteLine($"[{DateTime.Now}] Done GetAsync request for {url}");
            if (requestMetricsQueue.Count < 10)
            {
                requestMetricsQueue.Enqueue(new RequestMetrics()
                {
                    PrevRequestDurationMs = sw.ElapsedMilliseconds,
                    PrevRequestId = thisRGuid
                });
            }
            return "Cool";
        }
    }
}