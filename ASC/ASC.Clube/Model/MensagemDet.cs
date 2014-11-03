using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class MensagemDet
    {
        #region Atributos

        private int id;
        private string mensagem;
        private Associado associado;
        private Administrador administrador;
        
        #endregion

        #region Construtores

        public MensagemDet() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }
        public Associado Associado
        {
            get { return associado; }
            set { associado = value; }
        }
        public Administrador Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }

        #endregion
    }
}
