﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewNumberOfGuessingGame.Models
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }
    public struct GuessedNumber
    {
        public int? Number;
        public Outcome Outcome;
    }
}