using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EmlakOfisi.WebUI.Models;
using EmlakOfisi.Business.Abstract;

namespace EmlakOfisi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IAgentService _agentService;
        public LoginController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AgentModel agent)
        {
            var retAgent = _agentService.GetAgents().Where(x => x.Username == agent.Username && x.Password == agent.Password).FirstOrDefault();
            if (retAgent != null)
            {
                HttpContext.Session.SetString("agentId", (retAgent.Id).ToString());
                if (retAgent.IsAdmin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }



            }

            ViewData["Hata"] = "Lütfen giriş bilgilerinizi kontrol ediniz.";
            return View();
        }

        public IActionResult Exit()
        {
            HttpContext.Session.SetString("agentId", "");
            return RedirectToAction("Index", "Login");
        }
    }
}