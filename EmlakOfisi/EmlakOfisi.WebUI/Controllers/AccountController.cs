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

namespace EmlakOfisi.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAgentService _agentService;
        private IMapper _mapper;
        public AccountController(IAgentService agentisementService, IMapper mapper)
        {
            _agentService = agentisementService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public IActionResult Update()
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return RedirectToAction("Index", "Login");
            }
            var agentId = Convert.ToInt32(token);
            var entity = _agentService.GetAgentById(agentId);
            var model = _mapper.Map<AgentModel>(entity);

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(AgentModel model)
        {

            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Güncelleme başarısız";
                return View(model);
            }

            var entitiy = _mapper.Map<Agent>(model);
            var result = _agentService.UpdateAgent(entitiy);
            return RedirectToAction("Index", "Home");
        }
    }
}