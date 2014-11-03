using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Localidade
    {
        #region Atributos

        private int id;
        private Cidade cidade;
        private string bairro;
        private string endereco;
        private string cep;

        #endregion

        #region Construtores

        public Localidade() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Cidade Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        #endregion
    }
}
