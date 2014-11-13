using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewNumberOfGuessingGame.Models;

namespace NewNumberOfGuessingGame.ViewModels
{
    public class SecretIndexViewModels
    {
        private string _message;
        public SecretNumber SecretNumber { get; set; }
        public int? Guess { get; set; }
        public void Message()
        {
            switch (SecretNumber.LastGuessedNumber.Outcome)
            {
                case Outcome.Indefinite:
                    _message = "Ingen gissning";
                    break;
                case Outcome.Low:
                    _message = "För lågt";
                    break;
                case Outcome.High:
                    _message = "För högt";
                    break;
                case Outcome.Right:
                    _message = "Rätt gissat";
                    break;
                case Outcome.NoMoreGuesses:
                    _message = "Du har inga gissningar kvar";
                    break;
                case Outcome.OldGuess:
                    _message = "Du har redan gissat på det talet";
                    break;
                default:
                    break;
            }
        }
    }
}