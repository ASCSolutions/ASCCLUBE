using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Localidade
    {
        #region Atributos

        private int id;
        private string pais;
        private string uf;
        private string cidade;
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

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }
        public string Cidade
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
