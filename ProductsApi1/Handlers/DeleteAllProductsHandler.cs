using MediatR;
using ProductsApi1.Commands;
using ProductsApi1.RabbitMQ;

namespace ProductsApi1.Handlers
{
    public class DeleteAllProductsHandler: IRequestHandler<DeleteAllProductsCommand, string>
    {
        private readonly IRabbitMQProducer _rabitMQProducer;

        public DeleteAllProductsHandler(IRabbitMQProducer rabitMQProducer)
        {
            _rabitMQProducer = rabitMQProducer;
        }

        public async Task<string> Handle(DeleteAllProductsCommand query, CancellationToken cancellationToken)
        {
            _rabitMQProducer.SendProductMessage("DeleteProducts");
            return await Task.Run(() => "Los productos serán borrados dentro de 2 min");
        }
    }
}
