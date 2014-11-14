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
            SessionGuess.Initialize();
            var model = new SecretIndexViewModels()
            {
                SecretNumber = SessionGuess
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SecretIndexViewModels model)
        {
            if (Session.IsNewSession)
            {
                model = new SecretIndexViewModels()
                {
                    SecretNumber = SessionGuess
                };
                ModelState.AddModelError(String.Empty, "Session har gått ut, startar nytt spel");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        model.SecretNumber = SessionGuess;
                        int guess = model.Guess.Value;
                        model.SecretNumber.MakeGuess(guess);
                        model.OutconeMessage();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(String.Empty, ex.Message);
                    }
                }
            }
            
            return View(model);
        }
	}
}