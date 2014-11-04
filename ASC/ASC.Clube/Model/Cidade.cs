using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Cidade
    {
        #region Atributos

        private int id;
        private string nome;
        private Estado estado;

        #endregion

        #region Construtores

        public Cidade() { }

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
        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion
    }
}
