using Asignatura.Controllers;
using Asignatura.Models;
using Asignatura.Services.Interfaces;
using Asignaturas;
using Asignaturas.Models;
using Microsoft.EntityFrameworkCore;

namespace Asignatura.Services
{
    public class Inscripcion : IInscripcion
    {
        private readonly ILogger<Inscripcion> _logger;
        private readonly AsignaturesContext _dbContext;
        //private readonly Asignature Asignaturas;
        public Inscripcion(ILogger<Inscripcion> logger, AsignaturesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public bool ConsultarAsignaturaExistente(Guid asignatureId)
        {
            return _dbContext.Asignature.Any(a => a.AsignatureId == asignatureId);
        }

        public bool ConsultaUsuarioExistente(Guid userId)
        {
            return _dbContext.Users.Any(u => u.UserId == userId);
        }

        public bool InscribirUsuario(Models.AsignatureUser asignatureUser)
        {
            bool result = false;
            try
            {
                asignatureUser.AsignatureUserId = Guid.NewGuid();
                _dbContext.Add(asignatureUser);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data {ex.Message.ToString()}");
            }
            return result;
        }

        public List<User> ObtenerUsuariosInscritosEnAsignatura(Guid asignaturaId)
        {
            var usuariosInscritos = _dbContext.AsignatureUser
                .Where(au => au.AsignatureId == asignaturaId)
                .Join(
                    _dbContext.Users,
                    au => au.UserId,
                    u => u.UserId,
                    (au, u) => u
                )
                .ToList();

            return usuariosInscritos;
        }
    }
}
