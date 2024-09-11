using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    internal class TodoService
    {
        private HttpClient httpClient;
        private Todo? todo;
        private ObservableCollection<Todo>? todos;
        private JsonSerializerOptions jsonSerializerOptions;

        public TodoService()
        {
            this.httpClient = new();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Todo>?> FetchTodosAsync()
        {
            Uri uri = new("https://jsonplaceholder.typicode.com/todos");

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string json = await responseMessage.Content.ReadAsStringAsync();
                    todos = JsonSerializer.Deserialize<ObservableCollection<Todo>>(json, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return todos;
        }
    }
}
