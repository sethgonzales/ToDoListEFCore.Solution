using System.Collections.Generic;

namespace ToDoList.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; } //not in the database, but acts as a nav link to the Items model, showing that items and categories are related 
    }
}