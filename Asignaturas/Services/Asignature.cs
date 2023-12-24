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

        public List<AsignatureUser> GetAsignatureUsers()
        {
            return _dbContext.AsignatureUsers.ToList();
        }

        public AsignatureUser GetAsignatureUserById(Guid id)
        {
            return _dbContext.AsignatureUsers.Find(id);
        }

        public bool CreateAsignatureUser(AsignatureUser asignatureUser)
        {
            bool result = false;
            try
            {
                asignatureUser.AsignatureUserId = Guid.NewGuid();
                asignatureUser.CreationDate = DateTime.Now;
                _dbContext.AsignatureUsers.Add(asignatureUser);
                _dbContext.SaveChanges();
                result = true;
            }catch (Exception ex) {
                _logger.LogError($"error obteniendo data de asignatura {ex.Message.ToString()}");
            }
            return result;
        }

        public bool DeleteAsignatureUser(Guid id)
        {
            bool result = false;
            try { 
                AsignatureUser asignatureUser = _dbContext.AsignatureUsers.Find(id);
                if (asignatureUser != null)
                {
                    _dbContext.AsignatureUsers.Remove(asignatureUser);
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

        public bool UpdateAsignatureUser(Guid id, AsignatureUser nasignatureUser)
        {
            bool result = false;
            try
            {
                Models.AsignatureUser asignatureUser = _dbContext.AsignatureUsers.Find(id);
                if (asignatureUser != null)
                {
                    asignatureUser.NameAsignature = nasignatureUser.NameAsignature;
                    asignatureUser.AreaTypes = nasignatureUser.AreaTypes;
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
