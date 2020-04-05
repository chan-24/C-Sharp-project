using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Goldy.Controllers
{
    public class FirstController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Large()
        {
            return View();

        }
        public IActionResult Small()
        {
            return View();

        }
        public IActionResult Analysis()
        {
            return View();

        }
        public IActionResult Bangalore()
        {
            return View();

        }
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
   
}

