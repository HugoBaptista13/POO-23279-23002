using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using InterfaceDLL;

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
        private int lotacao_total;
        private string local;
        private DateTime data_inicio;
        private DateTime data_fim;
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
            this.lotacao_total = lotacao+1;
            this.local = string.Empty;
            this.data_inicio = DateTime.Today;
            this.data_fim = new DateTime(data_inicio.Year,data_inicio.Month+1,data_inicio.Day);
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="nome">Nome do evento</param>
        /// <param name="lotacao">Lotação do evento</param>
        /// <param name="lotacao_total">Lotação total do evento</param>
        /// <param name="local">Local do evento</param>
        /// <param name="data_inicio">Data de inicio do evento</param>
        /// <param name="data_fim">Data de fim do evento</param>
        public Evento(int id, string nome, int lotacao, int lotacao_total, string local, DateTime data_inicio, DateTime data_fim)
        {
            this.id = id;
            this.nome = nome;
            this.lotacao = lotacao;
            this.lotacao_total = lotacao_total;
            this.local = local;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
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
            set { lotacao_total = value; }
            get { return lotacao_total; }
        }
        public string Local
        {
            set { local = value; }
            get { return local; }
        }
        public DateTime DataInicio
        {
            set { data_inicio = value; }
            get { return data_inicio; }
        }
        public DateTime DataFim
        {
            set { data_fim = value; }
            get { return data_fim; }
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
            return String.Format("{0};{1};{2};{3};{4};{5};{6};", this.id.ToString(), this.nome.ToString(), this.lotacao.ToString(), this.lotacao_total.ToString(), this.local.ToString(), this.data_inicio.ToString(), this.data_fim.ToString());
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
