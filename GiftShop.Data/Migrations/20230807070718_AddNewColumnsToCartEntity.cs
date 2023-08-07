using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class AddNewColumnsToCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83a33b97-0c23-4a1e-990c-b18e32a08e08"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92249239-afef-4488-8afb-670933c3e4f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb97f245-67b2-4aee-8cfa-1f55fbdfaefd"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("a5072856-3d81-4fe6-ba20-cab810e228a1"), null, "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("f2b1ec89-e320-47c2-b639-9a2eaef19a2e"), null, "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("f7a74cdd-88ba-438f-ac15-010a0ed520c5"), null, "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DeliveryCompanyId",
                table: "Cart",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PackegingId",
                table: "Cart",
                column: "PackegingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_DeliveryCompanies_DeliveryCompanyId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Packaging_PackegingId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_CustomerId",
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
                keyValue: new Guid("a5072856-3d81-4fe6-ba20-cab810e228a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2b1ec89-e320-47c2-b639-9a2eaef19a2e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f7a74cdd-88ba-438f-ac15-010a0ed520c5"));

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PackegingId",
                table: "Cart");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("83a33b97-0c23-4a1e-990c-b18e32a08e08"), null, "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", null, 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 1, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("92249239-afef-4488-8afb-670933c3e4f3"), null, "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", null, 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 2, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "OrderId", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("eb97f245-67b2-4aee-8cfa-1f55fbdfaefd"), null, "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", null, 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 1, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });
        }
    }
}
