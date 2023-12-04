using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever uma venda
    /// </summary>
    public class Venda
    {
        #region ATRIBUTOS
        private int id;
        private int bilhete;
        private int num_bilhetes;
        private double valor;
        private DateTime data_venda;
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
            this.num_bilhetes = -1;
            this.valor = -1;
            this.data_venda = DateTime.Today;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id da venda</param>
        /// <param name="bilhete">Bilhete da venda</param>
        /// <param name="num_bilhetes">Número de bilhetes da venda</param>
        /// <param name="valor">Valor da venda</param>
        /// <param name="data_venda">Data da venda</param>
        public Venda(int id, int bilhete, int num_bilhetes, double valor, DateTime data_venda)
        {
            this.id = id;
            this.bilhete = bilhete;
            this.num_bilhetes = num_bilhetes;
            this.valor = valor;
            this.data_venda = data_venda;
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
            set { num_bilhetes = value; }
            get { return num_bilhetes; }
        }
        public double Valor
        {
            set { valor = value; }
            get { return valor; }
        }
        public DateTime DataVenda
        {
            set { data_venda = value; }
            get { return data_venda; }
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
            return String.Format("{0};{1};{2};{3};{4};", this.id.ToString(), this.bilhete.ToString(), this.num_bilhetes.ToString(), this.valor.ToString(), this.data_venda.ToString());
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
