using MediatR;
using ProductsApi1.Models;

namespace ProductsApi1.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public string Id { get; set; } = null!;
    }
}
