using Fundamentos_de_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using Task = Fundamentos_de_Entity_Framework.Models.Task;


namespace Fundamentos_de_Entity_Framework.Context;

public class TaskContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CategoryFluentConfiguration(modelBuilder, InitCategoryData());
        TaskFluentConfiguration(modelBuilder, InitTaskData());
    }

    private void CategoryFluentConfiguration(ModelBuilder modelBuilder, List<Category>? categoriesInit = null)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("catagory");
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.Name).IsRequired().HasMaxLength(150);
            category.Property(c => c.Description).IsRequired(false);
            category.Property(c => c.Weight);
            if (categoriesInit!=null) category.HasData(categoriesInit);
        });
    }
    private void TaskFluentConfiguration(ModelBuilder modelBuilder, List<Task>? tasksInit = null)
    {
        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("task");
            task.HasKey(t => t.TaskId);
            task.HasOne(t => t.Category)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.CategoryId);
            task.Property(t => t.Title).IsRequired().HasMaxLength(200);
            task.Property(t => t.Description).IsRequired(false);
            task.Property(t => t.Priority);
            task.Property(t => t.CreationDate);
            task.Ignore(t => t.Resume);
            if (tasksInit!=null) task.HasData(tasksInit);
        });
    }

    private List<Category> InitCategoryData()
    {
        List<Category> categoriesInit = new(); 
        categoriesInit.Add(new Category() {CategoryId = Guid.Parse("0350254e-bf94-47ae-af12-66f0c349958a"), Name = "Actividades pendientes", Weight = 20});
        categoriesInit.Add(new Category() {CategoryId = Guid.Parse("edb30390-0964-4d2b-88d3-524798688bc0"), Name = "Actividades personales", Weight = 50});
        categoriesInit.Add(new Category() {CategoryId = Guid.Parse("c23a570b-97aa-414d-8f22-93d4ba804805"), Name = "Actividades deportivas", Weight = 10});
        categoriesInit.Add(new Category() {CategoryId = Guid.Parse("a1c0ea94-091e-48b1-bb43-2a7ef79070ce"), Name = "Actividades familiares", Weight = 10});
        return categoriesInit;
    }
    
    private List<Task> InitTaskData()
    {
        List<Task> taskInit = new(); 
        taskInit.Add(new Task() {TaskId = Guid.Parse("719166a3-46cc-4fb8-a24b-44d810dd2f13"), CategoryId = Guid.Parse("0350254e-bf94-47ae-af12-66f0c349958a"), Priority = Priority.Media, Title = "Pago servicios", CreationDate = DateTime.Now});
        taskInit.Add(new Task() {TaskId = Guid.Parse("76377816-924a-4dd7-9b36-73f2f0152e13"), CategoryId = Guid.Parse("edb30390-0964-4d2b-88d3-524798688bc0"), Priority = Priority.Baja, Title = "Terminar de ver la pelicula de Netflix", CreationDate = DateTime.Now});
        taskInit.Add(new Task() {TaskId = Guid.Parse("f39d1a18-5851-41cf-94ff-f3219056d971"), CategoryId = Guid.Parse("c23a570b-97aa-414d-8f22-93d4ba804805"), Priority = Priority.Alta, Title = "Partido vs papa Karen", CreationDate = DateTime.Now});
        return taskInit;
    }

}