using System.Net;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
public class PetsFoodBffController : ControllerBase
{
    private readonly IPetsFoodService _petsFoodService;
    private readonly IPetsFoodBrandService _petsFoodBrandService;
    private readonly IPetsFoodTypeService _petsFoodTypeService;

    public PetsFoodBffController(
        IPetsFoodTypeService petsFoodTypeService,
        IPetsFoodService petsFoodService,
        IPetsFoodBrandService petsFoodBrandService)
    {
        _petsFoodService = petsFoodService;
        _petsFoodTypeService = petsFoodTypeService;
        _petsFoodBrandService = petsFoodBrandService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<PetsFoodDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> PetsFoods(PaginatedItemsRequest<PetsFoodFilter> request)
    {
        var result = await _petsFoodService.GetPetsFoodsAsync(request.Filter, request.PageSize, request.PageIndex);
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<PetsFoodBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Brands()
    {
        var result = await _petsFoodBrandService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<PetsFoodTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> PetsFoodTypes()
    {
        var result = await _petsFoodTypeService.GetAllAsync();
        return Ok(result);
    }
}