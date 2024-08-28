using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using HTTPClient.Models;

namespace HTTPClient.Services;

public class PostService
{
    private HttpClient httpClient;
    private Post? post;
    private ObservableCollection<Post>? posts;
    private JsonSerializerOptions jsonSerializerOptions;

    public PostService()
    {
        this.httpClient = new();
        jsonSerializerOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<ObservableCollection<Post>> FetchPosts()
    {
        Uri uri = new("https://jsonplaceholder.typicode.com/posts");

        try
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);

            if (responseMessage.IsSuccessStatusCode)
            {
                string json = await responseMessage.Content.ReadAsStringAsync();
                posts =  JsonSerializer.Deserialize<ObservableCollection<Post>>(json, jsonSerializerOptions);
            }
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return posts;
    }
}
