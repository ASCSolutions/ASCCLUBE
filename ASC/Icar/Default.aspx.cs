using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASC.Clube.Control.DAO;
using ASC.Clube.Model;

namespace Icar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Localidade localidade = new Localidade() { Id = 1};

            LocalidadeDAO localidadeDAO = new LocalidadeDAO();
            List<Localidade> listaLocalidade = localidadeDAO.ListarTodos();
            Localidade localidade2 = localidadeDAO.ProcurarPorId(1);

            LocalidadeDAO localidadeDAO2 = new LocalidadeDAO(false);
            List<Localidade> listaLocalidade2 = localidadeDAO2.ListarTodos();
            Localidade localidade22 = localidadeDAO2.ProcurarPorId(1);

            List<Localidade> localidades = localidadeDAO.ListarPorWhere();

            try
            {
                localidadeDAO.Deletar(localidade);
            }
            catch (Exception)
            {
                
            }
        }
    }
}