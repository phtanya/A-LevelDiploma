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
    [Scope("catalog.petsfood")]
    public class PetsFoodController : ControllerBase
    {
        private readonly ILogger<PetsFoodController> _logger;
        private readonly IPetsFoodService _petsFoodService;

        public PetsFoodController(
            ILogger<PetsFoodController> logger,
            IPetsFoodService petsFoodService)
        {
            _logger = logger;
            _petsFoodService = petsFoodService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreatePetsFoodRequest request)
        {
            var result = await _petsFoodService.AddAsync(
                request.Name,
                request.Description,
                request.Price!.Value,
                request.AvailableStock,
                request.PetsFoodBrandId!.Value,
                request.PetsFoodTypeId!.Value,
                request.PictureFileName);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdatePetsFoodRequest request)
        {
            var result = await _petsFoodService.UpdateAsync(
                request.Id!.Value,
                request.Name,
                request.Description,
                request.Price!.Value,
                request.AvailableStock,
                request.PetsFoodBrandId!.Value,
                request.PetsFoodTypeId!.Value,
                request.PictureFileName);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _petsFoodService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
