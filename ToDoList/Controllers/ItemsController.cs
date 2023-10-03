using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db; //property of items controller, we can only read what is in the database, not make changes, make an instance of our database model.

    public ItemsController(ToDoListContext db) //data injection of ToDoListContext db, meaning passing in the tools and information from the database
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Item> model = _db.Items.ToList(); //use the database model instance to 
      return View(model);
    }
  }
}
