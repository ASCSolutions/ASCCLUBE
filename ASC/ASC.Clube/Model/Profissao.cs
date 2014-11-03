using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Profissao
    {
        #region Atributos

        private int id;
        private string descricao;

        #endregion

        #region Construtores

        public Profissao() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        #endregion
    }
}
