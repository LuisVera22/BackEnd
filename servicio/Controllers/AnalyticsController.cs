using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servicio.Data;

namespace servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly MyAppContext myAppContext;

        public AnalyticsController(MyAppContext myAppContext)
        {
            this.myAppContext = myAppContext;
        }

        [HttpGet("genderCounts")]
        public IActionResult GetGenderCounts()
        {
            var maleStudents = myAppContext.Students.Count(s => s.Gender == "varon");
            var femaleStudents = myAppContext.Students.Count(s => s.Gender == "mujer");
            var maleGuardians = myAppContext.LegalGuardians.Count(g => g.Gender == "varon");
            var femaleGuardians = myAppContext.LegalGuardians.Count(g => g.Gender == "mujer");

            return Ok(new
            {
                MaleStudents = maleStudents,
                FemaleStudents = femaleStudents,
                MaleGuardians = maleGuardians,
                FemaleGuardians = femaleGuardians
            });
        }
    }
}
