using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace ASC.Util.Data.Conexao
{
    public class ConexaoASC
    {
        #region Atributos

        //string connection, depois deverá entrar aqui uma string criptografada // CRIPTOGRAFADA
        private const String STR_CONEXAO = "Driver=MySQL ODBC 5.2 ANSI Driver;DATABASE=ascweb_clube;SERVER=localhost;UID=root;PASSWORD=cpdadmin;"; //Driver=MySQL ODBC 5.2 ANSI Driver;DATABASE=teste_db;SERVER=localhost;UID=root;PASSWORD=cpdadmin;

        //o objeto de conexao Odbc
        private OdbcConnection conn;

        #endregion

        #region Construtores

        public ConexaoASC()
        {
            this.Conn = new OdbcConnection(STR_CONEXAO); //Será bom criptografar
        }

        #endregion

        #region Metodos

        //conecta ao banco
        public bool AbrirConexao()
        {
            if (this.conn.State != ConnectionState.Open)
            {
                try
                {
                    this.conn.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return true;
        }

        //fecha a conexao no banco
        public bool FecharConexao()
        {
            if (this.conn.State == ConnectionState.Closed)
                return true;
            else
            {
                try
                {
                    this.conn.Close();
                    return true;
                }
                catch (Exception)
                {

                }
            }

            return false;
        }

        #endregion

        #region Getters&Setters

        public OdbcConnection Conn
        {
            get
            {
                this.AbrirConexao();
                return conn;
            }
            set { conn = value; }
        }

        #endregion
    }
}
