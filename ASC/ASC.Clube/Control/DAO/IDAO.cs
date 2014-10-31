using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public interface IDAO<T>
    {
        T ProcuraPorId(int id);
        List<T> ListaTodos();

        bool Deleta(T obj);

        bool Inseri(T obj);

        bool Atualiza(T obj);

        T MontaObjeto();
    }
}
