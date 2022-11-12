using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Data;
using OnlineShopApi.Entities;
using OnlineShopApi.Repositories.Contracts;

namespace OnlineShopApi.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly OnlineShopDbContext _shopOnlineDbContext;

    public ProductRepository(OnlineShopDbContext shopOnlineDbContext)
    {
        this._shopOnlineDbContext = shopOnlineDbContext;
    }
    public async Task<IEnumerable<ProductCategory>> GetCategories()
    {
        var categories = await this._shopOnlineDbContext.ProductCategories.ToListAsync();
           
        return categories; 
        
    }

    public async Task<ProductCategory> GetCategory(int id)
    {
        var category = await _shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
        return category;
    }

    public async Task<Product> GetItem(int id)
    {
        var product = await _shopOnlineDbContext.Products
            // .Include(p => p.ProductCategory)
            .SingleOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task<IEnumerable<Product>> GetItems()
    {
        var products = await this._shopOnlineDbContext.Products
            // .Include(p => p.ProductCategory)
            .ToListAsync();

        return products;
        
    }

    public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
    {
        var products = await this._shopOnlineDbContext.Products
            // .Include(p => p.ProductCategory)
            .Where(p => p.CategoryId == id).ToListAsync();
        return products;
    }
}
