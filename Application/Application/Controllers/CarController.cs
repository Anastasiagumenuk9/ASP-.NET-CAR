using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MODELS.DB;

namespace Application.Controllers
{
    [Route("[controller]/[action]")]
    public class CarController : Controller
    {
        DataContext db;

        [HttpGet]
        public ActionResult Index()
        {
            var allcars = db.Cars.ToList<Car>();
            ViewBag.Cars = allcars;
            return View();
        }
    }
}