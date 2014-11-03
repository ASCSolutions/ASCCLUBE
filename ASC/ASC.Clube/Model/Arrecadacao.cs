using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Arrecadacao
    {
        #region Atributos

        private int id;
        private Associado associado;

        private int idBoleto;
        private char estado;
        private int mesAno;
        private DateTime dataVencimento;

        private double valor;
        private double desconto;
        private double juros;

        #endregion

        #region Construtores

        public Arrecadacao() { }

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
        public int IdBoleto
        {
            get { return idBoleto; }
            set { idBoleto = value; }
        }
        public char Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public int MesAno
        {
            get { return mesAno; }
            set { mesAno = value; }
        }
        public DateTime DataVencimento
        {
            get { return dataVencimento; }
            set { dataVencimento = value; }
        }
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public double Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
        public double Juros
        {
            get { return juros; }
            set { juros = value; }
        }

        #endregion
    }
}
