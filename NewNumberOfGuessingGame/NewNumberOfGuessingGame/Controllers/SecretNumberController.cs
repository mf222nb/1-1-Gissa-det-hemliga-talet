using NewNumberOfGuessingGame.Models;
using NewNumberOfGuessingGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewNumberOfGuessingGame.Controllers
{
    public class SecretNumberController : Controller
    {
        protected SecretNumber SessionGuess 
        {
            get
            {
                return Session["SessionGuess"] as SecretNumber ?? (SecretNumber)(Session["SessionGuess"] = new SecretNumber());
            }
        }

        //
        // GET: /SecretNumber/
        public ActionResult Index()
        {
            var model = new SecretIndexViewModels()
            {
                SecretNumber = SessionGuess
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SecretIndexViewModels model)
        {
            try
            {
                model.SecretNumber = SessionGuess;
                int guess = model.Guess.Value;
                model.SecretNumber.MakeGuess(guess);
                
            }
            catch (Exception)
            {
                throw;
            }
            
            return View(model);
        }
	}
}