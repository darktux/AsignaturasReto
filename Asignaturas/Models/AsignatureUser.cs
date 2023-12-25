using Asignaturas.Models;

namespace Asignatura.Models
{
    public class AsignatureUser
    {
        public Guid AsignatureUserId { get; set; }

        public Guid UserId { get; set; }
        //public User User { get; set; }

        public Guid AsignatureId { get; set; }
        //public Asignature Asignature { get; set; }
    }
}
