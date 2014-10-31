using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public abstract class Usuario
    {
        #region Atributos

        private int idUsuario;

        private string sigla;
        private string email;
        private string senha;
        private char situacao;

        private string nome;
        private char sexo;

        private List<HistoricoUsuario> listaHistoricoUsuario;

        #endregion

        #region Construtores

        public Usuario() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public string Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public char Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }
        public List<HistoricoUsuario> ListaHistoricoUsuario
        {
            get { return listaHistoricoUsuario; }
            set { listaHistoricoUsuario = value; }
        }

        #endregion
    }
}
