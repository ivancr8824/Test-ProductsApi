// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("product", exclusive: false);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, eventArgs) => {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Productos Eliminados");
                };

                channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
                Console.ReadKey();
            }
        }
    }
}