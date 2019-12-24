using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
                .Include(Chef => Chef.CreatedDishes)
                .ToList();
            return View(AllChefs);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(Chef thisChef)
        {
            if (ModelState.IsValid)
            {
                dbContext.Chefs.Add(thisChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> DishesWithCreator = dbContext.Dishes
                .Include(dish => dish.Creator)
                .ToList();
            return View(DishesWithCreator);
        }

        [HttpGet("/dishes/new")] //form to add a new dish
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.Chef = AllChefs;
            return View("NewDish");
        }

        [HttpPost("/dishes/addDish")]
        public IActionResult AddDish(Dish thisDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(thisDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.Chef = AllChefs;
            return View("NewDish");//NewDish is the html file
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
