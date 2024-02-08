using MediatR;
using ProductsApi1.Commands;
using ProductsApi1.Repositories;

namespace ProductsApi1.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(command.Id);
            if (product == null)
                return false;

            product.Upc = command.Upc;
            product.Name = command.Name;
            product.Model = command.Model;
            product.UnitListPrice = command.UnitListPrice;
            product.UnitsInStock = command.UnitsInStock;

            return await _productRepository.UpdateProductAsync(command.Id, product);
        }
    }
}
