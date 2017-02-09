using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace randomPw.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("visited") == null){
                HttpContext.Session.SetInt32("visited", 1);
            }
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[14];

            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            System.Console.WriteLine(HttpContext.Session.GetInt32("visited"));
            ViewBag.numVisited = HttpContext.Session.GetInt32("visited");
            ViewBag.password = finalString;
            return View();
        }

        [HttpPost]
        [Route("generate")]
        public IActionResult Generate()
        {
            int Num = (int)HttpContext.Session.GetInt32("visited");
            Num += 1;
            HttpContext.Session.SetInt32("visited", Num);
            return RedirectToAction("Index");
        }
    }
}
