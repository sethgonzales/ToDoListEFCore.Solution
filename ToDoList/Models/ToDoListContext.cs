using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext //create reference to database and extend functionality of EF Core's DBContext class
  {
    public DbSet<Item> Items { get; set; } //items property matching our items table in our database. Declare class name in <<
     public DbSet<Category> Categories { get; set; }


    public ToDoListContext(DbContextOptions options) : base(options) { } //constructor that inherits DBContext class behaviors, with prevention of dependency injections 
  }
}