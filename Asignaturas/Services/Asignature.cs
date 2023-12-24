using Asignaturas.Models;
using Asignaturas.Services.Interfaces;

namespace Asignaturas.Services
{
    public class Asignature : IAsignature
    {
        private readonly ILogger<Asignature> _logger;
        private readonly AsignaturesContext _dbContext;
        public Asignature(ILogger<Asignature> logger, AsignaturesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<Models.Asignature> GetAsignature()
        {
            return _dbContext.Asignature.ToList();
        }

        public Models.Asignature GetAsignatureById(Guid id)
        {
            return _dbContext.Asignature.Find(id);
        }

        public bool CreateAsignature(Models.Asignature asignature)
        {
            bool result = false;
            try
            {
                asignature.AsignatureId = Guid.NewGuid();
                asignature.CreationDate = DateTime.Now;
                _dbContext.Asignature.Add(asignature);
                _dbContext.SaveChanges();
                result = true;
            }catch (Exception ex) {
                _logger.LogError($"error obteniendo data de asignatura {ex.Message.ToString()}");
            }
            return result;
        }

        public bool DeleteAsignature(Guid id)
        {
            bool result = false;
            try {
                Models.Asignature asignature = _dbContext.Asignature.Find(id);
                if (asignature != null)
                {
                    _dbContext.Asignature.Remove(asignature);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de asignatura {ex.Message.ToString()}");
            }
            return result;
        }

        public bool UpdateAsignature(Guid id, Models.Asignature nasignature)
        {
            bool result = false;
            try
            {
                Models.Asignature asignature = _dbContext.Asignature.Find(id);
                if (asignature != null)
                {
                    asignature.NameAsignature = nasignature.NameAsignature;
                    asignature.AreaTypes = nasignature.AreaTypes;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de asignatura {ex.Message.ToString()}");
            }
            return result;
        }
    }
}
