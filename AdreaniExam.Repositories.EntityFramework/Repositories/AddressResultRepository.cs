using AdreaniExam.Models.Entities;
using AdreaniExam.Repositories.Entities;
using AdreaniExam.Repositories.EntityFramework.Model;
using AdreaniExam.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Repositories.EntityFramework.Repositories
{
    public class AddressResultRepository : IAddressResultRepository
    {
        private readonly AdreaniExamContext context;

        public AddressResultRepository(AdreaniExamContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IAddressResult> Add(IAddressResultAdd add)
        {
            var entry = await context.AddressResults.AddAsync(MapToEntity(add));
            await context.SaveChangesAsync();

            return entry.Entity;
        }

        private AddressResult MapToEntity(IAddressResultAdd add) =>
            new AddressResult
            {
                AddressRequestId = add.AddressRequestId,
                IsActive = true,
                State = State.Procesando
            };

        public async Task<IAddressResult> GetByAddressRequestId(int addressRequestId)
        {
            var entity = await context.AddressResults.FirstOrDefaultAsync(f => f.AddressRequestId == addressRequestId);

            return entity;
        }

        public async Task<IAddressResult> Update(IAddressResultUpdate update)
        {
            if (update is null) throw new ArgumentNullException(nameof(update));

            var entity = await context.AddressResults.FirstOrDefaultAsync(f => f.Id == update.Id);

            if (entity != null)
            {
                PatchProperties(entity, update);

                context.AddressResults.Update(entity);

                await context.SaveChangesAsync();
            }

            return entity;
        }

        private void PatchProperties(AddressResult entity, IAddressResultUpdate update)
        {
            entity.Latitude = update.Latitude;
            entity.Longitude = update.Longitude;
            entity.State = State.Terminado;
        }
    }
}
