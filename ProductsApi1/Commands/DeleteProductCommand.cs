using MediatR;

namespace ProductsApi1.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public string Id { get; set; } = null!;
    }
}
