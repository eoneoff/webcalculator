using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string ip = Request?.UserHostAddress;
            IEnumerable<string> history = await _repository.GetOperations(ip);
            return View(history);
        }

        [HttpPost]
        public async Task<JsonResult> PostRecord(string record)
        {
            string ip = Request?.UserHostAddress;
            try
            {
                await _repository.SaveOperation(ip, record);
            }
            catch(Exception e)
            {
                return Json($"{{\"Success\": \"false\", \"Error\":\"{e.Message}\"}}");
            }

            return Json("{\"Success\": \"true\"}");
        }
    }
}