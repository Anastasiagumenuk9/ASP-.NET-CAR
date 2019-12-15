using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MODELS.ViewModels;

namespace Application.Controllers
{
   [Route("[controller]/[action]")]
    public class CarController : Controller
    {
        public ICarManager carManager;
        public IPhotoCarManager photoCarManager;
        public IColorManager colorManager;
     
        public CarController(ICarManager carManager, IColorManager colorManager)
        {
            this.carManager = carManager;
            this.colorManager = colorManager;
            
        }

        [HttpPost]
        public IActionResult AddCar(CarViewModel item)
        {
           
            carManager.Insert(item);
            return RedirectToAction("Index", "Car");
        }




       
        [HttpGet]
        public IActionResult DeleteConfirmed(int carId)
        {

            carManager.Delete(carId);
            return RedirectToAction("Index", "Car");
        }


      
        [HttpPost]
        public IActionResult Delete(int carId)
        {
            var car = carManager.GetById(carId);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }


     
        [HttpPost]
        public IActionResult Edit(CarViewModel item)
        {

            if (ModelState.IsValid)
            {
                carManager.Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }


    
        [HttpGet]
        public IActionResult Edit(int carId)
        {
            var car = carManager.GetById(carId);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }


       
        [HttpGet]
        public IActionResult Index()
        {
            var cars = carManager.GetCars();
                return View(cars);
        }


        [HttpGet]
        public IActionResult IndexAdmin()
        {
            return View(carManager.GetCars());
        }


        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Details(int carId)
        {
            return View(carManager.GetById(carId));
        }


        [HttpGet]
       // [AutoValidateAntiforgeryToken]
        public IActionResult ShowCars()
        {
            var cars = carManager.GetCars();
           
            return View(cars);
        }



        public IActionResult CarMain(int carId)
        {
            var car = carManager.GetById(carId);
            return View(car);
        }



    }
}