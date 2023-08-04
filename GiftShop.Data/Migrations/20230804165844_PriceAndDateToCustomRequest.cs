using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class PriceAndDateToCustomRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06e4f7aa-ee39-4d6a-a20f-876f7a83e97a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a46284b3-6953-45c9-ae8c-54d3bd210f64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b38d8089-3d4e-496a-8557-cbc7b1217cf4"));

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CustomRequests",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("81bd0f5b-46aa-42f0-b6e0-7841f9d2ecf5"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("d496bfbe-379e-4266-afd6-e12e47d6884f"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("ffe4a345-162e-461b-aeca-74204148b5ff"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("81bd0f5b-46aa-42f0-b6e0-7841f9d2ecf5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d496bfbe-379e-4266-afd6-e12e47d6884f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffe4a345-162e-461b-aeca-74204148b5ff"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CustomRequests");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("06e4f7aa-ee39-4d6a-a20f-876f7a83e97a"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("a46284b3-6953-45c9-ae8c-54d3bd210f64"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("b38d8089-3d4e-496a-8557-cbc7b1217cf4"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });
        }
    }
}
