using ProductsApi1.Models;

namespace ProductsApi1.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductsListAsync();
        public Task<Product> GetProductByIdAsync(string id);
        public Task<Product> AddProductAsync(Product product);
        public Task<bool> UpdateProductAsync(string id, Product product);
        public Task<bool> DeleteProductAsync(string id);
    }
}
