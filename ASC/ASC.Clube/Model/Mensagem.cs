using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube
{
    public class Mensagem
    {
        #region Atributos

        private int id;

        private Associado associado;
        private MensagemStatus mensagemStatus;
        private Setor setor;
        private List<MensagemDet> listaMensagemDet;
        private Classificacao classificacao;

        #endregion

        #region Construtores

        public Mensagem() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Associado Associado
        {
            get { return associado; }
            set { associado = value; }
        }
        public MensagemStatus MensagemStatus
        {
            get { return mensagemStatus; }
            set { mensagemStatus = value; }
        }
        public Setor Setor
        {
            get { return setor; }
            set { setor = value; }
        }
        public List<MensagemDet> ListaMensagemDet
        {
            get { return listaMensagemDet; }
            set { listaMensagemDet = value; }
        }
        public Classificacao Classificacao
        {
            get { return classificacao; }
            set { classificacao = value; }
        }

        #endregion
    }
}
