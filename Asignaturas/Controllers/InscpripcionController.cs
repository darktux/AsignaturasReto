using Asignatura.Models;
using Asignatura.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Asignatura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscpripcionController : ControllerBase
    {
        private readonly ILogger<InscpripcionController> _logger;
        private readonly IInscripcion _inscripcion;
        public InscpripcionController(ILogger<InscpripcionController> logger, IInscripcion inscripcion)
        {
            _logger = logger;
            _inscripcion = inscripcion;
        }

        [HttpPost]
        [Route("Inscripcion")]
        public IActionResult InscribirUsuario(AsignatureUser asignatureUser)
        {
            try
            {
                bool asignaturaExiste = _inscripcion.ConsultarAsignaturaExistente(asignatureUser.AsignatureId);
                bool usuarioExiste = _inscripcion.ConsultaUsuarioExistente(asignatureUser.UserId);
                if (!asignaturaExiste)
                {
                    return BadRequest("La asignatura no existe. No se pudo realizar la inscripción.");
                }else if (!usuarioExiste)
                {
                    return BadRequest("El usuario no existe. No se pudo realizar la inscripción.");
                }else
                {
                    return Ok(_inscripcion.InscribirUsuario(asignatureUser));
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
