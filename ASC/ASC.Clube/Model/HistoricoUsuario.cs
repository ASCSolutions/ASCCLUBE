using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class HistoricoUsuario
    {
        #region Atributos

        private int id;
        private DateTime dataHoraAcesso;
        private Usuario usuario;

        #endregion

        #region Construtores

        public HistoricoUsuario() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime DataHoraAcesso
        {
            get { return dataHoraAcesso; }
            set { dataHoraAcesso = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        #endregion
    }
}
