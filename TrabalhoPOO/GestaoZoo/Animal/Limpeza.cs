using InterfaceDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever uma limpeza
    /// </summary>
    public class Limpeza : ILimpeza
    {
        #region ATRIBUTOS
        private int id;
        private int recinto;
        private int funcionario;
        private DateTime data;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Limpeza()
        {
            this.id = -1;
            this.recinto = -1;
            this.funcionario = -1;
            this.data = DateTime.Now;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id da limpeza</param>
        /// <param name="recinto">Recinto da limpeza</param>
        /// <param name="funcionario">Funcionário da limpeza</param>
        /// <param name="data">Data da limpeza</param>
        public Limpeza(int id, int recinto, int funcionario, DateTime data)
        {
            this.id = id;
            this.recinto = recinto;
            this.funcionario = funcionario;
            this.data = data;
        }
        #endregion
        #region PROPRIEDADES
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int Recinto
        {
            set { recinto = value; }
            get { return recinto; }
        }
        public int Funcionario
        {
            set { funcionario = value; }
            get { return funcionario; }
        }
        public DateTime Data
        {
            set { data = value; }
            get { return data; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Limpeza l1, Limpeza l2)
        {
            if ((l1.Id == l2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Limpeza l1, Limpeza l2)
        {
            if ((l1.Id == l2.Id))
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
            if (obj is Limpeza l)
            {
                if (this == l)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};", this.id.ToString(), this.recinto.ToString(), this.funcionario.ToString(), this.data.ToString());
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
