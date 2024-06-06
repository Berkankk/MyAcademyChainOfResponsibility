using Microsoft.AspNetCore.Mvc;
using MyAcademyChainOfResponsibility.CofR;
using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Clork _clork;
        private readonly AssistantManager _assistantManager;
        private readonly Manager _manager;
        private readonly RegionalManager _regionalManager;

        public DefaultController(Clork clork, AssistantManager assistantManager, Manager manager, RegionalManager regionalManager)
        {
            _clork = clork;
            _assistantManager = assistantManager;
            _manager = manager;
            _regionalManager = regionalManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(CustomerProcessViewModel model)
        {
            _clork.SetNextAprover(_assistantManager);
            _assistantManager.SetNextAprover(_manager);
            _manager.SetNextAprover(_regionalManager);

            _clork.Process(model);
            return NoContent();   //sweetAlert

          
        }
    }
}
