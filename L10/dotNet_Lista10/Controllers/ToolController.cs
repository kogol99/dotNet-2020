using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_Lista10.Controllers
{
    public class ToolController : Controller
    {
        private const string ERROR_COLOR = "color:#F24F13";
        private const string IS_RESULT_COLOR = "color:#A0D9A9";
        private const string NO_RESULT_COLOR = "color:#F24F13";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            Int32.TryParse((string)RouteData.Values["param1"], out int a);
            Int32.TryParse((string)RouteData.Values["param2"], out int b);
            Int32.TryParse((string)RouteData.Values["param3"], out int c);
            ViewBag.results = new List<string>();

            List<string> results = new List<string>();
            string color;

            if (a == 0 & b == 0 & c == 0)
            {
                results.Add("Rownanie tozsamosciowe");
                color = ERROR_COLOR;
            }
            else if (a == 0 & b == 0)
            {
                results.Add("Rownanie sprzeczne");
                color = ERROR_COLOR;
            }
            else if (a == 0)
            {
                results.Add("Nie jest to funkcja kwadratowa");
                color = ERROR_COLOR;
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta == 0)
                {
                    results.Add($"Wartość x wynosi: {((-b) / (2 * a)):N5}");
                    color = IS_RESULT_COLOR;
                }
                else if (delta > 0)
                {
                    results.Add($"Wartość x wynosi: {(-b - Math.Sqrt(delta)) / (2 * a):N5}");
                    results.Add($"Wartość x wynosi: {(-b + Math.Sqrt(delta)) / (2 * a):N5}");
                    color = IS_RESULT_COLOR;
                }
                else
                {
                    results.Add("Brak miejsc zerowych dla podanej funkcji");
                    color = NO_RESULT_COLOR;
                }
            }

            ViewData["resultsList"] = results;
            ViewData["color"] = color;

            return View();
        }
    }
}
