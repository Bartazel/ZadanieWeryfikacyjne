namespace ZadanieWeryfikacyjne.Exceptions
{
    public abstract class HttpResponseException : Exception
    {
        public HttpResponseException(string whatFailed, int statusCode, string? whyFailed = null, Dictionary<string, object>? data = null)
            : base(whatFailed)
        {
            StatusCode = statusCode;
            Data = data ?? new Dictionary<string, object>();
            Details = whyFailed;
        }

        public override Dictionary<string, object> Data { get; }
        public string? Details { get; }
        public int StatusCode { get; }
    }
}
