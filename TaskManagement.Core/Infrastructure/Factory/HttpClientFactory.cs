using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace TaskManagement.Core.Infrastructure.Factory
{
    public interface ITaskManagementHttpClientFactory
    {
        HttpClient CreateClient();
    }
    public class TaskManagementHttpClientFactory : ITaskManagementHttpClientFactory
    {
        private readonly IConfiguration _configuration;
        public TaskManagementHttpClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HttpClient CreateClient()
        {
            var timeout = Convert.ToInt32(_configuration["PMISTimeout"]);
            var client = new HttpClient();
            SetupClientDefaults(client, timeout);
            return client;
        }

        protected virtual void SetupClientDefaults(HttpClient client, int timeout)
        {
            client.Timeout = TimeSpan.FromSeconds(timeout);
            client.MaxResponseContentBufferSize = int.MaxValue;
        }
    }
}
