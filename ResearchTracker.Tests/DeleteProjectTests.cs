using System.Net;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ResearchTracker.Api.Models;

namespace ResearchTracker.Tests;

public class DeleteProjectTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public DeleteProjectTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Delete_Project_Returns_NoContent_When_Successful()
    {
        // Arrange - first create project
        var newProject = new { Title = "Test Project", PiName = "Dr. X", Status = "Proposed" };
        var createResponse = await _client.PostAsJsonAsync("/projects", newProject);
        var created = await createResponse.Content.ReadFromJsonAsync<ResearchProject>();

        // Act - delete created project
        var deleteResponse = await _client.DeleteAsync($"/projects/{created!.Id}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        // confirm it's gone
        var getResponse = await _client.GetAsync($"/projects/{created.Id}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }
}