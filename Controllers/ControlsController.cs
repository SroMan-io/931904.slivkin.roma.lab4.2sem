using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ControlsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Text"] = "";
            return View();
        }

        [HttpGet]
        public IActionResult TextBox()
        {
            ViewData["Method"] = "Get";
            return View();
        }

        [HttpPost]
        public IActionResult TextBox(string text)
        {
            ViewData["Method"] = "Post";
            
            ViewData["Text"] = text;

            return View();
        }

        [HttpGet]
        public IActionResult TextArea()
        {
            ViewData["Method"] = "Get";
            return View();
        }
        [HttpPost]
        public IActionResult TextArea(string text)
        {
            ViewData["Method"] = "Post";
            ViewData["Text"] = text;

            return View();
        }

        [HttpGet]
        public IActionResult CheckBox()
        {
            ViewData["Method"] = "Get";
            return View();
        }
        [HttpPost]
        public IActionResult CheckBox(string Enable)
        {
            ViewData["Method"] = "Post";
            
            if (Enable == "true") ViewData["Text"] = "True";
            else ViewData["Text"] = "False";
            return View();
        }

        [HttpGet]
        public IActionResult Radio()
        {
            ViewData["Method"] = "Get";
            return View();
        }

        [HttpPost]
        public IActionResult Radio(string month)
        {
            ViewData["Method"] = "Post";
            ViewData["Text"] = month;

            return View();
        }

        [HttpGet]
        public IActionResult DropDownList()
        {
            ViewData["Method"] = "Get";
            return View();
        }
        [HttpPost]
        public IActionResult DropDownList(string month)
        {
            ViewData["Method"] = "Post";
            ViewData["Text"] = month;
            return View();
        }

        [HttpGet]
        public IActionResult ListBox()
        {
            ViewData["Method"] = "Get";
            return View();
        }
        [HttpPost]
        public IActionResult ListBox(string month)
        {
            ViewData["Method"] = "Post";
            ViewData["Text"] = month;
            return View();
        }
    }
}
