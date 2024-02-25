using System;
using Refit;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Weather.Common.Constant;
using Newtonsoft.Json.Serialization;

namespace Weather.Services
{
    [ExcludeFromCodeCoverage]
    public class HttpClientProvider
    {
        public static HttpClientProvider Instance { get; } = new HttpClientProvider();

        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private HttpClientProvider()
        {
            _httpClient = new HttpClient(new HttpLoggingHandler());
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            };
        }

        public T GetApi<T>(string baseUrl = Server.ApiUrl ,string token = "")
        {
            _httpClient.BaseAddress = new Uri(baseUrl);

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return RestService.For<T>(_httpClient, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(_jsonSerializerSettings)
            });
        }
    }
}

