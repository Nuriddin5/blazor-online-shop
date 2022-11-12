using OnlineShop.Models.Dtos;

namespace OnlineShop.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetItems();
    
}