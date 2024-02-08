using MediatR;
using ProductsApi1.Models;
using ProductsApi1.Queries;
using ProductsApi1.Repositories;

namespace ProductsApi1.Handlers
{
    public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsListQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsListAsync();
        }
    }
}
