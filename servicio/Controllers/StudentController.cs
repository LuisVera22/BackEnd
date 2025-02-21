using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using servicio.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProyectoDSWI.Models;
using servicio.Models.ModelsDTO;

namespace servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyAppContext myAppContext;

        public StudentController (MyAppContext myAppContext)
        {
            this.myAppContext = myAppContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStudents()
        {
            var allStudents = await myAppContext.Students
                                                .Include(s => s.LegalGuardian)
                                                .ToListAsync();


            if (allStudents == null || !allStudents.Any())
            {
                return NotFound("No se encontraron estudiantes.");
            }

            return Ok(allStudents);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = await myAppContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingStudent = await myAppContext.Students
                                                         .Where(s => s.Code == request.Code)
                                                         .FirstOrDefaultAsync();
                    if (existingStudent != null)
                    {
                        return BadRequest("El código del estudiante ya existe.");
                    }

                    LegalGuardian legalGuardian = null;
                    if (request.LegalGuardian != null)
                    {
                        legalGuardian = await myAppContext.LegalGuardians
                                                          .Where(g => g.IdentityDocument == request.LegalGuardian.IdentityDocument)
                                                          .FirstOrDefaultAsync();

                        if (legalGuardian == null)
                        {
                            legalGuardian = new LegalGuardian
                            {
                                IdentityDocument = request.LegalGuardian.IdentityDocument,
                                Name = request.LegalGuardian.Name,
                                LastName = request.LegalGuardian.LastName,
                                Gender = request.LegalGuardian.Gender,
                                Birthdate = request.LegalGuardian.Birthdate,
                                CellphoneNumber = request.LegalGuardian.CellphoneNumber,
                                Email = request.LegalGuardian.Email,
                                Direction = request.LegalGuardian.Direction
                            };

                            myAppContext.LegalGuardians.Add(legalGuardian);
                            await myAppContext.SaveChangesAsync();
                        }
                    }

                    var student = new Student
                    {
                        Code = request.Code,
                        Name = request.Name,
                        LastName = request.LastName,
                        Direction = request.Direction,
                        Gender = request.Gender,
                        Birthdate = request.Birthdate,
                        LegalGuardianId = legalGuardian?.Id
                    };

                    myAppContext.Students.Add(student);
                    await myAppContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return CreatedAtAction(nameof(RegisterStudent), new { id = student.Id }, student);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    await transaction.RollbackAsync();
                    return StatusCode(500, "Error al registrar el estudiante o apoderado: " + ex.Message);
                }
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditStudent(int id, [FromBody] StudentDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await myAppContext.Students.Include(s => s.LegalGuardian).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Estudiante no encontrado.");
            }

            var existingStudent = await myAppContext.Students
                                                 .Where(s => s.Code == request.Code && s.Id != id)
                                                 .FirstOrDefaultAsync();
            if (existingStudent != null)
            {
                return BadRequest("El código del estudiante ya existe.");
            }

            // Buscar al apoderado en la base de datos
            var legalGuardian = await myAppContext.LegalGuardians
                                              .FirstOrDefaultAsync(g => g.Id == student.LegalGuardianId);
            if (legalGuardian == null)
            {
                return NotFound("Apoderado no encontrado.");
            }

            // Verificar si el DNI del apoderado está siendo modificado y ya existe en la base de datos
            var existingLegalGuardian = await myAppContext.LegalGuardians
                                                      .Where(g => g.IdentityDocument == request.LegalGuardian.IdentityDocument && g.Id != legalGuardian.Id)
                                                      .FirstOrDefaultAsync();
            if (existingLegalGuardian != null)
            {
                return BadRequest("El DNI del apoderado ya está registrado.");
            }

            // Actualizar el estudiante
            student.Code = request.Code;
            student.Name = request.Name;
            student.LastName = request.LastName;
            student.Gender = request.Gender;
            student.Direction = request.Direction;
            student.Birthdate = request.Birthdate;

            // Si se ha modificado el apoderado, actualizamos sus datos
            legalGuardian.IdentityDocument = request.LegalGuardian.IdentityDocument;
            legalGuardian.Name = request.LegalGuardian.Name;
            legalGuardian.LastName = request.LegalGuardian.LastName;
            legalGuardian.Gender = request.LegalGuardian.Gender;
            legalGuardian.Birthdate = request.LegalGuardian.Birthdate;
            legalGuardian.CellphoneNumber = request.LegalGuardian.CellphoneNumber;
            legalGuardian.Email = request.LegalGuardian.Email;
            legalGuardian.Direction = request.LegalGuardian.Direction;

            // Guardar los cambios
            await myAppContext.SaveChangesAsync();

            return Ok(student); // Retorna el estudiante actualizado
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await myAppContext.Students.Include(s => s.LegalGuardian).FirstOrDefaultAsync(s => s.Id == id);
                if (student == null)
                {
                    return NotFound("Estudiante no encontrado.");
                }

                myAppContext.Students.Remove(student);
                await myAppContext.SaveChangesAsync();

                return Ok("Estudiante eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("AssignLegalGuardianToStudent")]
        [Authorize]
        public async Task<IActionResult> AssignLegalGuardianToStudent([FromBody] AssingLegalGuardianDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = await myAppContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var student = await myAppContext.Students
                                                     .Where(s => s.Id == request.StudentId) 
                                                     .FirstOrDefaultAsync();
                    if (student == null)
                    {
                        return NotFound("Estudiante no encontrado.");
                    }

                    var legalGuardian = await myAppContext.LegalGuardians
                                                           .Where(g => g.Id == request.LegalGuardianId)  
                                                           .FirstOrDefaultAsync();

                    if (legalGuardian == null)
                    {
                        return NotFound("Apoderado no encontrado.");
                    }

                    // Asignamos el apoderado al estudiante
                    student.LegalGuardianId = legalGuardian.Id;
                    await myAppContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok("Apoderado asignado correctamente al estudiante.");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, "Error al asignar el apoderado: " + ex.Message);
                }
            }
        }
    }
}
