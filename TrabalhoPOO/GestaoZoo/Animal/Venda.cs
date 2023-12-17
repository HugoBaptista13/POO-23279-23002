using InterfaceDLL;
using System;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever uma venda
    /// </summary>
    [Serializable]
    public class Venda : IVenda
    {
        #region ATRIBUTOS
        private int id;
        private int bilhete;
        private int numBilhetes;
        private double valor;
        private DateTime dataVenda;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Venda()
        {
            this.id = -1;
            this.bilhete = -1;
            this.numBilhetes = -1;
            this.valor = -1;
            this.dataVenda = DateTime.Today;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id da venda</param>
        /// <param name="bilhete">Bilhete da venda</param>
        /// <param name="numBilhetes">Número de bilhetes da venda</param>
        /// <param name="valor">Valor da venda</param>
        /// <param name="dataVenda">Data da venda</param>
        public Venda(int id, int bilhete, int numBilhetes, double valor, DateTime dataVenda)
        {
            this.id = id;
            this.bilhete = bilhete;
            this.numBilhetes = numBilhetes;
            this.valor = valor;
            this.dataVenda = dataVenda;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        public Venda(Venda venda)
        {
            this.id = venda.id;
            this.bilhete = venda.bilhete;
            this.numBilhetes = venda.numBilhetes;
            this.valor = venda.valor;
            this.dataVenda = venda.dataVenda;
        }
        #endregion
        #region PROPRIEDADES
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int Bilhete
        {
            set { bilhete = value; }
            get { return bilhete; }
        }
        public int NumBilhetes
        {
            set { numBilhetes = value; }
            get { return numBilhetes; }
        }
        public double Valor
        {
            set { valor = value; }
            get { return valor; }
        }
        public DateTime DataVenda
        {
            set { dataVenda = value; }
            get { return dataVenda; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Venda v1, Venda v2)
        {
            if ((v1.Id == v2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Venda v1, Venda v2)
        {
            if ((v1.Id == v2.Id))
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
            if (obj is Venda v)
            {
                if (this == v)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};", this.id.ToString(), this.bilhete.ToString(), this.numBilhetes.ToString(), this.valor.ToString(), this.dataVenda.ToString());
        }
        #endregion
        #region OUTROS
        public string Listar()
        {
            return this.ToString();
        }
        public double CalcularValor()
        {
            return 0;
        }
        #endregion
        #endregion
    }
}
