using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Setor
    {
        #region Atributos

        private int id;
        private string nome;
        private string email;
        private string remetente;

        private List<Administrador> listaadministradores;
        private List<Mensagem> listamensagens;
        private List<Administrador> listaAdministradores;

        #endregion
        

        #region Construtores

        public Setor() { }

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
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Remetente
        {
            get { return remetente; }
            set { remetente = value; }
        }
        public List<Administrador> Usuarios
        {
            get { return listaadministradores; }
            set { listaadministradores = value; }
        }
        public List<Mensagem> Mensagens
        {
            get { return listamensagens; }
            set { listamensagens = value; }
        }

        #endregion
    }
}
