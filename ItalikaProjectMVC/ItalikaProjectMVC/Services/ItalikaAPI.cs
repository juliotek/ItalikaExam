using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ItalikaProjectMVC.Services
{
    public class ItalikaAPI
    {
        private static readonly string _apiURL = @"http://localhost:44371/";
        public HttpClient _client;

        public ItalikaAPI()
        {
            _client = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {

            HttpClient client = new HttpClient(GetHttpClientHandler())
            {
                BaseAddress = new Uri(_apiURL)
            };

            return client;
        }

        private static HttpClientHandler GetHttpClientHandler()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            return handler;
        }

        public async Task<List<Models.Product>> GetProducts()
        {

            HttpResponseMessage response;
            string query = "api/TbProducts";

            response = await _client.GetAsync(query);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Models.Product> responseJson;
                string streamResponse = await response.Content.ReadAsStringAsync();
                responseJson = JsonConvert.DeserializeObject<List<Models.Product>>(streamResponse);
                return responseJson;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductCreatedResponse> CreateProduct(Models.Product product)
        {
            try
            {
                HttpResponseMessage response;

                string query = "api/TbProducts";

                string jsonString = JsonConvert.SerializeObject(product);
                HttpContent data = new StringContent(jsonString, Encoding.UTF8, "application/json");

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 

                response = await _client.PostAsync(query, data);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    ProductCreatedResponse responseJson;
                    string streamResponse = await response.Content.ReadAsStringAsync();
                    responseJson = JsonConvert.DeserializeObject<ProductCreatedResponse>(streamResponse);
                    return responseJson;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public class ProductCreatedResponse
        {
            public int id { get; set; }
        }

    }
}
