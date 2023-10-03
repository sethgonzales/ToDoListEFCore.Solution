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

    public ActionResult Create() //take us to the form page
    {
      return View();
    }

    [HttpPost] 
    public ActionResult Create(Item item) //take in form data with post request, assign to variables, and redirect to index
    {
      _db.Items.Add(item);  //add new item to the items list using db abilities
      _db.SaveChanges(); // build in method to save changes in our directory
      return RedirectToAction("Index"); //take us to the index
    }

    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id); //in our list of items (_db.Items) give me the first (FirstOrDefault) item (item) whose (=>) Id (item.ItemId) matches the id (id) we passed in
      return View(thisItem);
    }

  }
}



