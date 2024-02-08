using MediatR;
using ProductsApi1.Commands;
using ProductsApi1.Repositories;

namespace ProductsApi1.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _productRepository.GetProductByIdAsync(command.Id);
            if (studentDetails == null)
                return false;

            return await _productRepository.DeleteProductAsync(command.Id);
        }
    }
}
