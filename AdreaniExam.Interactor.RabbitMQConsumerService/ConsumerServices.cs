using AdreaniExam.DataTransferObjects.Factories.Factories;
using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Interactors;
using AdreaniExam.Interactors.Persistances;
using AdreaniExam.Interactors.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdreaniExam.Interactor.RabbitMQConsumerService
{
    class AddressResultApi
    {
        public int AddressRequestId { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }

    public class ConsumerServices : IHostedService, IDisposable
    {
        private readonly UpdateAddressResultInteractor updateAddressResultInteractor;
        private readonly RabbitMQInteractor rabbitMQInteractor;
        private readonly RabbitMQConfiguration rabbitMQConfiguration;

        private readonly AddressResultDtoFactory addressResultDtoFactory;

        private readonly ServiceProvider serviceProvider;

        private readonly IServiceScope serviceScope;

        public ConsumerServices(IServiceCollection services, RabbitMQConfiguration rabbitMQConfiguration)
        {
            serviceProvider = services.BuildServiceProvider();
            serviceScope = serviceProvider.CreateScope();

            this.rabbitMQConfiguration = rabbitMQConfiguration;

            updateAddressResultInteractor = serviceProvider.GetService<UpdateAddressResultInteractor>();
            rabbitMQInteractor = serviceProvider.GetService<RabbitMQInteractor>();
            addressResultDtoFactory = serviceProvider.GetService<AddressResultDtoFactory>();
        }

        public void Dispose()
        {
            //serviceScope.Dispose();
            //serviceProvider.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = rabbitMQInteractor.GetConnectionFactory(rabbitMQConfiguration);

            string queueName = "AddressResults";
            var rabbitMqConnection = factory.CreateConnection();
            var rabbitMqChannel = rabbitMqConnection.CreateModel();

            rabbitMqChannel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(rabbitMqChannel);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var jsonResponse = JsonConvert.DeserializeObject<AddressResultApi>(message);

                    var dto = addressResultDtoFactory.BuildToAddressRequestResultDto(jsonResponse.AddressRequestId, Convert.ToDouble(jsonResponse.Longitud), Convert.ToDouble(jsonResponse.Latitud));

                    await updateAddressResultInteractor.Update(dto);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

                rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            rabbitMqChannel.BasicConsume(queue: queueName,
                                 autoAck: false,
                                 consumer: consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
