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
        [Range(1, 100)]
        public int? Guess { get; set; }
        public int Count { get; set; }
        public string OutcomeMessage
        {
            get
            {
                switch (SecretNumber.LastGuessedNumber.Outcome)
                {
                    case Outcome.Indefinite:
                        return "Ingen gissning gjord";
                        
                    case Outcome.Low:
                        return "För lågt";
                        
                    case Outcome.High:
                        return "För högt";
                        
                    case Outcome.Right:
                        return "Rätt gissat";
                        
                    case Outcome.NoMoreGuesses:
                        return "Du har inga gissningar kvar";
                        
                    case Outcome.OldGuess:
                        return "Du har redan gissat på det talet";
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}