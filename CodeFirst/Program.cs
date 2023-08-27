// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CourseLevel Level { get; set; }
    public float FullPrice { get; set; }
    public Author Author { get; set; }
    public IList<Tag> Tags { get; set; }
}
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Course> Courses { get; set; }
}
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Course> Courses { get; set; }
}
public enum CourseLevel
{
    Beginner = 1,
    Intermediate = 2,
    Advanced = 3
}

public class PlutoDbContext : DbContext
{
    public string PlutoConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pluto;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public PlutoDbContext() : base()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(PlutoConnectionString);
        }
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Tag> Tags { get; set; }
}