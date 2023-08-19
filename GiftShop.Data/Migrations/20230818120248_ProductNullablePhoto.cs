using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class ProductNullablePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[,]
                {
                    { new Guid("193f5a1c-d161-4833-9789-9acc26a0697d"), "Elevate the ordinary with our crochet bouquet of five intricately crafted roses, a timeless and artful display that captures the essence of nature's beauty in delicate yarn. A thoughtful and lasting gift for any occasion, adding a touch of handmade elegance to your surroundings.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("2f558699-0ade-4437-a52e-649ce238b2aa"), "Wrap yourself in the soothing comfort of our blue soft crochet blanket. Handcrafted with care, this cozy and inviting blanket features a delicate crochet pattern that adds a touch of elegance to its comforting embrace. ", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("73339734-206e-4540-b670-f1530c202ca3"), "Say hello to Leggy Froggie, our delightful crochet creation that adds a playful twist to traditional plushies. With its vibrant colors, long and stretchy legs, and a cheerful smile, Leggy Froggie is ready to hop into your heart and become a cherished companion.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691667795/Frog.jpg", "Leggy Froggie", 15.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "12cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("b9bff006-e66c-43d4-8dd1-629b70e3f5c1"), "Meet our adorable crochet penguin, meticulously handcrafted to bring a touch of whimsy and charm into your life. With its intricate stitches and lovable design, this penguin plushie is a perfect cuddly companion for both kids and the young at heart.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691390683/test.jpg", "Penguin", 35.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "25cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("b9d8d516-885b-43bf-a747-8da6f58cecff"), "Introduce a serene touch to your living space with our blue pillow, its soothing hue and plush texture offering both aesthetic elegance and cozy comfort.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691317411/Pillow.jpg", "Pillow", 60.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "40x40cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("ed73248a-9a68-41f2-a926-51de5d086ce3"), "Delight in the enchanting innocence of our crochet baby deer plushie, a soft and lovable addition to any nursery that promises warmth and companionship for your little bundle of joy.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("193f5a1c-d161-4833-9789-9acc26a0697d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f558699-0ade-4437-a52e-649ce238b2aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73339734-206e-4540-b670-f1530c202ca3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9bff006-e66c-43d4-8dd1-629b70e3f5c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9d8d516-885b-43bf-a747-8da6f58cecff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed73248a-9a68-41f2-a926-51de5d086ce3"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
