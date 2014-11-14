using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewNumberOfGuessingGame.Models
{
    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumber;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess 
        {
            get
            {
                if (Count < MaxNumberOfGuesses && LastGuessedNumber.Outcome != Outcome.Right)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
        public int Count 
        { 
            get
            {
                return _guessedNumber.Count();
            }
        }
        public IList<GuessedNumber> GuessedNumbers 
        { 
            get
            {
                return _guessedNumber.AsReadOnly();
            } 
        }
        public GuessedNumber LastGuessedNumber 
        {
            get
            {
                return _lastGuessedNumber;
            } 
        }
        public int? Number 
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
            private set
            {
                Number = _number;
            } 
        }

        public void Initialize()
        {
            _lastGuessedNumber.Outcome = Outcome.Indefinite;
            _guessedNumber.Clear();
            Random myRandom = new Random();
            _number = myRandom.Next(1, 100);
        }

        public Outcome MakeGuess(int guess)
        {
            if (CanMakeGuess)
            {
                if (guess < 1 || guess > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                foreach (var item in _guessedNumber)
	            {
		            if (item.Number == guess)
	                {
                        return _lastGuessedNumber.Outcome = Outcome.OldGuess;
	                }
	            }
                
                _lastGuessedNumber.Number = guess;
                _guessedNumber.Add(LastGuessedNumber);
                
                if (guess > _number)
                {
                    _lastGuessedNumber.Outcome = Outcome.High;
                }
                else if (guess < _number)
                {
                    _lastGuessedNumber.Outcome = Outcome.Low;
                }
                else if (guess == _number)
                {
                    _lastGuessedNumber.Outcome = Outcome.Right;
                }
            }
            else
            {
                _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
            }
            return _lastGuessedNumber.Outcome;
        }

        public SecretNumber()
        {
            _guessedNumber = new List<GuessedNumber>();
            _lastGuessedNumber = new GuessedNumber();
            Initialize();
        }
    }
}