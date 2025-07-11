using Microsoft.AspNetCore.SignalR;

namespace ResearchTracker.Api.Models;

public class ResearchProject
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PrincipalInvestigator { get; set; } = string.Empty;
    public string Status { get; set; } = "Not Started"; // Not Started, Ongoing, Completed
}