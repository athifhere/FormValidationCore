using Microsoft.AspNetCore.Mvc;
using FormValidationCore.Models;

namespace FormValidationCore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            UserModel model = new UserModel();
            model.CountriesList = new List<string>() { "India", "USA", "UK" };
            TempData["CountriesList"] = model.CountriesList;
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            model.CountriesList = new List<string>();
            foreach (var item in (IEnumerable<string>)TempData["CountriesList"])
            {
                model.CountriesList.Add(item);
            }
            TempData["Username"] = model.UserName;
            if (ModelState.IsValid)
            {
                return RedirectToAction("Message");
            }
            return View(model);
        }

        public IActionResult Message()
        {
            ViewBag.Username = (string)TempData["Username"];
            return View();
        }

        public List<string> GetCityListByCountry(string countryName)
        {
            List<string> CityList = new List<string>() { "New Delhi", "Chennai", "Hyderabad", "Mumbai", "Kolkata",
            "New York", "Los Angeles", "Boston", "Houston", "Washington",
            "London", "Manchester", "Liverpool", "Birmingham", "Edinburgh"};
            List<string> data = new List<string>();

            if (countryName == "India")
            {
                data = CityList.GetRange(0, 5);
                data.Sort();
            }
            else if (countryName == "USA")
            {
                data = CityList.GetRange(5, 5);
                data.Sort();
            }
            else if (countryName == "UK")
            {
                data = CityList.GetRange(10, 5);
                data.Sort();
            }
            return data;
        }
    }
}
