using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DWShop.App.Context
{
    public class RestService
    {
        HttpClient _client;
        Uri _urlBase;


        public RestService()
        {
            _urlBase = new Uri("http://gdlsoft.ddns.net:99/");
            _client = new HttpClient();
            _client.BaseAddress = _urlBase;
        }

        public async Task<T> GetSingleAsync<T>(string url) 
        {
           T TData = default;

            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    TData = await response.Content.ReadFromJsonAsync<T>();
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Error {ex.Message}");
            }

            return TData;

        }

        public async Task<List<T>> GetDataAsync<T>(string url)
        {
            List<T> TData = null;

            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    TData = await response.Content.ReadFromJsonAsync<List<T>>();
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Error {ex.Message}");
            }

            return TData;
        }


        public async Task PostDataAsync<T>(T data, string url)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }


    }
}
