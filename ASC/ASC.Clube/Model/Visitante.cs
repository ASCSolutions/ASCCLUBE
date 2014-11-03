using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Visitante
    {
        #region Atributos

        private int id;
        private string nome;
        private string cpf;

        #endregion

        #region Construtores

        public Visitante() { }

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
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        #endregion
    }
}
