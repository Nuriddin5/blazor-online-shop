using System.Collections;
using System.Net.Http.Json;
using OnlineShop.Models.Dtos;

namespace OnlineShop.Services.Contracts;

public class ProductServices : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductDto>> GetItems()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}