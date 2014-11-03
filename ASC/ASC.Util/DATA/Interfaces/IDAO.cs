using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Util.Data.Interfaces
{
    public interface IDAO<T>
    {
        T ProcurarPorId(int id);
        List<T> ListarTodos();
        List<T> ListarPorWhere(string where);

    }
}
