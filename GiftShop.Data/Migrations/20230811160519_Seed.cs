using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("678c2eea-223a-4272-8abc-0339a4ae4bee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c80c0df4-94ac-4eaf-aea5-912d0f9b8b57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfae175a-0f6f-431a-ac55-3f0c6ddf9b9a"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("041de077-c96a-42c4-8daf-ff82b95729a9"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("4fb0e4e3-6f8a-448b-bb53-69c5fabb75e2"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("c740d64c-e5fb-4fa4-9a76-99e566f87abb"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("041de077-c96a-42c4-8daf-ff82b95729a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4fb0e4e3-6f8a-448b-bb53-69c5fabb75e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c740d64c-e5fb-4fa4-9a76-99e566f87abb"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("678c2eea-223a-4272-8abc-0339a4ae4bee"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("c80c0df4-94ac-4eaf-aea5-912d0f9b8b57"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("cfae175a-0f6f-431a-ac55-3f0c6ddf9b9a"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });
        }
    }
}
