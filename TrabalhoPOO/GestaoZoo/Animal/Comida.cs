using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDLL;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever a comida dos animais
    /// </summary>
    public class Comida : IComida
    {
        #region ATRIBUTOS
        private int id;
        private string nome;
        private string tipo;
        private string dieta;
        private int stock;
        private DateTime data_validade;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Comida()
        {
            this.id = -1;
            this.nome = string.Empty;
            this.tipo = string.Empty;
            this.dieta = string.Empty;
            this.stock = -1;
            this.data_validade = new DateTime(DateTime.Today.Year,DateTime.Now.Month+1,DateTime.Now.Day);
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id da comida</param>
        /// <param name="nome">Nome da comida</param>
        /// <param name="tipo">Tipo da comida</param>
        /// <param name="dieta">Dieta da comida</param>
        /// <param name="stock">Stock da comida</param>
        /// <param name="data_validade">Data de validade da comida</param>
        public Comida(int id, string nome, string tipo, string dieta, int stock, DateTime data_validade)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.dieta = dieta;
            this.stock = stock;
            this.data_validade = data_validade;
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
        public string Tipo
        {
            set { tipo = value; }
            get { return tipo; }
        }
        public string Dieta
        {
            set { dieta = value; }
            get { return dieta; }
        }
        public int Stock
        {
            set { stock = value; }
            get { return stock; }
        }
        public DateTime DataValidade
        {
            set { data_validade = value; }
            get { return data_validade; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Comida c1, Comida c2)
        {
            if ((c1.Id == c2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Comida c1, Comida c2)
        {
            if ((c1.Id == c2.Id))
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
            if (obj is Comida c)
            {
                if (this == c)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};", this.id.ToString(), this.nome.ToString(), this.tipo.ToString(), this.dieta.ToString(), this.stock.ToString(), this.data_validade.ToString());
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
