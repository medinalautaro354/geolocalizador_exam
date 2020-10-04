using Microsoft.AspNetCore.Mvc;

namespace AdreaniExam.Controllers
{
    public class HealthCheckController : ControllerBase
    {

        [HttpGet("health-check")]
        public ActionResult HealthCheck()
        {
            return Ok();
        }
    }
}