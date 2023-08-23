using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.Api.RabbitMq
{
    public class Consumer
    {
        public void Consume()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://turtjjhs:mM-cxDqotlsIQtOqZDLewbqFKHwYF0-X@cougar.rmq.cloudamqp.com/turtjjhs");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("turnikesorgu", true, consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                channel.BasicAck(e.DeliveryTag, false);
            };
            

        }
    }
}
