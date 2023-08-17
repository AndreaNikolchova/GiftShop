namespace GiftShop.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using GiftShop.Services.MediaService;
    using System.IO;

    public class CloudinaryServiceTests
    {
        private const string TestCloudName = "andysgiftshop";
        private const string TestApiKey = "611171239463741";
        private const string TestApiSecret = "QkoqvqrGEpLH0iv-mfwYWl1ddCQ";

        [Fact]
        public async Task UploadAsync_UploadSuccessful_ReturnsImageUrl()
        {
            // Arrange
            var cloudinary = new Cloudinary(
                new Account(TestCloudName, TestApiKey, TestApiSecret)
            );

            var cloudinaryService = new CloudinaryService(cloudinary);

            using var testFile = File.OpenRead(@"C:\Users\Adi\Desktop\photos for giftshop\IMG_3876.jpeg"); 

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("test_image.jpg", testFile),
                PublicId = "testPublicId", 
            };

            // Act
            var result = await cloudinaryService.UploadAsync(uploadParams);

            // Assert
            Assert.NotNull(result.Url);
            Assert.StartsWith("http://res.cloudinary.com/", result.Url.AbsoluteUri);
        }
    }

}
