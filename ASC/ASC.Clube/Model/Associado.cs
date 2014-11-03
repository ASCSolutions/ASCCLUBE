using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASC.Clube.Model
{
    public class Associado : Usuario
    {
        #region Atributos

        private int id;
        private int idAssociado;

        private string matricula;
        private string titulo;
        private string cpf;
        private string rg;
        private string foto;

        private string telefone1;
        private string telefone2;
        private string telefone3;
        private string tipoTelefone1;
        private string tipoTelefone2;
        private string tipoTelefone3;

        private string naturalidade;
        private Escolaridade escolaridade;
        private Profissao profissao;
        private EstadoCivil estadoCivil;

        private Localidade localidadePessoal;
        private Localidade localidadeCobranca;
        private Localidade localidadeResidencial;
        private Localidade localidadeComercial;

        private string telefoneComercial;
        private string ramal;
        private string emailComercial;

        private List<Dependente> listaDependente;
        private List<Convite> listaConvite;

        #endregion

        #region Construtores

        public Associado() { }

        #endregion

        #region Metodos

        #endregion

        #region Getters&Setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public string Telefone1
        {
            get { return telefone1; }
            set { telefone1 = value; }
        }
        public string Telefone2
        {
            get { return telefone2; }
            set { telefone2 = value; }
        }
        public string Telefone3
        {
            get { return telefone3; }
            set { telefone3 = value; }
        }
        public string TipoTelefone1
        {
            get { return tipoTelefone1; }
            set { tipoTelefone1 = value; }
        }
        public string TipoTelefone2
        {
            get { return tipoTelefone2; }
            set { tipoTelefone2 = value; }
        }
        public string TipoTelefone3
        {
            get { return tipoTelefone3; }
            set { tipoTelefone3 = value; }
        }
        public string Naturalidade
        {
            get { return naturalidade; }
            set { naturalidade = value; }
        }
        public Escolaridade Escolaridade
        {
            get { return escolaridade; }
            set { escolaridade = value; }
        }
        public Profissao Profissao
        {
            get { return profissao; }
            set { profissao = value; }
        }
        public EstadoCivil EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }
        public Localidade LocalidadePessoal
        {
            get { return localidadePessoal; }
            set { localidadePessoal = value; }
        }
        public Localidade LocalidadeCobranca
        {
            get { return localidadeCobranca; }
            set { localidadeCobranca = value; }
        }
        public Localidade LocalidadeResidencial
        {
            get { return localidadeResidencial; }
            set { localidadeResidencial = value; }
        }
        public Localidade LocalidadeComercial
        {
            get { return localidadeComercial; }
            set { localidadeComercial = value; }
        }
        public string TelefoneComercial
        {
            get { return telefoneComercial; }
            set { telefoneComercial = value; }
        }
        public string Ramal
        {
            get { return ramal; }
            set { ramal = value; }
        }
        public string EmailComercial
        {
            get { return emailComercial; }
            set { emailComercial = value; }
        }
        public List<Dependente> ListaDependente
        {
            get { return listaDependente; }
            set { listaDependente = value; }
        }
        public List<Convite> ListaConvite
        {
            get { return listaConvite; }
            set { listaConvite = value; }
        }

        #endregion
    }
}
