using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_Lista10.Controllers
{
    public class GameController : Controller
    {
        private static int range;
        private static int drawnNumber;

        private const string TOO_BIG_NUMBER_COLOR = "color:#F28444";
        private const string CORRECT_NUMBER_COLOR = "color:#A0D9A9";
        private const string TOO_SMALL_NUMBER_COLOR = "color:#F2BF80";

        private static bool readyToGuess;

        static GameController()
        {
            readyToGuess = false;
        }

        [Route("Set,{range}")]
        public IActionResult Set()
        {
            int range;
            int.TryParse((string)RouteData.Values["range"], out range);
            string result;
            string color;
            if (range > 0)
            {
                GameController.range = range;
                result = $"Ustawiono nowy przedział [0, {range - 1}].";
                color = CORRECT_NUMBER_COLOR;
            }
            else
            {
                result = "Podano nieprawidłową liczbę";
                color = TOO_BIG_NUMBER_COLOR;
            }
            ViewBag.result = result;
            ViewBag.color = color;
            return View();
        }

        [Route("Draw")]
        public IActionResult Draw()
        {
            drawnNumber = new Random().Next(range);
            readyToGuess = true;
            return View();
        }

        [Route("Guess,{number}")]
        public IActionResult Guess()
        {
            int number;
            bool success = int.TryParse((string)RouteData.Values["number"], out number);

            string result;
            string color;
            if (readyToGuess)
            {
                if (success)
                {
                    if (number == drawnNumber)
                    {
                        result = $"Trafiona! Liczba {number} została odgadnięta.";
                        color = CORRECT_NUMBER_COLOR;
                        readyToGuess = false;
                    }
                    else if (number < drawnNumber)
                    {
                        result = "Podana liczba jest za mała.";
                        color = TOO_SMALL_NUMBER_COLOR;
                    }
                    else
                    {
                        result = "Podana liczba jest za duża.";
                        color = TOO_BIG_NUMBER_COLOR;
                    }
                }
                else
                {
                    result = "Podano nieprawidłową wartość.";
                    color = TOO_BIG_NUMBER_COLOR;
                }
            }
            else
            {
                result = "Nie wylosowano żadnej liczby.";
                color = TOO_BIG_NUMBER_COLOR;
            }

            ViewBag.result = result;
            ViewBag.color = color;
            return View();
        }

    }
}
