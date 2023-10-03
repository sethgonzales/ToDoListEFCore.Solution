namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; } //uppercase syntax and name must match what these are called in the database. Primary key (id number) follows [ClassName]Id syntax
    public string Description { get; set; }

  }
}
