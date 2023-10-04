using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      ViewBag.PageTitle = "View All Items";
      List<Item> model = _db.Items.Include(item => item.Category).ToList(); //use the database model instance to 
      return View(model);
    }

    public ActionResult Create() //take us to the form page
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");  //db.Categories is the data that will have. The categoryId is the value of every option. Name is the Category.Name of each object that is displayed in the drop. The name of the viewbag variable has to match the name of the value that will be collected.
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item) //take in form data with post request, assign to variables, and redirect to index
    {
      ViewBag.PageTitle = "Create New Items";
      if (item.CategoryId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Items.Add(item);  //add new item to the items list using db abilities
      _db.SaveChanges(); // build in method to save changes in our directory
      return RedirectToAction("Index"); //take us to the index
    }

    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Item Details";
      Item thisItem = _db.Items.Include(item => item.Category).FirstOrDefault(item => item.ItemId == id); //in our list of items (_db.Items) give me the first (FirstOrDefault) item (item) whose (=>) Id (item.ItemId) matches the id (id) we passed in. Need to Include the item category with this informaiton as well
      return View(thisItem);
    }

    //_db.Items.FirstOrDefault(IsItemMatching);
    //bool IsItemMatching(Item item)
    //{
    // return item.ItemId == id;
    //}
    public ActionResult Edit(int id) //take us to the form page of the item we have selected passing along the items id
    {
      ViewBag.PageTitle = "Edit Item Details";
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id); //instantiate Item thisItem, look into items within database (_db.Items), for the first item matching (or default if none) an item with a specific id that we are passing through
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item) //pass in some item information including the id
    {
      _db.Items.Update(item); //update the list of items in the items list with the item information we are passing in from the form
      _db.SaveChanges(); //save changes 
      return RedirectToAction("Index"); //take us back to the index page
    }

    public ActionResult Delete(int id)
    {
      ViewBag.PageTitle = "Delete Items";
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")] //actionname is renaming the action result delecteconfirmed method back to delete. We cannot have the same method with the same parameter (Delete(int id)) in the same controller
    public ActionResult DeleteConfirmed(int id) //take in the id of the item we are looking at
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id); //find the item in our list of items
      _db.Items.Remove(thisItem); //remove this from the database
      _db.SaveChanges(); //save
      return RedirectToAction("Index"); //take us back to the index
    }
  }
}



