using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;

using ASC.Util.Data.Conexao;
using ASC.Util.Data.Interfaces;
using ASC.Clube.Model;

namespace ASC.Clube.Control.DAO
{
    public class AssociadoDAO : IDAONegocio<Associado>
    {
        #region Atributos

        private ConexaoASC conexao;


        private const String nomeTabela = "associados";

        #endregion

        #region Construtores

        public AssociadoDAO()
        {
            this.conexao = new ConexaoASC();
        }

        #endregion

        #region Metodos

        public Associado ProcurarPorId(int id)
        {
            if (this.Conexao.AbrirConexao())
            {
                OdbcCommand comando = new OdbcCommand("SELECT * FROM " + nomeTabela + " WHERE IDASSOCIADO = ?", this.Conexao.Conn);
                
                comando.Parameters.AddWithValue("@idassociado", id);
                
                OdbcDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    return MontarObjeto(leitor);
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        public List<Associado> ListarTodos()
        {
            if (this.Conexao.AbrirConexao())
            {
                List<Associado> listaAssociado = new List<Associado>();

                OdbcCommand comando = new OdbcCommand("SELECT * FROM " + nomeTabela, this.Conexao.Conn);
                
                OdbcDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    listaAssociado.Add(MontarObjeto(leitor));
                }

                if (listaAssociado.Count != 0)
                    return listaAssociado;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public bool Deletar(Associado obj)
        {
            int numLinhasAfetadas = 0;

            OdbcCommand comando = new OdbcCommand("DELETE FROM " + nomeTabela + " WHERE ID = ?", this.Conexao.Conn);

            comando.Parameters.AddWithValue("@idassociado", obj.Id);

            numLinhasAfetadas = comando.ExecuteNonQuery();

            if (numLinhasAfetadas > 0)
                return true;
            else
                return false;
        }

        public bool Inserir(Associado obj)
        {
            int numLinhasAfetadas = 0;

            OdbcCommand comando = new OdbcCommand("INSERT INTO " + nomeTabela + " (column1,column2,column3,...) VALUES ();", this.Conexao.Conn);

            comando.Parameters.AddWithValue("@idassociado", obj.Id);

            numLinhasAfetadas = comando.ExecuteNonQuery();

            if (numLinhasAfetadas > 0)
                return true;
            else
                return false;
        }

        public bool Atualizar(Associado obj)
        {
            throw new NotImplementedException();
        }

        public Associado MontarObjeto(OdbcDataReader leitor)
        {
            Associado associado = new Associado();

            associado.Id = leitor.GetInt32(0);
            associado.Matricula = leitor.GetString(1);
            associado.Titulo = leitor.GetString(2);
            associado.Cpf = leitor.GetString(3);
            associado.Rg = leitor.GetString(4);

            return associado;
        }

        #endregion

        #region Getters&Setters

        public ConexaoASC Conexao
        {
            get { return conexao; }
            set { conexao = value; }
        }

        #endregion


        public Associado MontarObjeto()
        {
            throw new NotImplementedException();
        }


        public List<Associado> ListarPorWhere(string where)
        {
            throw new NotImplementedException();
        }
    }
}
