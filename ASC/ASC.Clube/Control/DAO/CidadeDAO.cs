using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASC.Util.Data.Interfaces;
using ASC.Util.Data.Conexao;
using System.Data.Odbc;
using ASC.Clube.Model;

namespace ASC.Clube.Control.DAO
{
    public class CidadeDAO : IDAO<Cidade>
    {
        #region Atributos

        private ConexaoASC conexao;
        private const String nomeTabela = "cidades";

        #endregion

        #region Construtores

        public CidadeDAO()
        {
            this.Conexao = new ConexaoASC();
        }

        #endregion

        #region Metodos

        public Cidade ProcurarPorId(int id)
        {
            string querySql = "SELECT c.ID, c.CIDADE, e.ID, e.ESTADO FROM " + nomeTabela + " AS c INNER JOIN estados AS e ON e.ID = c.ID_ESTADO WHERE c.ID = ?";

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            comando.Parameters.AddWithValue("@id", id);

            OdbcDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                return MontarObjeto(leitor);
            }

            return null;
        }

        public List<Cidade> ListarTodos()
        {
            string querySql = "SELECT c.ID, c.CIDADE, e.ID, e.ESTADO FROM " + nomeTabela + " AS c INNER JOIN estados AS e ON e.ID = c.ID_ESTADO";

            List<Cidade> listaCidade = new List<Cidade>();

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            OdbcDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                listaCidade.Add(MontarObjeto(leitor));
            }

            if (listaCidade.Count != 0)
                return listaCidade;
            else
                return null;
        }

        public List<Cidade> ListarPorWhere(string where)
        {
            string querySql = "SELECT c.ID, c.CIDADE, e.ID, e.ESTADO FROM " + nomeTabela + " AS c INNER JOIN estados AS e ON e.ID = c.ID_ESTADO WHERE" + where;

            List<Cidade> listaCidade = new List<Cidade>();

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            OdbcDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                listaCidade.Add(MontarObjeto(leitor));
            }

            if (listaCidade.Count != 0)
                return listaCidade;
            else
                return null;
        }

        private Cidade MontarObjeto(OdbcDataReader leitor)
        {
            Cidade cidade = new Cidade();

            cidade.Id = (!leitor.IsDBNull(0)) ? leitor.GetInt32(0) : 0;
            cidade.Nome = (!leitor.IsDBNull(1)) ? leitor.GetString(1) : null;
            cidade.Estado = new Estado();
            cidade.Estado.Id = (!leitor.IsDBNull(2)) ? leitor.GetInt32(2) : 0;
            cidade.Estado.Nome = (!leitor.IsDBNull(3)) ? leitor.GetString(3) : null;

            return cidade;
        }

        public Cidade MontarObjeto()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Getters&Setters

        public ConexaoASC Conexao
        {
            get { return conexao; }
            set { conexao = value; }
        }

        #endregion
    }
}
