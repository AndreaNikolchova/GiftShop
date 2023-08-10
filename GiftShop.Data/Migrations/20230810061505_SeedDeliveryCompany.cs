using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class SeedDeliveryCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("5f6bd9b9-d348-4dea-813c-93a1a365f288"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f3776ca-578c-4f78-8c02-7bca1f35f606"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("309a38d9-6c18-411c-a215-225c6591c06d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af56957a-a164-422f-b033-7d320e68e5f2"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DeliveryCompanies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("3505bf92-0bcd-463f-b117-9f0d8365ef66"),
                columns: new[] { "Name", "Price" },
                values: new object[] { "Ekont Avtomat", 6m });

            migrationBuilder.UpdateData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("41be4560-ba27-46c7-a75c-5dfe69339302"),
                columns: new[] { "Name", "Price" },
                values: new object[] { "Speedy to your address", 8m });

            migrationBuilder.UpdateData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("49ce683b-bd2d-4d6c-8d3f-fea4395cefe6"),
                columns: new[] { "Name", "Price" },
                values: new object[] { "Sameday Avtomat", 3.48m });

            migrationBuilder.InsertData(
                table: "DeliveryCompanies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("20adea35-fc7d-4d09-a08d-c1565da80428"), "Ekont to your address", 7m },
                    { new Guid("32399eb3-76c3-4c96-8b63-1ae65d949175"), "Speedy Avtomat", 4.16m },
                    { new Guid("692078e5-eaed-48f6-b513-c81fe669f8c3"), "Sameday to your address", 5.88m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[,]
                {
                    { new Guid("580c60d4-b959-48f2-b853-ea5921717ae2"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("6ab8d854-dddc-4ec7-bd90-91cdaec4100f"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") },
                    { new Guid("86d73a25-da4f-4741-910d-0b3405edafac"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("20adea35-fc7d-4d09-a08d-c1565da80428"));

            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("32399eb3-76c3-4c96-8b63-1ae65d949175"));

            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("692078e5-eaed-48f6-b513-c81fe669f8c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("580c60d4-b959-48f2-b853-ea5921717ae2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ab8d854-dddc-4ec7-bd90-91cdaec4100f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86d73a25-da4f-4741-910d-0b3405edafac"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DeliveryCompanies");

            migrationBuilder.UpdateData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("3505bf92-0bcd-463f-b117-9f0d8365ef66"),
                column: "Name",
                value: "Ekont");

            migrationBuilder.UpdateData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("41be4560-ba27-46c7-a75c-5dfe69339302"),
                column: "Name",
                value: "Speedy");

            migrationBuilder.UpdateData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("49ce683b-bd2d-4d6c-8d3f-fea4395cefe6"),
                column: "Name",
                value: "Sameday");

            migrationBuilder.InsertData(
                table: "DeliveryCompanies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5f6bd9b9-d348-4dea-813c-93a1a365f288"), "Box Now" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[,]
                {
                    { new Guid("0f3776ca-578c-4f78-8c02-7bca1f35f606"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("309a38d9-6c18-411c-a215-225c6591c06d"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("af56957a-a164-422f-b033-7d320e68e5f2"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") }
                });
        }
    }
}
