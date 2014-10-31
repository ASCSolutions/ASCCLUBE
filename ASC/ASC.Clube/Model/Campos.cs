using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Campo
    {
        #region Atributos

        private int id;
        private string nome;
        private string descricao;
        private bool isBlocked;

        #endregion

        #region Construtores

        public Campo() { }

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
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public bool IsBlocked
        {
            get { return isBlocked; }
            set { isBlocked = value; }
        }

        #endregion
    }
}
