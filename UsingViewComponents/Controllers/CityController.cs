using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private ICityRepository repository;

        public CityController(ICityRepository repo)
        {
            repository = repo;
        }
        public ViewResult Create() => View();
        [HttpPost]
        public IActionResult Create(City newCity) 
        {
            repository.AddCity(newCity);
            return RedirectToAction("Index","Home");
        }
        public IViewComponentResult Invoke() 
        {
            return new ViewViewComponentResult() 
            {
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IEnumerable<City>>(ViewData, repository.Cities)
            }; 
        }
    }
}
