using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmlakOfisi.WebUI.Models;
using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Business.Concrete;
using Microsoft.AspNetCore.Http;

namespace EmlakOfisi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAgentService _agentService;
        private IAdvertisementService _advertisementService;
        public HomeController(IAgentService agentService, IAdvertisementService advertisementService)
        {
            _agentService = agentService;
            _advertisementService = advertisementService;
        }

        public IActionResult Index(int roomCount,string search, int age)
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return RedirectToAction("Index", "Login");
            }
            var agentId = Convert.ToInt32(token);
            var advertisements = _agentService.GetAdvertisementsList(x => x.AgentId == agentId);

            var advertisementsList = advertisements.Select(x => new AdvertisementModel() {Id=x.Id, AgeOfHouse = x.AgeOfHouse, NumberOfRoom = x.NumberOfRoom, SquareMeter = x.SquareMeter, Title = x.Title }).ToList();

            if (roomCount!=0)
            {
                advertisementsList = advertisementsList.Where(x => x.NumberOfRoom == roomCount).ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                advertisementsList = advertisementsList.Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            if (age != 0)
            {
                advertisementsList = advertisementsList.Where(x => x.AgeOfHouse == age).ToList();
            }


            ViewData["CompanyName"] = _agentService.GetAgentById(agentId).CompanyName;
            ViewData["UserName"] = _agentService.GetAgentById(agentId).Username;
            return View(advertisementsList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
