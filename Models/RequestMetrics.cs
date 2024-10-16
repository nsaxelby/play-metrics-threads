namespace Models
{
    public class RequestMetrics
    {
        public string RequestId { get; set; }
        public string PrevRequestId { get; set; }
        public long PrevRequestDurationMs { get; set; }
    }
}