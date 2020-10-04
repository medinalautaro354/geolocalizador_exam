using AdreaniExam.DataTransferObjects.Factories.Factories;
using AdreaniExam.GeocodificadorService.Dtos;
using AdreaniExam.GeocodificadorService.Model;
using AdreaniExam.Interactors;
using AdreaniExam.Interactors.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdreaniExam.GeocodificadorService.Api
{
    class OpenStreetMapApi
    {
        private readonly string baseUrl;

        private readonly HttpClient client;

        private readonly RabbitMQInteractor rabbitMQInteractor;
        private readonly AddressResultDtoFactory addressResultDtoFactory;

        public OpenStreetMapApi(string baseUrl, RabbitMQConfiguration rabbitMQConfiguration)
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Services demo");

            rabbitMQInteractor = new RabbitMQInteractor(rabbitMQConfiguration);
            addressResultDtoFactory = new AddressResultDtoFactory();
        }

        public async Task GetLatitudeAndLongitudeByAddress(AddressRequestMessageDto addressRequestMessage)
        {
            var response = await client.GetAsync($"{baseUrl}/search?street={addressRequestMessage.Street} {addressRequestMessage.Number}&city={addressRequestMessage.Province}&state={addressRequestMessage.City}&country={addressRequestMessage.Country}&postalcode={addressRequestMessage.ZipCode}&format=json&addressdetails=1&limit=1&polygon_svg=1");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<List<Result>>(contentStream);

                var dto = addressResultDtoFactory.BuildToAddressRequestResultDto(addressRequestMessage.Id, Convert.ToDouble(responseObject[0].Lon), Convert.ToDouble(responseObject[0].Lat));

                rabbitMQInteractor.PublishMessage(dto, "AddressResults");
            }
            else
            {
                Console.WriteLine();
            }

        }
    }
}
