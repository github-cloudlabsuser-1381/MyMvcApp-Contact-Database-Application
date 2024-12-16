using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

    // GET: User
    public ActionResult Index()
    {
        // Implement the Index method here
        return View(userlist);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        // Implement the details method here
        var user = userlist.Find(user => user.Id == id);
        if (user != null)
        {
            return View(user);
        }
        return NotFound();
    }

    // GET: User/Create
    public ActionResult Create()
    {
        // Implement the Create method here
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        // Implement the Create method (POST) here
        if (ModelState.IsValid)
        {
            userlist.Add(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        // This method is responsible for displaying the view to edit an existing user with the specified ID.
        // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
        var user = userlist.Find(user => user.Id == id);
        if (user != null)
        {
            return View(user);
        }
        return NotFound();
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
        // It receives user input from the form submission and updates the corresponding user's information in the userlist.
        // If successful, it redirects to the Index action to display the updated list of users.
        // If no user is found with the provided ID, it returns a HttpNotFoundResult.
        // If an error occurs during the process, it returns the Edit view to display any validation errors.
        var userToUpdate = userlist.Find(u => u.Id == id);
        if (userToUpdate != null)
        {
            if (ModelState.IsValid)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                // userToUpdate.Age = user.Age;
                return RedirectToAction("Index");
            }
            return View(user);
        }
        return NotFound();
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        // Implement the Delete method here
        var user = userlist.Find(user => user.Id == id);
        if (user != null)
        {
            return View(user);
        }
        return NotFound();
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        // Implement the Delete method (POST) here
        var userToDelete = userlist.Find(user => user.Id == id);
        if (userToDelete != null)
        {
            userlist.Remove(userToDelete);
            return RedirectToAction("Index");
        }
        return NotFound();
    }
}