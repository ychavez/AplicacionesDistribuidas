using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace DWShop.App.Context
{
    public class RestService
    {
        HttpClient _client;
        Uri _urlBase;


        public RestService()
        {
            _urlBase = new Uri("https://fakestoreapi.com/");
            _client = new HttpClient();
            _client.BaseAddress = _urlBase;
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


    }
}
