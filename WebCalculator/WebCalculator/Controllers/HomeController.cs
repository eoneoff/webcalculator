using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        ICalculatorRepository.ICalculatorRepository _repository;

        public HomeController(ICalculatorRepository.ICalculatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _repository.GetOperations(Request?.UserHostAddress));
        }
    }
}