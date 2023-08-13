using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DeliveryCompanies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("20adea35-fc7d-4d09-a08d-c1565da80428"), "Ekont to your address", 7m },
                    { new Guid("32399eb3-76c3-4c96-8b63-1ae65d949175"), "Speedy Avtomat", 4.16m },
                    { new Guid("3505bf92-0bcd-463f-b117-9f0d8365ef66"), "Ekont Avtomat", 6m },
                    { new Guid("41be4560-ba27-46c7-a75c-5dfe69339302"), "Speedy to your address", 8m },
                    { new Guid("49ce683b-bd2d-4d6c-8d3f-fea4395cefe6"), "Sameday Avtomat", 3.48m },
                    { new Guid("692078e5-eaed-48f6-b513-c81fe669f8c3"), "Sameday to your address", 5.88m }
                });

            migrationBuilder.InsertData(
                table: "Packaging",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0d0cdc67-7dfc-4236-8eab-bc8021aeb942"), "Normal", 0m },
                    { new Guid("ec46d5b0-38ca-4d42-a336-1151e4152c29"), "In a box with a bow", 4.5m }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), "Accessories" },
                    { new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), "Toys" },
                    { new Guid("c1143e77-ccfa-4231-bd25-49e29470f13a"), "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "YarnTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33db593a-7a2b-493d-ae3c-f35086510855"), "Alize Puffy" },
                    { new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2"), "Alexander Yarn Ira" },
                    { new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27"), "Baby Bunny" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[,]
                {
                    { new Guid("098e2f65-6390-46df-93d1-247218a92b96"), "Meet our adorable crochet penguin, meticulously handcrafted to bring a touch of whimsy and charm into your life. With its intricate stitches and lovable design, this penguin plushie is a perfect cuddly companion for both kids and the young at heart.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691390683/test.jpg", "Penguin", 35.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "25cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("0f0e4163-f1b8-4814-9d3d-5b0366dbd3c0"), "Say hello to Leggy Froggie, our delightful crochet creation that adds a playful twist to traditional plushies. With its vibrant colors, long and stretchy legs, and a cheerful smile, Leggy Froggie is ready to hop into your heart and become a cherished companion.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691667795/Frog.jpg", "Leggy Froggie", 15.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "12cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("1f6a651a-6bc4-46cc-bb8c-e859cbeaffd8"), "Introduce a serene touch to your living space with our blue pillow, its soothing hue and plush texture offering both aesthetic elegance and cozy comfort.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691317411/Pillow.jpg", "Pillow", 60.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "40x40cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("7bd529b6-53a0-41e3-babc-b40cfeffa774"), "Elevate the ordinary with our crochet bouquet of five intricately crafted roses, a timeless and artful display that captures the essence of nature's beauty in delicate yarn. A thoughtful and lasting gift for any occasion, adding a touch of handmade elegance to your surroundings.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("b328f085-95f8-4345-894a-099c8086e42a"), "Delight in the enchanting innocence of our crochet baby deer plushie, a soft and lovable addition to any nursery that promises warmth and companionship for your little bundle of joy.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") },
                    { new Guid("f2697be3-c0f2-47e5-b9d4-1d182939da9c"), "Wrap yourself in the soothing comfort of our blue soft crochet blanket. Handcrafted with care, this cozy and inviting blanket features a delicate crochet pattern that adds a touch of elegance to its comforting embrace. ", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") }
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
                keyValue: new Guid("3505bf92-0bcd-463f-b117-9f0d8365ef66"));

            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("41be4560-ba27-46c7-a75c-5dfe69339302"));

            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("49ce683b-bd2d-4d6c-8d3f-fea4395cefe6"));

            migrationBuilder.DeleteData(
                table: "DeliveryCompanies",
                keyColumn: "Id",
                keyValue: new Guid("692078e5-eaed-48f6-b513-c81fe669f8c3"));

            migrationBuilder.DeleteData(
                table: "Packaging",
                keyColumn: "Id",
                keyValue: new Guid("0d0cdc67-7dfc-4236-8eab-bc8021aeb942"));

            migrationBuilder.DeleteData(
                table: "Packaging",
                keyColumn: "Id",
                keyValue: new Guid("ec46d5b0-38ca-4d42-a336-1151e4152c29"));

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("c1143e77-ccfa-4231-bd25-49e29470f13a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("098e2f65-6390-46df-93d1-247218a92b96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f0e4163-f1b8-4814-9d3d-5b0366dbd3c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f6a651a-6bc4-46cc-bb8c-e859cbeaffd8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd529b6-53a0-41e3-babc-b40cfeffa774"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b328f085-95f8-4345-894a-099c8086e42a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2697be3-c0f2-47e5-b9d4-1d182939da9c"));

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"));

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"));

            migrationBuilder.DeleteData(
                table: "YarnTypes",
                keyColumn: "Id",
                keyValue: new Guid("33db593a-7a2b-493d-ae3c-f35086510855"));

            migrationBuilder.DeleteData(
                table: "YarnTypes",
                keyColumn: "Id",
                keyValue: new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2"));

            migrationBuilder.DeleteData(
                table: "YarnTypes",
                keyColumn: "Id",
                keyValue: new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProducts");
        }
    }
}
