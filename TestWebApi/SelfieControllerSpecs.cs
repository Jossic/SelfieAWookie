using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SelfieAWookie.API.UI.Controllers;

namespace TestWebApi;

public class SelfieControllerSpecs
{
    [Fact]
    public void Should_return_a_list_of_selfies()
    {
        // Arrange
        var controller = new SelfieController(null);
        
        
        // Act
        var result = controller.Get();

        // Assert
        result.Should().NotBeNull();
        // var okResult = result as OkObjectResult;
        // okResult!.Value.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }
}