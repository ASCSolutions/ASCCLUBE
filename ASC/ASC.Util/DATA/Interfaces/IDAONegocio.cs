using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace ASC.Util.Data.Interfaces
{
    public interface IDAONegocio<T> : IDAO<T>
    {
        bool Deletar(T obj);

        bool Inserir(T obj);

        bool Atualizar(T obj);

        T MontarObjeto(OdbcDataReader leitor);
    }
}
