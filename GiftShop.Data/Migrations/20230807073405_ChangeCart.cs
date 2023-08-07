using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class ChangeCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_DeliveryCompanies_DeliveryCompanyId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Packaging_PackegingId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_DeliveryCompanyId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_PackegingId",
                table: "Cart");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ed10a12-8f27-4b4a-8f2b-658e7080077b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("37d28417-ac0d-4960-9b0e-7d089dc4f009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a46f9df3-2c57-47c8-8bc6-836797530615"));

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PackegingId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Cart");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("1f495f6d-f41e-47ad-826a-aa869ae92976"), null, "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("6a049ae2-eb40-4b6f-ba53-b0448ea10127"), null, "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("b772f8ac-403a-446f-b302-31c1ae27438d"), null, "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f495f6d-f41e-47ad-826a-aa869ae92976"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a049ae2-eb40-4b6f-ba53-b0448ea10127"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b772f8ac-403a-446f-b302-31c1ae27438d"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryCompanyId",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PackegingId",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("0ed10a12-8f27-4b4a-8f2b-658e7080077b"), null, "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("37d28417-ac0d-4960-9b0e-7d089dc4f009"), null, "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("a46f9df3-2c57-47c8-8bc6-836797530615"), null, "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DeliveryCompanyId",
                table: "Cart",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PackegingId",
                table: "Cart",
                column: "PackegingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_DeliveryCompanies_DeliveryCompanyId",
                table: "Cart",
                column: "DeliveryCompanyId",
                principalTable: "DeliveryCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Packaging_PackegingId",
                table: "Cart",
                column: "PackegingId",
                principalTable: "Packaging",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
