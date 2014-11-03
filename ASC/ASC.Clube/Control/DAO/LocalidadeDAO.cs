﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASC.Util.Data.Interfaces;
using ASC.Util.Data.Conexao;
using System.Data.Odbc;
using ASC.Clube.Model;

namespace ASC.Clube.Control.DAO
{
    public class LocalidadeDAO : IDAONegocio<Localidade>
    {
        #region Atributos

        private ConexaoASC conexao;
        private const String nomeTabela = "localidades";

        #endregion

        #region Construtores

        public LocalidadeDAO()
        {
            this.Conexao = new ConexaoASC();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Deleta um registro da tabela de localidades
        /// </summary>
        public bool Deletar(Localidade obj)
        {
            string querySql = "DELETE FROM " + nomeTabela + " WHERE ID = ?";

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //Parametros que serão substituidos na Query
            comando.Parameters.AddWithValue("@id", obj.Id);

            //executa o comando e retorna quantas linha foram afetadas
            int numLinhasAfetadas = comando.ExecuteNonQuery();

            //retorna true se alguma linha foi afetada
            return VerificarAlteracao(numLinhasAfetadas);
        }

        /// <summary>
        /// Inseri um registro da tabela de localidades
        /// </summary>
        public bool Inserir(Localidade obj)
        {
            string querySql = "INSERT INTO " + nomeTabela + " ('ID_CIDADE', 'BAIRRO', 'ENDERECO', 'CEP') VALUES ('?', '?', '?', '?')";

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //Parametros que serão substituidos na Query
            comando.Parameters.AddWithValue("@ID_CIDADE", obj.Cidade.Id);
            comando.Parameters.AddWithValue("@ID_BAIRRO", obj.Bairro);
            comando.Parameters.AddWithValue("@ID_ENDERECO", obj.Endereco);
            comando.Parameters.AddWithValue("@ID_CEP", obj.Cep);

            //executa o comando e retorna quantas linha foram afetadas
            int numLinhasAfetadas = comando.ExecuteNonQuery();

            //retorna true se alguma linha foi afetada
            return VerificarAlteracao(numLinhasAfetadas);
        }

        /// <summary>
        /// Atualiza um registro da tabela de localidades
        /// </summary>
        public bool Atualizar(Localidade obj)
        {
            string querySql = "UPDATE " + nomeTabela + " ID_CIDADE='?', BAIRRO='?', ENDERECO='?', CEP='?' WHERE ID=?";

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //Parametros que serão substituidos na Query
            comando.Parameters.AddWithValue("@ID_CIDADE", obj.Cidade.Id);
            comando.Parameters.AddWithValue("@ID_BAIRRO", obj.Bairro);
            comando.Parameters.AddWithValue("@ID_ENDERECO", obj.Endereco);
            comando.Parameters.AddWithValue("@ID_CEP", obj.Cep);
            comando.Parameters.AddWithValue("@ID", obj.Id);

            //executa o comando e retorna quantas linha foram afetadas
            int numLinhasAfetadas = comando.ExecuteNonQuery();

            //retorna true se alguma linha foi afetada
            return VerificarAlteracao(numLinhasAfetadas);
        }

        /// <summary>
        /// Procura por um registro de localidade na tabela localidades
        /// </summary>
        public Localidade ProcurarPorId(int id)
        {
            string querySql = "SELECT l.ID, c.ID AS ID_CIDADE, c.CIDADE, e.ID AS ID_ESTADO, e.ESTADO, l.BAIRRO, l.ENDERECO, l.CEP FROM " + nomeTabela + " AS l INNER JOIN cidades AS c ON l.ID_CIDADE = c.ID INNER JOIN estados AS e ON c.ID_ESTADO = e.ID WHERE l.ID = ?";

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //Parametros que serão substituidos na Query
            comando.Parameters.AddWithValue("@id", id);

            //executa o comando e retorna o resultado da Query
            OdbcDataReader leitor = comando.ExecuteReader();

            //A cada linha ele monta um objeto
            while (leitor.Read())
            {
                return MontarObjeto(leitor);
            }

            return null;
        }

        /// <summary>
        /// lista todos os registros de localidade na tabela localidades
        /// </summary>
        /// <returns></returns>
        public List<Localidade> ListarTodos()
        {
            string querySql = "SELECT l.ID, c.ID AS ID_CIDADE, c.CIDADE, e.ID AS ID_ESTADO, e.ESTADO, l.BAIRRO, l.ENDERECO, l.CEP FROM " + nomeTabela + " AS l INNER JOIN cidades AS c ON l.ID_CIDADE = c.ID INNER JOIN estados AS e ON c.ID_ESTADO = e.ID";

            List<Localidade> listaLocalidade = new List<Localidade>();

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //executa o comando e retorna o resultado da Query
            OdbcDataReader leitor = comando.ExecuteReader();

            //A cada linha ele monta um objeto
            while (leitor.Read())
            {
                listaLocalidade.Add(MontarObjeto(leitor));
            }

            //Se a lista estiver diferente de vazia retorna a lista
            if (listaLocalidade.Count != 0)
                return listaLocalidade;
            else
                return null;
        }

        /// <summary>
        /// lista registros de localidade na tabela localidades dependendo de um argumento para fazer uma pesquisa específica
        /// </summary>
        public List<Localidade> ListarPorWhere(string where)
        {
            string querySql = "SELECT l.ID, c.ID AS ID_CIDADE, c.CIDADE, e.ID AS ID_ESTADO, e.ESTADO, l.BAIRRO, l.ENDERECO, l.CEP FROM " + nomeTabela + " AS l INNER JOIN cidades AS c ON l.ID_CIDADE = c.ID INNER JOIN estados AS e ON c.ID_ESTADO = e.ID WHERE " + where;

            List<Localidade> listaLocalidade = new List<Localidade>();

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //executa o comando e retorna o resultado da Query
            OdbcDataReader leitor = comando.ExecuteReader();

            //A cada linha ele monta um objeto
            while (leitor.Read())
            {
                listaLocalidade.Add(MontarObjeto(leitor));
            }

            //Se a lista estiver diferente de vazia retorna a lista
            if (listaLocalidade.Count != 0)
                return listaLocalidade;
            else
                return null;
        }

        /// <summary>
        /// Monta o objeto que vai ser retornado nos metodos publicos
        /// </summary>
        public Localidade MontarObjeto(OdbcDataReader leitor)
        {
            Localidade localidade = new Localidade();

            localidade.Id = (!leitor.IsDBNull(0)) ? leitor.GetInt32(0) : 0; //ID - localidades

            localidade.Cidade = new Cidade(); //constroi a cidade dentro de localidade
            localidade.Cidade.Id = (!leitor.IsDBNull(1)) ? leitor.GetInt32(1) : 0; //ID - cidades
            localidade.Cidade.Nome = (!leitor.IsDBNull(2)) ? leitor.GetString(2) : null; //CIDADE - cidades

            localidade.Cidade.Estado = new Estado(); //constroi o estado dentro de cidade
            localidade.Cidade.Estado.Id = (!leitor.IsDBNull(3)) ? leitor.GetInt32(3) : 0; //ID - estados
            localidade.Cidade.Estado.Nome = (!leitor.IsDBNull(4)) ? leitor.GetString(4) : null; //ESTADO - estados
            localidade.Bairro = (!leitor.IsDBNull(5)) ? leitor.GetString(5) : null; //BAIRRO - localidades
            localidade.Endereco = (!leitor.IsDBNull(6)) ? leitor.GetString(6) : null; //ENDERECO - localidades
            localidade.Cep = (!leitor.IsDBNull(7)) ? leitor.GetString(7) : null; //CEP - localidades

            return localidade;
        }

        /// <summary>
        /// verifica o numero de linhas que foi alterada na tabela(maior que 0 = true / 0 ou menor = false)
        /// </summary>
        private static bool VerificarAlteracao(int numLinhasAfetadas)
        {
            if (numLinhasAfetadas > 0)
                return true;
            else
                return false;
        }

        #endregion

        #region Getters&Setters

        private ConexaoASC Conexao
        {
          get { return conexao;}
          set { conexao = value;}
        }

        #endregion
    }
}
