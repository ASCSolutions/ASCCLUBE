using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Config
    {
        #region Atributos

        private int id;
        private string host;
        private string login;
        private string senha;
        private string porta;
        private string remetente;

        #endregion

        #region Construtores

        public Config() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public string Porta
        {
            get { return porta; }
            set { porta = value; }
        }
        public string Remetente
        {
            get { return remetente; }
            set { remetente = value; }
        }

        #endregion
    }
}
