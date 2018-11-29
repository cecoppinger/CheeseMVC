using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            //add new cheese to list
            //Cheese newCheese = new Cheese(name, desc);
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
            
        }
        
        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            Cheese cheeseToEdit = CheeseData.GetById(cheeseId);
            ViewBag.cheese = cheeseToEdit;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            //CheeseData.GetById(cheeseId).Name = name;
            //CheeseData.GetById(cheeseId).Description = description;
            Cheese myCheese = CheeseData.GetById(cheeseId);
            myCheese.Name = name;
            myCheese.Description = description;

            return Redirect("/");
        }
    }
}
