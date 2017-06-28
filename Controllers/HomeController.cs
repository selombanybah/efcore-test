using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pocoinheritance.Data;
using pocoinheritance.Models;

namespace pocoinheritance.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db;
        public HomeController(MyDbContext dbcontext)
        {
            db=dbcontext;
        }
        public IActionResult Index()
        {
            Student s=new Student{
                StudentAge=15,
                FirstName="Joe",
                LastName="Doe"
            };
            Person p=new Person{
                FirstName="james",
                LastName="Bond"
            };
            s.Friends.Add(p);
            db.Persons.Add(p);
            db.Students.Add(s);
            db.SaveChanges();
            ViewBag.DbStudent=db.Students.FirstOrDefault(item=>item.Friends.Count>0);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
