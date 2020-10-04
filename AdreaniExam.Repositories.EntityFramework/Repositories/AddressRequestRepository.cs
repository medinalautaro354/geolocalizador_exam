using AdreaniExam.Models.Entities;
using AdreaniExam.Repositories.Entities;
using AdreaniExam.Repositories.EntityFramework.Model;
using AdreaniExam.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Repositories.EntityFramework.Repositories
{
    public class AddressRequestRepository : IAddressRequestRepository
    {
        private readonly AdreaniExamContext context;

        public AddressRequestRepository(AdreaniExamContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IAddressRequest> Add(IAddressRequestAdd add)
        {
            var entry = await context.AddressRequests.AddAsync(MapToEntity(add));
            await context.SaveChangesAsync();

            return entry.Entity;
        }

        private AddressRequest MapToEntity(IAddressRequestAdd add) =>
            new AddressRequest
            {
                City = add.City,
                Country = add.Country,
                IsActive = true,
                Number = add.Number,
                Province = add.Province,
                Street = add.Street,
                ZipCode = add.ZipCode
            };
    }
}
