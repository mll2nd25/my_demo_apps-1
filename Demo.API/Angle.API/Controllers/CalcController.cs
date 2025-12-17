using Angle.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Angle.API.Services.Interfaces;

namespace Angle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        readonly ICalcService _srv;

        public CalcController(ICalcService srv)
        {
            _srv = srv;
        }

        [HttpPost("[Action]")]
        public ActionResult<AngleModel> CalculateTimeAngle(TimeModel arg)
        {
            if (arg == null)
                return BadRequest("The angle could not be determined");
            return Ok(_srv.CalculateAngle(arg));
        }
    }
}
