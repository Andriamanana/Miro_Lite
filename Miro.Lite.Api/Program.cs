using Miro.Lite.Api.Data;
using Microsoft.EntityFrameworkCore;
using Miro.Lite.Api.Mapping;
using Miro.Lite.Api.Entities;
using Miro.Lite.Api.Dto;

var builder = WebApplication.CreateBuilder(args);

//for dataBase
builder.Services.AddDbContext<UserStoryDb>(opt => opt.UseInMemoryDatabase("UserStoryList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//for swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUi();
}

app.MapGet("/", () => "ok");
app.MapGet("/user_stories", async(UserStoryDb db) =>
    await db.UserStories.Select(us => us.ToDto()).ToListAsync());

app.MapGet("/user_stories/{id}", async (int id,UserStoryDb db) =>
    await db.UserStories.FindAsync(id) 
    is UserStory userStory
        ? Results.Ok(userStory)
        : Results.NotFound());

app.MapPost("/user_stories", async (UserStoryDto userStoryDto, UserStoryDb db) =>
{
    db.UserStories.Add(userStoryDto.ToEntity());
    await db.SaveChangesAsync();

    return Results.Created($"/user_stories/{userStoryDto.Id}",userStoryDto);
});

app.MapPut("/user_stories/{id}", async (int id, UserStoryDto userStoryDto, UserStoryDb db) =>
{
    var userStory = await db.UserStories.FindAsync();
    if (userStory is null) return Results.NotFound();
    userStoryDto.ToEntity();
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/user_stories/{id}", async(int id, UserStoryDb db) =>
{
    if (await db.UserStories.FindAsync(id) is UserStory userStory)
    {
        db.UserStories.Remove(userStory);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.Run();
