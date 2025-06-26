using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"Server=NITRO-JN\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;TrustServerCertificate=true;");
    }
}