using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Dependente
    {
        #region Atributos

        private int id;

        private string nome;
        private string nomePai;
        private string nomeMae;
        private string foto;
        private string rg;

        private string telefone;
        private string email;
        private Localidade localidade;

        private Associado associado;

        #endregion

        #region Construtores

        public Dependente() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string NomePai
        {
            get { return nomePai; }
            set { nomePai = value; }
        }
        public string NomeMae
        {
            get { return nomeMae; }
            set { nomeMae = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Localidade Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }
        public Associado Associado
        {
            get { return associado; }
            set { associado = value; }
        }

        #endregion
    }
}
