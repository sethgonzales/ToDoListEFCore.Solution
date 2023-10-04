namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; } //uppercase syntax and name must match what these are called in the database. Primary key (id number) follows [ClassName]Id syntax
    public string Description { get; set; }
    public Category Category { get; set; } //grab the category object. This is the phone - how we make the call
    public int CategoryId { get; set; } //grab the category id - this is the phone number -how we use the phone to connect to the other person


  }
}
