using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AjaxDemo.Models;
using Microsoft.AspNet.Http;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private DemoAjaxContext db = new DemoAjaxContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HelloAjax()
        {
            return Content("Hello from the controller!", "text/plain");
        }
        public IActionResult Sum(int firstNumber, int secondNumber)
        {
            return Content((firstNumber + secondNumber).ToString(), "text/plain");
        }
        public IActionResult DisplayObject()
        {
            Destination destination = new Destination("Tokyo", "Japan", 1);
            return Json(destination);
        }
        public IActionResult DisplayObjectList()
        {
            Destination destination1 = new Destination("Tokyo", "Japan", 1);
            Destination destination2 = new Destination("Paris", "France", 2);
            Destination destination3 = new Destination("London", "England", 3);
            var destinations = new List<Destination> { destination1, destination2, destination3 };
            return Json(destinations);
        }
        public IActionResult DemoAjaxView()
        {
            return View();
        }
        public IActionResult DisplayDatabaseList()
        {
            var destinations = db.Destinations.ToList();
            return Json(destinations);
        }

        public IActionResult Destinations()
        {
            return View(db.Destinations.ToList());
        }

        public IActionResult RandomDestinations(string number)
        {
            return View(db.Destinations.OrderBy(r => Guid.NewGuid()).Take(Int32.Parse(number)));
        }

        public IActionResult NewDestination(string newCity, string newCountry)
        {
            Destination newDestination = new Destination(newCity, newCountry);
            db.Destinations.Add(newDestination);
            db.SaveChanges();
            return Json(newDestination);
        }
    }
}
