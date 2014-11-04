using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace ASC.Util.Data.Interfaces
{
    public interface IDAO<T>
    {
        T ProcurarPorId(int id);
        List<T> ListarTodos();
        List<T> ListarPorWhere(string where);
        //T MontarObjetoCompleto(OdbcDataReader leitor);
        //T MontarObjetoParcial(OdbcDataReader leitor);
        List<T> MontarObjetosCompleto(OdbcDataReader leitor);
        List<T> MontarObjetosParcial(OdbcDataReader leitor);
        List<T> FabricarObjetos(OdbcDataReader leitor);
    }
}
