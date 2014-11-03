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

            CidadeDAO cidadeDAO = new CidadeDAO();
            List<Cidade> cidades = cidadeDAO.ListarTodos();
            Cidade cidade2 = cidadeDAO.ProcurarPorId(1);

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