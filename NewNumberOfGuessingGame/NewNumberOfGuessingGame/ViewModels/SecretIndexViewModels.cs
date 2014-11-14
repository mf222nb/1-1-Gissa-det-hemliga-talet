using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewNumberOfGuessingGame.Models;
using System.ComponentModel.DataAnnotations;

namespace NewNumberOfGuessingGame.ViewModels
{
    public class SecretIndexViewModels
    {
        public SecretNumber SecretNumber { get; set; }
        [Required]
        public int? Guess { get; set; }
        public string OutcomeMessage { get; set; }
        public int Count { get; set; }
        public void OutconeMessage()
        {
            switch (SecretNumber.LastGuessedNumber.Outcome)
            {
                case Outcome.Indefinite:
                    OutcomeMessage = "Ingen gissning gjord";
                    break;
                case Outcome.Low:
                    OutcomeMessage = "För lågt";
                    break;
                case Outcome.High:
                    OutcomeMessage = "För högt";
                    break;
                case Outcome.Right:
                    OutcomeMessage = "Rätt gissat";
                    break;
                case Outcome.NoMoreGuesses:
                    OutcomeMessage = "Du har inga gissningar kvar";
                    break;
                case Outcome.OldGuess:
                    OutcomeMessage = "Du har redan gissat på det talet";
                    break;
                default:
                    break;
            }
        }
    }
}