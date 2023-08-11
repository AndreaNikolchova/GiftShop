using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShop.Data.Migrations
{
    public partial class SeedMoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2ec037c7-3e9f-4f72-8151-b2b01caebb4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3f8923b1-d309-44ac-a2ec-742e15cef4e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fdd4249d-360b-43e0-a9f0-708382a24b01"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[,]
                {
                    { new Guid("0bfc6304-8a17-4d73-a499-08756b128e47"), "Say hello to Leggy Froggie, our delightful crochet creation that adds a playful twist to traditional plushies. With its vibrant colors, long and stretchy legs, and a cheerful smile, Leggy Froggie is ready to hop into your heart and become a cherished companion.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691667795/Frog.jpg", "Leggy Froggie", 15.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "12cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("257afac7-a2b6-4a90-ab65-f589ab1e3cae"), "Elevate the ordinary with our crochet bouquet of five intricately crafted roses, a timeless and artful display that captures the essence of nature's beauty in delicate yarn. A thoughtful and lasting gift for any occasion, adding a touch of handmade elegance to your surroundings.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") },
                    { new Guid("4ef53813-3384-4ac3-9b13-3c9f3c4f986a"), "Delight in the enchanting innocence of our crochet baby deer plushie, a soft and lovable addition to any nursery that promises warmth and companionship for your little bundle of joy.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") },
                    { new Guid("718d0487-2586-420b-97b1-c38cc23c3bfa"), "Introduce a serene touch to your living space with our blue pillow, its soothing hue and plush texture offering both aesthetic elegance and cozy comfort.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691317411/Pillow.jpg", "Pillow", 60.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "40x40cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("832843b6-ad69-4fb0-beea-ac9f2c9e74c9"), "Wrap yourself in the soothing comfort of our blue soft crochet blanket. Handcrafted with care, this cozy and inviting blanket features a delicate crochet pattern that adds a touch of elegance to its comforting embrace. ", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") },
                    { new Guid("c5eadbc8-c52e-4c8a-9384-2f1fc2f74b05"), "Meet our adorable crochet penguin, meticulously handcrafted to bring a touch of whimsy and charm into your life. With its intricate stitches and lovable design, this penguin plushie is a perfect cuddly companion for both kids and the young at heart.", "https://res.cloudinary.com/andysgiftshop/image/upload/v1691390683/test.jpg", "Penguin", 35.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "25cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0bfc6304-8a17-4d73-a499-08756b128e47"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("257afac7-a2b6-4a90-ab65-f589ab1e3cae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ef53813-3384-4ac3-9b13-3c9f3c4f986a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("718d0487-2586-420b-97b1-c38cc23c3bfa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("832843b6-ad69-4fb0-beea-ac9f2c9e74c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c5eadbc8-c52e-4c8a-9384-2f1fc2f74b05"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("2ec037c7-3e9f-4f72-8151-b2b01caebb4f"), "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg", "Baby Dear", 25.00m, new Guid("979b887d-03fc-4f43-91b4-1c36daae5ac5"), 5, "20 cm", new Guid("fa6e1ffc-2094-4b9d-a985-305443b7ef27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("3f8923b1-d309-44ac-a2ec-742e15cef4e8"), "Blue soft blanket", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg", "Blanket", 130.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "100x180 cm", new Guid("33db593a-7a2b-493d-ae3c-f35086510855") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductTypeId", "Quantity", "Size", "YarnTypeId" },
                values: new object[] { new Guid("fdd4249d-360b-43e0-a9f0-708382a24b01"), "A buquet of 5 roses", "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg", "Roses", 20.00m, new Guid("1e1ee133-0f1a-4585-89ed-e251dd84b98d"), 5, "25 cm", new Guid("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2") });
        }
    }
}
