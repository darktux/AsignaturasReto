using Asignaturas.Models;

namespace Asignaturas.Services.Interfaces
{
    public interface IAsignature
    {
        bool CreateAsignatureUser(AsignatureUser asignatureUser);
        List<AsignatureUser> GetAsignatureUsers();
        AsignatureUser GetAsignatureUserById(Guid id);
        bool UpdateAsignatureUser(Guid id, AsignatureUser updatedAsignatureUser);
        bool DeleteAsignatureUser(Guid id);
    }
}
