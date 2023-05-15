using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PetsFood, PetsFoodDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<PetsFoodPictureResolver, string>(c => c.PictureFileName));
        CreateMap<PetsFoodBrand, PetsFoodBrandDto>();
        CreateMap<PetsFoodType, PetsFoodTypeDto>();
    }
}