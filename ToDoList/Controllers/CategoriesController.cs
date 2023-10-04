using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;
    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Categories";
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = "Create Category";
      return View();
    }
    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Category Details";
      Category thisCategory = _db.Categories.Include(category => category.Items).FirstOrDefault(category => category.CategoryId == id); //Here we state that we want to include the Items property, which tells EF Core to fetch every Item object belonging to the Category.Just like before, if we don't explicitly tell EF Core to include the data for the navigation property Items with the code .Include(category => category.Items), it won't gather that data. However, we'll still get the Category.CategoryId and the Category.Name information.

      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      ViewBag.PageTitle = "Edit Category";
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Categories.Update(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      ViewBag.PageTitle = "Delete Category";
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}