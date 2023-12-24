using Asignatura.Controllers;
using Asignatura.Services.Interfaces;
using Asignaturas;
using Microsoft.EntityFrameworkCore;

namespace Asignatura.Services
{
    public class Inscripcion : IInscripcion
    {
        private readonly ILogger<Inscripcion> _logger;
        private readonly AsignaturesContext _dbContext;
        public Inscripcion(ILogger<Inscripcion> logger, AsignaturesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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
    }
}
