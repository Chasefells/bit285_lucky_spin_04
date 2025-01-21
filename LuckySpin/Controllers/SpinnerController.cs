using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.Services;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        //DIJ in 4 STEPS -
        //Done: 0) Register the Repository class as a service in Program.cs
        private readonly Repository _repository; 
        //Done: 1) add an instance variable here of type Repository


        /***
         * Constructor - Done: 2) call for a DIJ Repository object to be passed to the constructor
         **/
        public SpinnerController(Repository repository)
        {
            //DOne: 3) save the DIJ Repository object into your instance variable
            _repository = repository; 
        }

        /***
         * Index Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid)
            {

            return View(player);
        }
            return RedirectToAction("Spin", new { player });
        }
        /***
         * Spin Action
         **/  
               
        public IActionResult Spin(Player player)
        {
            //Create a new Spin with the player
            Spin spin = new Spin { Player = player };
            //Done: Add to LuckList
            bool isWinning = spin.IsWinning;

            _repository.AddSpin(spin);

            return View("Spin", spin);
        }

        /***
         * ListSpins Action
         **/
        [HttpGet]
        public IActionResult LuckList()
        {
                //Done: Pass the repository's Player Spins to the LuckList View
            var spins = _repository.GetPlayerSpins();
                return View(spins);
        }

    }
}

