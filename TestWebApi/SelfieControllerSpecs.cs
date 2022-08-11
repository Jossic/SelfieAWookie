using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookie.Core.Framework;
using SelfieAWookie.Core.Selfies.Domain;

namespace TestWebApi;

public class SelfieControllerSpecs
{
    [Fact]
    public void Should_add_one_selfie()
    {
        // Arrange
        SelfieDto selfie = new SelfieDto();
        var repositoryMock = new Mock<ISelfieRepository>();
        var unit = new Mock<IUnitOfWork>();
        repositoryMock.Setup(item => item.UnitOfWork).Returns(unit.Object);
        repositoryMock.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });

        // Act
        var controller = new SelfieController(repositoryMock.Object);
        var result = controller.AddOne(selfie);
        var addedSelfie = (result as OkObjectResult).Value as SelfieDto;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        addedSelfie.Should().NotBeNull();
        addedSelfie.Id.Should().BeGreaterThan(0);
    }


    [Fact]
    public void Should_return_a_list_of_selfies()
    {

        // Arrange
        var repositoryMock = new Mock<ISelfieRepository>();
        var expectedList = new List<Selfie>() {
            new Selfie() {Wookie = new Wookie()},
            new Selfie() {Wookie = new Wookie()}
        };
        repositoryMock.Setup(item => item.GetAll()).Returns(expectedList);

        var controller = new SelfieController(repositoryMock.Object);

        // Act
        var result = controller.Get();
        var okResult = result as OkObjectResult;
        List<SelfieResumeDto> list = okResult.Value as List<SelfieResumeDto>;

        // Assert
        result.Should().NotBeNull();

        okResult.Value.Should().BeOfType<List<SelfieResumeDto>>();
        okResult!.Value.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        list.Should().HaveCount(expectedList.Count);


    }

}