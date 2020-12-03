using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Entities;
using EmlakOfisi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Entities;
using EmlakOfisi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmlakOfisi.WebUI.Areas.Admin.Controllers
{
    public class CreateAgentController : Controller
    {
        private IAgentService _agentService;
        private IMapper _mapper;

        public CreateAgentController(IAgentService agentisementService, IMapper mapper)
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
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult Index(AgentModel model)
        {
          
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var entitiy = _mapper.Map<Agent>(model);

            var result = _agentService.CreateAgent(entitiy);

            return RedirectToAction("Index", "Home");
        }
    }
}