using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Convite
    {
        #region Atributos

        private int id;

        private DateTime validade;
        private Associado associado;
        private Visitante visitante;

        #endregion

        #region Construtores

        public Convite() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Validade
        {
            get { return validade; }
            set { validade = value; }
        }
        public Associado Associado
        {
            get { return associado; }
            set { associado = value; }
        }
        public Visitante Visitante
        {
            get { return visitante; }
            set { visitante = value; }
        }

        #endregion
    }
}
