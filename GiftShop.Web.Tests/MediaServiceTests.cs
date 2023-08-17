using CloudinaryDotNet.Actions;
using GiftShop.Services.MediaService;
using GiftShop.Services.MediaService.Contracts;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GiftShop.Web.Tests
{
    public class MediaServiceTests
    {
        [Fact]
        public async Task UploadPictureAsync_Success()
        {
            // Arrange
            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Url = new Uri("https://example.com/image.jpg") });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(file => file.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            // Act
            var result = await mediaService.UploadPictureAsync(formFileMock.Object, "image_name");

            // Assert
            Assert.Equal("https://example.com/image.jpg", result);
        }

        [Fact]
        public async Task UploadPictureAsync_FileTooBig_ThrowsException()
        {
            // Arrange
            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Error = new Error() });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(file => file.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            // Act and Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => mediaService.UploadPictureAsync(formFileMock.Object, "image_name")
            );
        }
    }
}
