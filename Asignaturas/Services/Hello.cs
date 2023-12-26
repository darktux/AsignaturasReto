using Asignaturas.Services.Interfaces;

namespace Asignaturas.Services
{
    public class Hello:IHello
    {
        public string Get()
        {
            return $"Hello " + DateTime.Now.ToString();
        }
    }
}
