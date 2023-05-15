using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.PetsFoodBrands.Any())
        {
            await context.PetsFoodBrands.AddRangeAsync(GetPreconfiguredPetsFoodBrands());

            await context.SaveChangesAsync();
        }

        if (!context.PetsFoodTypes.Any())
        {
            await context.PetsFoodTypes.AddRangeAsync(GetPreconfiguredPetsFoodTypes());

            await context.SaveChangesAsync();
        }

        if (!context.PetsFoods.Any())
        {
            await context.PetsFoods.AddRangeAsync(GetPreconfiguredPetsFoods());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<PetsFoodBrand> GetPreconfiguredPetsFoodBrands()
    {
        return new List<PetsFoodBrand>()
        {
            new PetsFoodBrand() { Brand = "Purina" },
            new PetsFoodBrand() { Brand = "Dog Chow" },
            new PetsFoodBrand() { Brand = "Nutrivet" },
            new PetsFoodBrand() { Brand = "Whiskas" },
            new PetsFoodBrand() { Brand = "Lillebro" },
            new PetsFoodBrand() { Brand = "Tetra" }
        };
    }

    private static IEnumerable<PetsFoodType> GetPreconfiguredPetsFoodTypes()
    {
        return new List<PetsFoodType>()
        {
            new PetsFoodType() { Type = "Dog" },
            new PetsFoodType() { Type = "Cat" },
            new PetsFoodType() { Type = "Bird" },
            new PetsFoodType() { Type = "Fish" }
        };
    }

    private static IEnumerable<PetsFood> GetPreconfiguredPetsFoods()
    {
        return new List<PetsFood>()
        {
            new PetsFood
            {
                PetsFoodTypeId = 1,
                PetsFoodBrandId = 1,
                AvailableStock = 100,
                Description = "Energy-rich dry food for medium and large breed active dogs weighing over 10kg",
                Name = "Purina One Medium/Maxi Active Chicken",
                Price = 28.9M,
                PictureFileName = "1.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 1,
                PetsFoodBrandId = 2,
                AvailableStock = 100,
                Description = "Give your puppy the best start in life with this wholesome, flavoursome nutrition, enriched with nutrients and antioxidants that help support healthy development and high activity levels.",
                Name = "Dog Chow Puppy Turkey & Lamb",
                Price = 48.50M,
                PictureFileName = "2.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 1,
                PetsFoodBrandId = 3,
                AvailableStock = 100,
                Description = "High protein dry food for dogs that are very active, with a complete and balanced grain-free recipe that supports healthy joints.",
                Name = "Nutrivet Inne Energetic Dry Dog Food",
                Price = 122,
                PictureFileName = "3.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 2,
                PetsFoodBrandId = 1,
                AvailableStock = 100,
                Description = "Premium dry food for adult cats, with Bifensis Dual Defence formula to strengthen the natural defences, chicken as protein supplier, rich in valuable omega-6 fatty acids & minerals.",
                Name = "Purina ONE Adult Chicken Dry Cat Food",
                Price = 15,
                PictureFileName = "4.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 2,
                PetsFoodBrandId = 3,
                AvailableStock = 100,
                Description = "This healthy dry kitten food has a high-protein, grain-free recipe with herbs, vegetables and fruit.",
                Name = "Nutrivet Inne Dry Kitten Food",
                Price = 19.5M,
                PictureFileName = "5.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 2,
                PetsFoodBrandId = 4,
                AvailableStock = 100,
                Description = "Whiskas Senior 7+ Chicken is prepared with delicious fresh meat and contains a range of important vitamins and minerals your cat needs for vitality.",
                Name = "Whiskas Senior 7+ Chicken",
                Price = 10.45M,
                PictureFileName = "6.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 3,
                PetsFoodBrandId = 5,
                AvailableStock = 100,
                Description = "Lillebro dried meal worms are a hit with wild birds and the ideal alternative to live feeds. ",
                Name = "Lillebro Dried Mealworms",
                Price = 11,
                PictureFileName = "7.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 3,
                PetsFoodBrandId = 5,
                AvailableStock = 100,
                Description = "Premium wild bird food for all-year feeding.",
                Name = "Lillebro Wild Bird Food",
                Price = 10.5M,
                PictureFileName = "8.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 3,
                PetsFoodBrandId = 5,
                AvailableStock = 100,
                Description = "Striped sunflower seeds for wild birds.",
                Name = "Lillebro Sunflower Seeds for Wild Birds",
                Price = 3,
                PictureFileName = "9.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 4,
                PetsFoodBrandId = 6,
                AvailableStock = 100,
                Description = "Complete food flakes for goldfish and other coldwater fish",
                Name = "Tetra Goldfish Flakes",
                Price = 9.7M,
                PictureFileName = "10.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 4,
                PetsFoodBrandId = 6,
                AvailableStock = 100,
                Description = "Premium flake food for all tropical fish.",
                Name = "Tetra Energy Multi-Crisp",
                Price = 14.5M,
                PictureFileName = "11.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 4,
                PetsFoodBrandId = 6,
                AvailableStock = 100,
                Description = "Flake food for all tropical fish",
                Name = "Tetra Ruby Flakes",
                Price = 11,
                PictureFileName = "12.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 1,
                PetsFoodBrandId = 1,
                AvailableStock = 100,
                Description = "Complete dry food for medium breed puppies with sensitive skin.",
                Name = "Purina Pro Plan Medium Puppy Sensitive Skin",
                Price = 29,
                PictureFileName = "13.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 2,
                PetsFoodBrandId = 4,
                AvailableStock = 100,
                Description = "Complete dry food for growing kittens up to 12 months old, carefully prepared, very digestible",
                Name = "Whiskas Junior Chicken",
                Price = 12,
                PictureFileName = "14.png"
            },
            new PetsFood
            {
                PetsFoodTypeId = 3,
                PetsFoodBrandId = 3,
                AvailableStock = 100,
                Description = "Variety seed mixture for all cockatoos, enriched with extra vitamins, minerals and trace element.",
                Name = "Nutrivet Prestige Premium Australian Parrot",
                Price = 22,
                PictureFileName = "15.png"
            },
        };
    }
}