using MediatR;
using ProductsApi1.Models;

namespace ProductsApi1.Queries
{
    public class GetProductsListQuery : IRequest<IEnumerable<Product>>
    {
    }
}
