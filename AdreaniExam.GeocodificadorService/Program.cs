using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.IO;
using Microsoft.Extensions.Configuration;
using AdreaniExam.Interactors.Utils;
using AdreaniExam.GeocodificadorService.Dtos;
using AdreaniExam.GeocodificadorService.Api;

namespace AdreaniExam.GeocodificadorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var rabbitConfiguration = new RabbitMQConfiguration();

            configuration.GetSection("RabbitMQConfiguration").Bind(rabbitConfiguration);

            var baseUrlOpenStreetMap = configuration.GetValue<string>("OpenStreetMap:url");

            var api = new OpenStreetMapApi(baseUrlOpenStreetMap, rabbitConfiguration);

            var factory = new ConnectionFactory()
            {
                HostName = rabbitConfiguration.HostName,
                UserName = rabbitConfiguration.Username,
                Password = rabbitConfiguration.Password,
                Uri = new Uri(rabbitConfiguration.Uri),
                VirtualHost = rabbitConfiguration.VirtualHost

            };

            string queueName = "AddressRequests";
            var rabbitMqConnection = factory.CreateConnection();
            var rabbitMqChannel = rabbitMqConnection.CreateModel();

            rabbitMqChannel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            int messageCount = Convert.ToInt16(rabbitMqChannel.MessageCount(queueName));
            Console.WriteLine(" Escuchando las colas. Hay {0} mensajes en la cola", messageCount);

            var consumer = new EventingBasicConsumer(rabbitMqChannel);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var entity = JsonConvert.DeserializeObject<AddressRequestMessageDto>(message);

                    await api.GetLatitudeAndLongitudeByAddress(entity);

                    Console.WriteLine(" Se recibio: " + message);
                    rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            };
            rabbitMqChannel.BasicConsume(queue: queueName,
                                 autoAck: false,
                                 consumer: consumer);

            Thread.Sleep(1000 * messageCount);
            Console.WriteLine(" Se cerro la conexion, no hay mas mensajes.");
            Console.ReadLine();
        }
    }
}
