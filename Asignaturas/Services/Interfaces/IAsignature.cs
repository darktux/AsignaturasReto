using Asignaturas.Models;

namespace Asignaturas.Services.Interfaces
{
    public interface IAsignature
    {
        bool CreateAsignature(Models.Asignature asignature);
        List<Models.Asignature> GetAsignature();
        Models.Asignature GetAsignatureById(Guid id);
        bool UpdateAsignature(Guid id, Models.Asignature updatedAsignature);
        bool DeleteAsignature(Guid id);
    }
}
