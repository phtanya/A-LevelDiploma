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
    [Scope("catalog.petsfood.type")]
    public class PetsFoodTypeController : ControllerBase
    {
        private readonly IPetsFoodTypeService _petsFoodTypeService;
        private readonly ILogger<PetsFoodTypeController> _logger;

        public PetsFoodTypeController(
            IPetsFoodTypeService petsFoodTypeService,
            ILogger<PetsFoodTypeController> logger)
        {
            _petsFoodTypeService = petsFoodTypeService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Add(CreatePetsFoodTypeRequest request)
        {
            var result = await _petsFoodTypeService.AddAsync(request.Type);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdatePetsFoodTypeRequest request)
        {
            var result = await _petsFoodTypeService.UpdateAsync(request.Id!.Value, request.Type);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _petsFoodTypeService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
