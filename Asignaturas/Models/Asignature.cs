using Asignatura.Models;
using Asignaturas.Enums;

namespace Asignaturas.Models
{
    public class Asignature
    {
        //[Key]
        public Guid AsignatureId { get; set; }
        //[ForeignKey("UserId")]
        //public Guid UserId { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string NameAsignature { get; set; }

        public AreaTypes AreaTypes { get; set; }

        public DateTime CreationDate { get; set; }

        //public virtual User User { get; set; }
        //public ICollection<AsignatureUser> AsignatureUsers { get; set; }
        //[NotMapped]
        public string Detail { get; set; }

    }
}
