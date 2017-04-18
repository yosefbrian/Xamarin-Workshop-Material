using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoREST.Data;
using TodoREST.Models;

namespace TodoREST.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<TodoItem> Items { get; private set; }
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            Items = new List<TodoItem>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Kesalahan {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        {
            var uriPost = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var uriPut = new Uri(string.Format(Constants.RestUrl, item.ID));
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uriPost, content);
                }
                else
                {
                    response = await client.PutAsync(uriPut, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"TodoItem berhasil disimpan.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Kesalahan {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"TodoItem berhasil didelete.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Kesalahan {0}", ex.Message);
            }
        }
    }
}