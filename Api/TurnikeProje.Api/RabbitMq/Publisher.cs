using RabbitMQ.Client;
using System.Text;

namespace TurnikeProje.Api.RabbitMq
{
    public class Publisher
    {
        public void Publish(string sorgu) 
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://turtjjhs:mM-cxDqotlsIQtOqZDLewbqFKHwYF0-X@cougar.rmq.cloudamqp.com/turtjjhs");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("turnikesorgu",true,false,false);
            string message = $"{sorgu}";
            var messagebody = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(string.Empty,"turnikesorgu",null,messagebody);
        }
    }
}
