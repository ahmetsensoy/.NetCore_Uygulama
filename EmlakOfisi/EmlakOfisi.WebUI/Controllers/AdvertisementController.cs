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
    public class AdvertisementController : Controller
    {
        private IAdvertisementService _advertisementService;
        private IMapper _mapper;
        public AdvertisementController(IAdvertisementService advertisementService, IMapper mapper)
        {
            _advertisementService = advertisementService;
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

        public IActionResult Update(int id)
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return RedirectToAction("Index", "Login");
            }
            var entity = _advertisementService.GetAdvertisementByExpression(x => x.Id == id);
            var model = _mapper.Map<AdvertisementModel>(entity);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AdvertisementModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Güncelleme başarısız";
                return View(model);
            }

            var entitiy = _mapper.Map<Advertisement>(model);
            var result = _advertisementService.UpdateAdvertisement(entitiy);
            return RedirectToAction("Index", "Home");
        }

     
        public IActionResult Delete(int id)
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return RedirectToAction("Index", "Login");
            }
            _advertisementService.DeleteAdvertisement(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            var token = HttpContext.Session.GetString("agentId");
            if (string.IsNullOrEmpty(token))
            {

                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdvertisementModel model)
        {
            var token = HttpContext.Session.GetString("agentId");

            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Kayıt başarısız";
                return View();
            }

            var agentId = Convert.ToInt32(token);
            var entitiy = _mapper.Map<Advertisement>(model);
            entitiy.AgentId = agentId;
            var result = _advertisementService.CreateAdvertisement(entitiy);

            return RedirectToAction("Index", "Home");
        }

    }
}