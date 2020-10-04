using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Interactors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Controllers
{
    [Route("[Controller]")]
    public class GeocodificarController : ControllerBase
    {
        private readonly AddressResultInteractor interactor;

        public GeocodificarController(AddressResultInteractor interactor)
        {
            this.interactor = interactor ?? throw new ArgumentNullException(nameof(interactor));
        }

        [HttpGet()]
        public async Task<ActionResult<IAddressResultDto>> GetById([FromQuery(Name = "id")] int addressRequestId)
        {
            var result = await interactor.GetByAddressRequestId(addressRequestId);
            return Ok(result);
        }
    }
}
