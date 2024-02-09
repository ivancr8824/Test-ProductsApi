using ProductsApi1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProductsApi1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository(IOptions<MongoDBSettings> mongoDBSetting)
        {
            MongoClient client = new MongoClient(mongoDBSetting.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSetting.Value.DatabaseName);
            _productCollection = database.GetCollection<Product>(mongoDBSetting.Value.CollectionName);
        }


        public async Task<IEnumerable<Product>> GetProductsListAsync()
        {
            return await _productCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _productCollection.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProductAsync(string id, Product product)
        {
            await _productCollection.ReplaceOneAsync(x => x.Id == id, product);
            return true;
        }

        public async Task<bool> DeleteAllProductAsync()
        {
            await _productCollection.DeleteManyAsync(_ => true);
            return true;
        }
    }
}
