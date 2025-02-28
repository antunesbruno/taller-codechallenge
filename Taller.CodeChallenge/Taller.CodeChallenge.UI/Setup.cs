using Polly;
using Polly.Extensions.Http;
using RestEase.HttpClientFactory;
using System.Net;

using Taller.CodeChallenge.UI.Services;

namespace Taller.CodeChallenge.UI
{
    public static class Setup
    {
        public static void AddRestEaseServices(this IServiceCollection services)
        {
            services.AddRestEaseClient<IRestEaseTallerUsApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://localhost:44322");
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                }).AddPolicies();
        }

        private static void AddPolicies(this IHttpClientBuilder httpClientBuilder)
        {
            httpClientBuilder.AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(httpResponseMessage => httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
                .WaitAndRetryAsync(3, contador => TimeSpan.FromSeconds(5)));
        }
    }
}