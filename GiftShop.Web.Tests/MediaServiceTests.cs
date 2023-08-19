
namespace GiftShop.Web.Tests
{
    using CloudinaryDotNet.Actions;
    using GiftShop.Services.MediaService;
    using GiftShop.Services.MediaService.Contracts;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    public class MediaServiceTests
    {
        [Fact]
        public async Task UploadPictureAsync_Success()
        {

            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Url = new Uri("https://example.com/image.jpg") });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(file => file.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            var result = await mediaService.UploadPictureAsync(formFileMock.Object, "image_name");


            Assert.Equal("https://example.com/image.jpg", result);
        }

        [Fact]
        public async Task UploadPictureAsync_FileTooBig_ThrowsException()
        {

            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Error = new Error() });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(file => file.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => mediaService.UploadPictureAsync(formFileMock.Object, "image_name")
            );
        }
    }
}
