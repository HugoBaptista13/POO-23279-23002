using InterfaceDLL;
using System;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever um evento
    /// </summary>
    public class Evento : IEvento
    {
        #region ATRIBUTOS
        private int id;
        private string nome;
        private int lotacao;
        private int lotacaoTotal;
        private string local;
        private DateTime dataInicio;
        private DateTime dataFim;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Evento()
        {
            this.id = -1;
            this.nome = string.Empty;
            this.lotacao = -1;
            this.lotacaoTotal = lotacao+1;
            this.local = string.Empty;
            this.dataInicio = DateTime.Today;
            this.dataFim = new DateTime(dataInicio.Year,dataInicio.Month+1,dataInicio.Day);
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="nome">Nome do evento</param>
        /// <param name="lotacao">Lotação do evento</param>
        /// <param name="lotacaoTotal">Lotação total do evento</param>
        /// <param name="local">Local do evento</param>
        /// <param name="dataInicio">Data de inicio do evento</param>
        /// <param name="dataFim">Data de fim do evento</param>
        public Evento(int id, string nome, int lotacao, int lotacaoTotal, string local, DateTime dataInicio, DateTime dataFim)
        {
            this.id = id;
            this.nome = nome;
            this.lotacao = lotacao;
            this.lotacaoTotal = lotacaoTotal;
            this.local = local;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="evento">Objeto do tipo evento</param>
        public Evento(Evento evento)
        {
            this.id = evento.id;
            this.nome = evento.nome;
            this.lotacao = evento.lotacao;
            this.lotacaoTotal = evento.lotacaoTotal;
            this.local = evento.local;
            this.dataInicio = evento.dataInicio;
            this.dataFim = evento.dataFim;
        }
        #endregion
        #region PROPRIEDADES
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }
        public int Lotacao
        {
            set { lotacao = value; }
            get { return lotacao; }
        }
        public int LotacaoTotal
        {
            set { lotacaoTotal = value; }
            get { return lotacaoTotal; }
        }
        public string Local
        {
            set { local = value; }
            get { return local; }
        }
        public DateTime DataInicio
        {
            set { dataInicio = value; }
            get { return dataInicio; }
        }
        public DateTime DataFim
        {
            set { dataFim = value; }
            get { return dataFim; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Evento e1, Evento e2)
        {
            if ((e1.Id == e2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Evento e1, Evento e2)
        {
            if ((e1.Id == e2.Id))
                return true;
            return false;
        }
        #endregion
        #region OVERRIDES
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Evento e)
            {
                if (this == e)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};", this.id.ToString(), this.nome.ToString(), this.lotacao.ToString(), this.lotacaoTotal.ToString(), this.local.ToString(), this.dataInicio.ToString(), this.dataFim.ToString());
        }
        #endregion
        #region OUTROS
        public string Listar()
        {
            return this.ToString();
        }
        #endregion
        #endregion
    }
}
