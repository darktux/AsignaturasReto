using Asignaturas.Controllers;
using Asignaturas.Models;
using Asignaturas.Services;
using Asignaturas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Asignatura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignatureController : ControllerBase
    {
        private readonly ILogger<AsignatureController> _logger;
        private readonly IAsignature _asignature;

        public AsignatureController(ILogger<AsignatureController> logger, IAsignature asignature)
        {
            _logger = logger;
            _asignature = asignature;

        }

        [HttpPost]
        [Route("CreateAsignature")]
        public IActionResult CreateAsignature(Asignaturas.Models.Asignature asignature)
        {
            return Ok(_asignature.CreateAsignature(asignature));
        }

        [HttpGet]
        [Route("GetAsignatures")]
        public IActionResult GetAsignature()
        {
                return Ok(_asignature.GetAsignature());
        }

        [HttpGet]
        [Route("GetAsignatures/{id}")]
        public IActionResult GetAsignatureById(Guid id)
        {
            return Ok(_asignature.GetAsignatureById(id));
        }

        [HttpDelete]
        [Route("DeleteAsignature/{id}")]
        public IActionResult DeleteAsignature(Guid id)
        {
            try
            {
                if (_asignature.DeleteAsignature(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("La asignatura no existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("La asignatura no existe");
            }
        }

        [HttpPut]
        [Route("UpdateAsignature/{id}")]
        public IActionResult UpdateAsignature(Guid id, Asignaturas.Models.Asignature asignature)
        {
            if (asignature == null)
            {
                return BadRequest("Debe ingresar los datos a modificar");
            }
            if (_asignature.UpdateAsignature(id, asignature))
            {
                return Ok();
            }
            else
            {
                return BadRequest("La asignatura no existe o no se pudo actualizar");
            }
        }
    }
}
