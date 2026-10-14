using Fast.Route.Logic;
using Fast.Route.Models;
using Fast.Route.Models.Common;
using Fast.Route.Models.Program;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Fast.Route.UserInterface.Controllers
{
    public class ProgramController : Controller
    {
        private readonly RouteLogic _routeLogic;
        private readonly ProgramLogic _programLogic;
        public ProgramController(IOptions<AppSettings> appSettings)
        {
            _routeLogic = new RouteLogic(appSettings.Value);
            _programLogic = new ProgramLogic(appSettings.Value);    
        }

        [HttpGet("/Program/{programId}")]
        public async Task<ActionResult> GetById(string programId)
        {
            return Json(await _programLogic.GetById(new ParameterModel() { Description = programId }));
        }

        [HttpPost("/Program")]
        public async Task<ActionResult> AddUpdProgram([FromBody] ProgramModel program)
        {
            if(program.Op == 1)
                return Json(await _programLogic.Add(program));
            return Json(await _programLogic.Update(program));
        }

        [HttpPost]
        public async Task<ActionResult> Preview([FromBody] ParameterModel parameter)
        {
            return Json(await _routeLogic.GetRoute(parameter));
        }
        
        [HttpPost]
        public async Task<ActionResult> Run([FromBody] ParameterModel parameter)
        {
            return Json(await _routeLogic.Run(parameter));
        }
    }
}
