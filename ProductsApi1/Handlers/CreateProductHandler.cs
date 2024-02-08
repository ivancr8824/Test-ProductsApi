using MediatR;
using ProductsApi1.Commands;
using ProductsApi1.Models;
using ProductsApi1.Repositories;

namespace ProductsApi1.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Upc = command.Upc,
                Name = command.Name,
                Model = command.Model,
                UnitListPrice = command.UnitListPrice,
                UnitsInStock = command.UnitsInStock
            };

            return await _productRepository.AddProductAsync(product);
        }
    }
}
