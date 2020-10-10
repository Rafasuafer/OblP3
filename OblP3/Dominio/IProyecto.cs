using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IProyecto<T> where T: class
    {
        bool Add(T unT);

        bool Remove(T unT);

        bool Update(T unT);

        T GetTbyId(object clave);

        IEnumerable<T> FindAll();
    }
}
