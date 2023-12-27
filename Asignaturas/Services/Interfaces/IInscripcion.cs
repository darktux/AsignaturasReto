﻿
namespace Asignatura.Services.Interfaces
{
    public interface IInscripcion
    {
        bool ConsultarAsignaturaExistente(Guid asignatureId);
        bool ConsultaUsuarioExistente(Guid userId);
        bool InscribirUsuario(Models.AsignatureUser asignatureUser);
    }
}
