using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Entities;
using EmlakOfisi.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakOfisi.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IAgentService _agentService;
        private IMapper _mapper;
        public HomeController(IAgentService agentisementService, IMapper mapper)
        {
            _agentService = agentisementService;
            _mapper = mapper;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return Redirect("/Login/Index");
            }
            var agents = _agentService.GetAgents().Where(x => !x.IsAdmin).ToList();
            var agentsList = agents.Select(x => new AgentModel() { Id = x.Id, CompanyName = x.CompanyName, Username = x.Username }).ToList();
            return View(agentsList);
        }
        [Area("Admin")]
        public IActionResult Delete(int id)
        {
            _agentService.DeleteAgent(id);
            return RedirectToAction("Index", "Home");
        }

    }
}