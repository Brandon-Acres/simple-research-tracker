using ResearchTracker.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// can Add HTTPS redirects later
// app.UseHttpsRedirection();

// In-memory static list for now:
List<ResearchProject> projects = new List<ResearchProject>();

app.MapGet("/projects", () => projects);

app.MapGet("/projects/{id}", (int id) =>
{
    var project = projects.FirstOrDefault(p => p.Id == id);
    return project is not null ? Results.Ok(project) : Results.NotFound();
});

app.MapPost("/projects", (ResearchProject project) =>
{
    project.Id = projects.Count + 1;
    projects.Add(project);
    return Results.Created($"/projects/{project.Id}", project);
});

app.MapPut("/projects/{id}", (int id, ResearchProject updatedProject) =>
{
    var existing = projects.FirstOrDefault(p => p.Id == id);
    if (existing is null) return Results.NotFound();

    existing.Status = updatedProject.Status;
    return Results.Ok(existing);
});

app.MapDelete("/projects/{id}", (int id) =>
{
    var existing = projects.FirstOrDefault(p => p.Id == id);
    if (existing is null) return Results.NotFound();

    projects.Remove(existing);
    return Results.NoContent();
});



app.Run();

public partial class Program { }