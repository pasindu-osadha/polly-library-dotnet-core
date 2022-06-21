using Polly;
using Polly.Retry;

namespace RequestProject.Policies
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediteHttpRetryPolicy { get;}
        public ClientPolicy()
        {
            ImmediteHttpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(res=>!res.IsSuccessStatusCode).RetryAsync(5);
        }
    }
}
