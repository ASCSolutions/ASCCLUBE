using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASC.Util.Data.Interfaces;
using ASC.Util.Data.Conexao;
using System.Data.Odbc;
using ASC.Clube.Model;
using System.Data;

namespace ASC.Clube.Control.DAO
{
    public class LocalidadeDAO : IDAONegocio<Localidade>
    {
        #region Atributos

        private ConexaoASC conexao;
        private const string nomeTabela = "localidades";
        private bool objetoCompleto;

        

        /// <summary>
        /// Query que fornece todos os campos para ser contruído o objeto completo
        /// </summary>
        private const string selectAllQueryPadraoObjetoCompleto = 
            @"SELECT l.ID, 
            c.ID AS ID_CIDADE, 
            c.CIDADE, 
            e.ID AS ID_ESTADO, 
            e.ESTADO, 
            l.BAIRRO, 
            l.ENDERECO, 
            l.CEP 
            FROM " + nomeTabela + @" AS l 
            INNER JOIN cidades AS c 
            ON l.ID_CIDADE = c.ID 
            INNER JOIN estados AS e 
            ON c.ID_ESTADO = e.ID";

        /// <summary>
        /// Query que fornece os campos para ser contruído o objeto parcial
        /// </summary>
        private const string selectAllQueryPadraoObjetoParcial =
            @"SELECT l.ID, 
            l.ID_CIDADE,
            l.BAIRRO, 
            l.ENDERECO, 
            l.CEP 
            FROM " + nomeTabela + @" AS l";

        #endregion

        #region Construtores

        public LocalidadeDAO()
        {
            this.Conexao = new ConexaoASC();
            objetoCompleto = true;
        }
        public LocalidadeDAO(bool objCompleto) : this()
        {
            this.objetoCompleto = objCompleto;
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
            string querySql = selectAllQueryPadraoObjetoCompleto + " WHERE l.ID = ?";

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //Parametros que serão substituidos na Query
            comando.Parameters.AddWithValue("@id", id);

            //executa o comando e retorna o resultado da Query
            OdbcDataReader leitor = comando.ExecuteReader();

            //acessar o primeiro objeto da lista
            return FabricarObjetos(leitor).FirstOrDefault();
        }

        /// <summary>
        /// lista todos os registros de localidade na tabela localidades
        /// </summary>
        /// <returns></returns>
        public List<Localidade> ListarTodos()
        {
            string querySql = selectAllQueryPadraoObjetoCompleto;

            List<Localidade> listaLocalidade = new List<Localidade>();

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //executa o comando e retorna o resultado da Query
            OdbcDataReader leitor = comando.ExecuteReader();

            return FabricarObjetos(leitor);
        }

        /// <summary>
        /// lista registros de localidade na tabela localidades dependendo de um argumento para fazer uma pesquisa específica(SQL)
        /// </summary>
        public List<Localidade> ListarPorWhere(string where)
        {
            string querySql = selectAllQueryPadraoObjetoCompleto + " WHERE " + where;

            List<Localidade> listaLocalidade = new List<Localidade>();

            OdbcCommand comando = new OdbcCommand(querySql, this.Conexao.Conn);

            //executa o comando e retorna o resultado da Query
            OdbcDataReader leitor = comando.ExecuteReader();

            return FabricarObjetos(leitor);
        }

        /// <summary>
        /// Monta o objeto completo que vai ser retornado nos metodos publicos
        /// </summary>
        //public Localidade MontarObjetoCompleto(OdbcDataReader leitor)
        //{
        //    Localidade localidade = new Localidade();

        //    localidade.Id = (!leitor.IsDBNull(0)) ? leitor.GetInt32(0) : 0; //ID - localidades

        //    localidade.Cidade = new Cidade(); //constroi a cidade dentro de localidade
        //    localidade.Cidade.Id = (!leitor.IsDBNull(1)) ? leitor.GetInt32(1) : 0; //ID - cidades
        //    localidade.Cidade.Nome = (!leitor.IsDBNull(2)) ? leitor.GetString(2) : null; //CIDADE - cidades

        //    localidade.Cidade.Estado = new Estado(); //constroi o estado dentro de cidade
        //    localidade.Cidade.Estado.Id = (!leitor.IsDBNull(3)) ? leitor.GetInt32(3) : 0; //ID - estados
        //    localidade.Cidade.Estado.Nome = (!leitor.IsDBNull(4)) ? leitor.GetString(4) : null; //ESTADO - estados

        //    localidade.Bairro = (!leitor.IsDBNull(5)) ? leitor.GetString(5) : null; //BAIRRO - localidades
        //    localidade.Endereco = (!leitor.IsDBNull(6)) ? leitor.GetString(6) : null; //ENDERECO - localidades
        //    localidade.Cep = (!leitor.IsDBNull(7)) ? leitor.GetString(7) : null; //CEP - localidades

        //    return localidade;
        //}

        /// <summary>
        /// Monta o objeto parcial que vai ser retornado nos metodos publicos
        /// </summary>
        //public Localidade MontarObjetoParcial(OdbcDataReader leitor)
        //{
        //    Localidade localidade = new Localidade();

        //    localidade.Id = (!leitor.IsDBNull(0)) ? leitor.GetInt32(0) : 0; //ID - localidades

        //    localidade.Cidade = new Cidade(); //constroi a cidade dentro de localidade
        //    localidade.Cidade.Id = (!leitor.IsDBNull(1)) ? leitor.GetInt32(1) : 0; //ID_CIDADE - localidades

        //    localidade.Bairro = (!leitor.IsDBNull(5)) ? leitor.GetString(5) : null; //BAIRRO - localidades
        //    localidade.Endereco = (!leitor.IsDBNull(6)) ? leitor.GetString(6) : null; //ENDERECO - localidades
        //    localidade.Cep = (!leitor.IsDBNull(7)) ? leitor.GetString(7) : null; //CEP - localidades

        //    return localidade;
        //}

        /// <summary>
        /// Monta todos os objetos(completo) e retorna uma lista
        /// </summary>
        public List<Localidade> MontarObjetosCompleto(OdbcDataReader leitor)
        {
            DataTable dt = new DataTable("localidades");
            dt.Load(leitor);

            return dt.Select().Select(x => new Localidade
            {
                Id = x.Field<int>("ID"),
                Cidade = new Cidade
                {
                    Id = x.Field<int>("ID"),
                    Nome = x.Field<string>("CIDADE"),
                    Estado = new Estado
                    {
                        Id = x.Field<int>("ID"),
                        Nome = x.Field<string>("ESTADO"),
                    },
                },
                Bairro = x.Field<string>("BAIRRO"),
                Endereco = x.Field<string>("ENDERECO"),
                Cep = x.Field<string>("CEP"),

            }
            ).ToList();
        }

        /// <summary>
        /// Monta todos os objetos(parcial) e retorna uma lista
        /// </summary>
        public List<Localidade> MontarObjetosParcial(OdbcDataReader leitor)
        {
            DataTable dt = new DataTable("localidades");
            dt.Load(leitor);

            return dt.Select().Select(x => new Localidade
            {
                Id = x.Field<int>("ID"),
                Cidade = new Cidade
                {
                    Id = x.Field<int>("ID"),
                },
                Bairro = x.Field<string>("BAIRRO"),
                Endereco = x.Field<string>("ENDERECO"),
                Cep = x.Field<string>("CEP"),

            }
            ).ToList();
        }

        /// <summary>
        /// Fabrica todos os objetos necessarios para servir de retorno dos metodos de select
        /// </summary>
        //public List<Localidade> FabricarObjetos(OdbcDataReader leitor)
        //{
        //    List<Localidade> listaLocalidade = new List<Localidade>();

        //    //A cada linha ele monta um objeto
        //    if (this.ObjetoCompleto)
        //    {
        //        while (leitor.Read())
        //        {
        //            listaLocalidade.Add(MontarObjetoCompleto(leitor));
        //        }
        //    }
        //    else
        //    {
        //        while (leitor.Read())
        //        {
        //            listaLocalidade.Add(MontarObjetoParcial(leitor));
        //        }
        //    }

        //    //Se a lista estiver diferente de vazia retorna a lista
        //    if (listaLocalidade.Count != 0)
        //        return listaLocalidade;
        //    else
        //        return null;
        //}

        /// <summary>
        /// Fabrica os objetos optando pela construção completa do objeto ou parcial
        /// </summary>
        public List<Localidade> FabricarObjetos(OdbcDataReader leitor)
        {
            List<Localidade> listaLocalidade = new List<Localidade>();

            if (this.ObjetoCompleto)
                listaLocalidade = MontarObjetosCompleto(leitor);
            else
                listaLocalidade = MontarObjetosParcial(leitor);

            //Se a lista estiver diferente de vazia retorna a lista
            if (listaLocalidade.Count != 0)
                return listaLocalidade;
            else
                return null;
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
        public bool ObjetoCompleto
        {
            get { return objetoCompleto; }
            set { objetoCompleto = value; }
        }

        #endregion
    }
}
