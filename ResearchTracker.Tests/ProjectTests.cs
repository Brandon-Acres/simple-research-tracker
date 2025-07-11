using ResearchTracker.Api.Models;

namespace ResearchTracker.Tests;

public class ProjectTests
{
    [Fact]
    public void CanCreateProject()
    {
        var project = new ResearchProject { Title = "AI Study", PrincipalInvestigator = "Dr. Smith" };
        // Assert.Equal("AI Study", project.Title);
        // Assert.NotEqual("ML topics", project.Title);
    }

    // Will develop more detailed tests
}