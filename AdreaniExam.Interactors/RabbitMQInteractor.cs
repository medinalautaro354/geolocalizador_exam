using AdreaniExam.Interactors.Utils;
using AdreaniExam.Models.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace AdreaniExam.Interactors
{
    public class RabbitMQInteractor
    {
        private readonly ConnectionFactory connectionFactory;

        public RabbitMQInteractor(RabbitMQConfiguration rabbitMQConfiguration)
        {
            connectionFactory = GetConnectionFactory(rabbitMQConfiguration);
        }

        public ConnectionFactory GetConnectionFactory(RabbitMQConfiguration rabbitMQConfiguration)
        {
            return new ConnectionFactory
            {
                UserName = rabbitMQConfiguration.Username,
                Password = rabbitMQConfiguration.Password,
                VirtualHost = rabbitMQConfiguration.VirtualHost,
                HostName = rabbitMQConfiguration.HostName,
                Uri = new Uri(rabbitMQConfiguration.Uri)
            };
        }

        public void PublishMessage(object message, string queueName)
        {
            CreateConnectionAndSendMessage(queueName, message);
        }

        private void CreateConnectionAndSendMessage(string queueName, object message)
        {
            using (var conn = connectionFactory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var jsonPayload = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonPayload);

                    channel.BasicPublish(exchange: "",
                        routingKey: queueName,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }
    }
}
