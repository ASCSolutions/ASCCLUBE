using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class MensagemStatus
    {
        #region Atributos

        private int id;
        private string nomeStatus;
        private string descricao;

        #endregion

        #region Construtores

        public MensagemStatus() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string NomeStatus
        {
            get { return nomeStatus; }
            set { nomeStatus = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        #endregion
    }
}
