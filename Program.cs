using System.Security.Cryptography;
using Fundamentos_de_Entity_Framework.Context;
using Fundamentos_de_Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = Fundamentos_de_Entity_Framework.Models.Task;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TareasDB"));*/
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTask"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconection", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/task", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.OrderBy(t => t.CreationDate));
});

app.MapGet("/api/task/priority-low", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Where(t => t.Priority == Priority.Media));
});

app.MapGet("/api/task/priority-low-and-category", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(t => t.Category).Where(t => t.Priority == Priority.Media));
});

app.MapGet("/api/categories", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Categories);
});

app.MapPost("api/task", async ([FromServices] TaskContext dbContext, [FromBody] Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    //await dbContext.AddAsync(task);
    await dbContext.Tasks.AddAsync(task);
//    dbContext.Tasks.Add(task);

    await dbContext.SaveChangesAsync();
    
    return Results.Ok("La tarea fue agregada correctamente");
});

app.MapPut("api/task/{id}", async ([FromServices] TaskContext dbContext, [FromBodyAttribute] Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if (task != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.Priority = task.Priority;
        currentTask.Description = task.Description;
        
        await dbContext.SaveChangesAsync();
        
        return Results.Ok("La tarea fue actualizada correctamente");
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("api/task/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>
{
    var task = dbContext.Tasks.Find(id);

    if (task != null)
    {
        dbContext.Remove(task);

        await dbContext.SaveChangesAsync();
        
        return Results.Ok("Tarea borrada correctamente");
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();
