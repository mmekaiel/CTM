using System.Collections.Generic;
using System.Diagnostics;

using CTM.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTM.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Constructors

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public List<string> GetResults(int num)
        {
            if (num <= 0 || num > 100) return new List<string> {"Error: Please enter a number between 1 and 100!"};

            var result = new List<string>();

            // Check for multiples of 3 and of 5. "Fizz" if multiple of 3. "Buzz" if multiple of 5. "FizzBuzz" if multiple of 3 and 5.
            for (var i = 1; i < num + 1; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    result.Add(i.ToString());

                    continue;
                }

                if (i % 3 == 0 && i % 5 == 0)
                    result.Add("FizzBuzz");
                else if (i % 3 == 0)
                    result.Add("Fizz");
                else if (i % 5 == 0) result.Add("Buzz");
            }

            return result;
        }

        #endregion
    }
}