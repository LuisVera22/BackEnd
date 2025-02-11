using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servicio.Data;

namespace servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalGuardianController : ControllerBase
    {
        private readonly MyAppContext myAppContext;

        public LegalGuardianController(MyAppContext myAppContext)
        {
            this.myAppContext = myAppContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStudents()
        {
            var allLegalGuardians = await myAppContext.LegalGuardians.ToListAsync();

            if (allLegalGuardians == null || !allLegalGuardians.Any())
            {
                return NotFound("No se encontraron apoderados.");
            }

            return Ok(allLegalGuardians);
        }
    }
}
