using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Administrador : Usuario
    {
        #region Atributos

        private int idAdministrador;

        private Setor setor;
        private List<Mensagem> listaConversa;

        #endregion

        #region Construtores

        public Administrador() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int IdAdministrador
        {
            get { return idAdministrador; }
            set { idAdministrador = value; }
        }
        public Setor Setor
        {
            get { return setor; }
            set { setor = value; }
        }
        public List<Mensagem> ListaConversa
        {
            get { return listaConversa; }
            set { listaConversa = value; }
        }

        #endregion
    }
}
