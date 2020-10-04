using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Dtos;
using AdreaniExam.Interactors.Persistances;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Controllers
{
    [Route("[Controller]")]
    public class GeolocalizarController : ControllerBase
    {
        private readonly AddAddressRequestInteractor addInteractor;

        public GeolocalizarController(AddAddressRequestInteractor addInteractor)
        {
            this.addInteractor = addInteractor ?? throw new ArgumentNullException(nameof(addInteractor));
        }

        [HttpPost]
        public async Task<ActionResult<IBaseAddressRequestDto>> Post([FromBody] AddAddressRequestDto dto)
        {
            var result = await addInteractor.Add(dto);

            return Accepted(result);
        }
    }
}
