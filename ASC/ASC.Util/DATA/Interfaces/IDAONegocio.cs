using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Util.Data.Interfaces
{
    public interface IDAONegocio<T> : IDAO<T>
    {
        bool Deletar(T obj);

        bool Inserir(T obj);

        bool Atualizar(T obj);
    }
}
