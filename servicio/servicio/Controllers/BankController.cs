using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDSWI.Models;
using servicio.Data;
using servicio.Models.ModelsDTO;

namespace servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly MyAppContext myAppContext;

        public BankController(MyAppContext myAppContext)
        {
            this.myAppContext = myAppContext;
        }

        [HttpGet]
        public IActionResult GetAllBanks() 
        {
            var allBanks = myAppContext.Banks.ToList();
            return Ok(allBanks);
        }

        [HttpPost]
        public IActionResult AddBank(BankDTO bankDTO)
        {
            using (var transaction = myAppContext.Database.BeginTransaction())
            {
                try
                {
                    var bank = new Bank()
                    {
                        BankName = bankDTO.BankName
                    };

                    myAppContext.Banks.Add(bank);
                    myAppContext.SaveChanges();

                    transaction.Commit();

                    return Ok(bank);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Ocurrió un error: {ex.Message}");
                }
            }
        }
    }
}
