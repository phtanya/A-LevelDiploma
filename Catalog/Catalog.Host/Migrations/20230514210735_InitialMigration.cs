using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Host.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "pets_food_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "pets_food_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "PetsFoodBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsFoodBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetsFoodType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsFoodType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetsFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: true),
                    PetsFoodTypeId = table.Column<int>(type: "integer", nullable: false),
                    PetsFoodBrandId = table.Column<int>(type: "integer", nullable: false),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetsFood_PetsFoodBrand_PetsFoodBrandId",
                        column: x => x.PetsFoodBrandId,
                        principalTable: "PetsFoodBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetsFood_PetsFoodType_PetsFoodTypeId",
                        column: x => x.PetsFoodTypeId,
                        principalTable: "PetsFoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetsFood_PetsFoodBrandId",
                table: "PetsFood",
                column: "PetsFoodBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PetsFood_PetsFoodTypeId",
                table: "PetsFood",
                column: "PetsFoodTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetsFood");

            migrationBuilder.DropTable(
                name: "PetsFoodBrand");

            migrationBuilder.DropTable(
                name: "PetsFoodType");

            migrationBuilder.DropSequence(
                name: "pets_food_hilo");

            migrationBuilder.DropSequence(
                name: "pets_food_type_hilo");
        }
    }
}
