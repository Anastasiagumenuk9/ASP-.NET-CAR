using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("[controller]/[action]")]
    public class CarController : Controller
    {
        private readonly ICarManager commodityManager;

        private readonly IModeratorManager moderatorManager;

        private readonly IOrderManager basketManager;

        private readonly IBasketCommoditiesManager basketCommoditiesManager;


        public IActionResult Index()
        {
            return View();
        }
    }
}