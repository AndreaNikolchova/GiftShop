using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class CartProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("088cc830-f004-4980-9a1b-0586526ff8db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f89748d-8756-4dc6-a4ca-c6c6613f8dd0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8689acac-0da9-4ac3-ad0a-e1f6d4e04917"));

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("0cb8c17f-bc8d-4b6f-96d1-fac2682fed5f"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("5b8d121a-3396-49ee-9809-3494cfa281ca"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("72233928-c6fe-48ef-927f-f0e554b011f9"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0cb8c17f-bc8d-4b6f-96d1-fac2682fed5f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5b8d121a-3396-49ee-9809-3494cfa281ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72233928-c6fe-48ef-927f-f0e554b011f9"));

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Cart_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("088cc830-f004-4980-9a1b-0586526ff8db"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("2f89748d-8756-4dc6-a4ca-c6c6613f8dd0"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("8689acac-0da9-4ac3-ad0a-e1f6d4e04917"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductsId",
                table: "CartProduct",
                column: "ProductsId");
        }
    }
}
