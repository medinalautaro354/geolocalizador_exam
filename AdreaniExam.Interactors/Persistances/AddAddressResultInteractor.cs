using AdreaniExam.Models.Entities;
using AdreaniExam.Repositories.Entities;
using AdreaniExam.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Interactors.Persistances
{
    public partial class AddAddressResultInteractor
    {
        public class AddressResultAdd : IAddressResultAdd
        {
            public int AddressRequestId { get; set; }

            public AddressResultAdd(int addressRequestId)
            {
                AddressRequestId = addressRequestId;
            }
        }

    }
    public partial class AddAddressResultInteractor
    {
        private readonly IAddressResultRepository repository;

        public AddAddressResultInteractor(IAddressResultRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IAddressResult> Add(int addressRequestId)
        {
            var entity = await repository.Add(new AddressResultAdd(addressRequestId));

            return entity;
        }
    }
}
