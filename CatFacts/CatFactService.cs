namespace CatFacts;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class CatFactService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://catfact.ninja/fact";

    public CatFactService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetRandomCatFactAsync()
    {
        var response = await _httpClient.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var fact = JsonSerializer.Deserialize<CatFactResponse>(content);
            return fact.Fact;
        }
        else
        {
            throw new Exception("Failed to fetch cat fact from API.");
        }
    }
}

public class CatFactResponse
{
    public string Fact { get; set; }
}
