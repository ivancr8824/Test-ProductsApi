using MediatR;
using ProductsApi1.Models;
using ProductsApi1.Queries;
using ProductsApi1.Repositories;

namespace ProductsApi1.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdAsync(query.Id);
        }
    }
}
