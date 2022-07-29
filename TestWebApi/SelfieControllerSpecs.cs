using FluentAssertions;
using SelfieAWookie.API.UI.Controllers;

namespace TestWebApi;

public class SelfieControllerSpecs
{
    [Fact]
    public void Should_return_a_list_of_selfies()
    {
        // Arrange
        var controller = new SelfieController();
        
        
        // Act
        var result = controller.Get().ToList();

        // Assert
        result.Should().NotBeNull();
        result.GetEnumerator().MoveNext().Should().BeTrue();
    }
}