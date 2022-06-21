using Polly;
using Polly.Retry;

namespace RequestProject.Policies
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediteHttpRetryPolicy { get; }
        public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetryPolicy { get; }
        public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetryPolicy { get; }
        public ClientPolicy()
        {
            ImmediteHttpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).RetryAsync(5);
            LinearHttpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(2));
            ExponentialHttpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
