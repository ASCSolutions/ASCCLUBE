using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Foto
    {
        #region Atributos

        private int id;
        private string arquivo;
        private FotoStatus fotoStatus;
        private Associado associado;

        #endregion

        #region Construtores

        public Foto() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Arquivo
        {
            get { return arquivo; }
            set { arquivo = value; }
        }
        public FotoStatus FotoStatus
        {
            get { return fotoStatus; }
            set { fotoStatus = value; }
        }
        public Associado Associado
        {
            get { return associado; }
            set { associado = value; }
        }

        #endregion
    }
}
