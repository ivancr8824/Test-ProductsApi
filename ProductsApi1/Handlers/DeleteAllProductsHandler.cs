using MediatR;
using ProductsApi1.Commands;
using ProductsApi1.Repositories;

namespace ProductsApi1.Handlers
{
    public class DeleteAllProductsHandler: IRequestHandler<DeleteAllProductsCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteAllProductsCommand query, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteAllProductAsync();
        }
    }
}
