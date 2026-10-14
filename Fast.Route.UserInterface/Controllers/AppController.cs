using Fast.Route.Logic;
using Fast.Route.Models;
using Fast.Route.Models.Common;
using Fast.Route.Models.Program;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Fast.Route.UserInterface.Controllers
{
    public class AppController : Controller
    {
        private readonly AppLogic _appLogic;
        public AppController(IOptions<AppSettings> options)
        {
            _appLogic = new AppLogic(options.Value);
        }
        // GET: AppController
        public ActionResult Main()
        {
            ViewData["Title"] = "Inicio";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProgram([FromBody] ProgramModel program)
        {
            var inputs = await _appLogic.ProgramInputs(program);

            return PartialView("../App/Form/_FormFields.cshtml", inputs);
        }

        [HttpPost]
        public async Task<ActionResult> EditProgram([FromBody] ProgramModel program)
        {
            var inputs = await _appLogic.ProgramInputs(program);

            return PartialView("../App/Form/_FormFields", inputs);
        }
        
        [HttpPost]
        public async Task<ActionResult> ManagePrograms([FromBody] ParameterModel parameter)
        {
            var body = await _appLogic.ManageProgramBody(parameter);

            return PartialView("../App/Modal/Body/_Programs", body);
        }

    }
}
