using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("catalog.petsfood.brand")]
    public class PetsFoodBrandController : ControllerBase
    {
        private readonly IPetsFoodBrandService _petsFoodBrandService;
        private readonly ILogger<PetsFoodBrandController> _logger;

        public PetsFoodBrandController(IPetsFoodBrandService petsFoodBrandService, ILogger<PetsFoodBrandController> logger)
        {
            _petsFoodBrandService = petsFoodBrandService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Add(CreatePetsFoodBrandRequest request)
        {
            var result = await _petsFoodBrandService.AddAsync(request.Brand);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdatePetsFoodBrandRequest request)
        {
            var result = await _petsFoodBrandService.UpdateAsync(request.Id!.Value, request.Brand);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _petsFoodBrandService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
