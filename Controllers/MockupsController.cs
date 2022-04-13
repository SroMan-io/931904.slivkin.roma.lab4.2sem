using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class MockupsController : Controller
    {
        static UsersInfo Person = new UsersInfo();
        public IActionResult Index(string Action) {
            if (Action == "Verify") ViewData["Reset"] = "Instructions has been sent on your email. Check and follow it!";
            else ViewData["Reset"] = "";
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {            
            ViewData["SignUpStep"] = "1";

            var days = new List<int>();
            var years = new List<int>();

            for (int i = 1; i < 32; i++)
                days.Add(i);

            for (int i = 1900; i < 2023; i++)
                years.Add(i);
           
            ViewBag.Days = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(days);
            ViewBag.Years = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(years);
            
            return View();        
        }

        [HttpPost]
        public IActionResult SignUp(string days, string month, string years, string Gender, string FName, string LName)
        {
            ViewData["InvalidDate"] = "";

                if (ModelState.IsValid)
                {                   
                    ViewData["SignUpStep"] = "2";

                    int day = Int32.Parse(days);
                    int year = Int32.Parse(years);

                    if (day > 28 && (month == "February") && (year % 4 != 0))                   
                    {
                        days = 28.ToString();
                        ViewData["InvalidDate"] = "Incorrect date was chosen. System suppose "+ days+" "+month+" " + years +" is correct date. If it is wrong, return to the previous page and correct your birth date";
                    }
                        
                    else if (day > 29 && (month == "February") && (year % 4 == 0))
                    {
                        days = 29.ToString();
                        ViewData["InvalidDate"] = "Incorrect date was chosen. System suppose " + days + " " + month + " " + years + " is correct date. If it is wrong, return to the previous page and correct your birth date"; ;
                    }

                    if (day > 30 && ( month == "April" || month == "June" || month == "September" || month == "November" ))
                    {
                        days = 30.ToString();
                        ViewData["InvalidDate"] = "Incorrect date was chosen. System suppose " + days + " " + month + " " + years + " is correct date. If it is wrong, return to the previous page and correct your birth date"; ;
                    }


                    Person.FName = FName;
                    Person.LName = LName;
                    Person.BDay = days;
                    Person.BMonth = month;
                    Person.BYear = years;
                    Person.Gender = Gender;

                    return View();

                }
                else
                {
                    ViewData["SignUpStep"] = "1";
                    return View();
                }
            
        }
        public IActionResult SignUpCredentials(string Email, string Password, string Remember, string PasswordConfirm)
        {
            Person.EMail = Email;
            Person.Password = Password;
            Person.PasswordConfirm = PasswordConfirm;
            Person.Remembered = Remember;

            Person.ListOfUsers.Add(Person);

            return View(Person);
        }

        [HttpGet]
        public IActionResult Reset()
        {          
            ViewData["Method"] = "Get";           
            return View();
        }

        [HttpPost]
        public IActionResult Reset(string EMail)
        {           
            ViewData["Method"] = "Post";
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string EMail)
        {          
            foreach (UsersInfo person in Person.ListOfUsers)
            {              
                if (EMail == person.EMail)                    
                        return Json(false);                  
            }
            return Json(true);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmailReset(string EMailForReset)
        {            
            foreach (UsersInfo person in Person.ListOfUsers)
            {              
                if (EMailForReset == person.EMail)                    
                        return Json(true);                   
            }                    
            return Json(false);          
        }      
    }
}