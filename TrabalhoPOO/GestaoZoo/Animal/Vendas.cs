using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    /// <summary>
    /// Classe para guardar as vendas
    /// </summary>
    public class Vendas
    {
        #region ATRIBUTOS
        private const int MAXVENDAS = 100;
        private static Venda[] l_vendas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Vendas()
        {
            for (int i = 0; i < MAXVENDAS; i++)
            {
                l_vendas[i] = new Venda();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Venda[] LVendas
        {
            set { l_vendas = value; }
            get { return l_vendas; }
        }
        #endregion
        #region OPERADORES
        //public static bool operator ==(Animais a1, Animais a2)
        //{
        //    if (Animais.LAnimais == a2.LAnimais)
        //        return true;
        //    return false;
        //}
        //public static bool operator !=(Animais a1, Animais a2)
        //{
        //    if (a1.LAnimais == a2.LAnimais)
        //        return true;
        //    return false;
        //}
        #endregion
        #region OVERRIDES
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Vendas v)
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
            string output = "";
            if (LVendas == null)
                return String.Format(output);
            else
            {
                foreach (Venda venda in l_vendas)
                {
                    output += venda.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar as vendas todas
        /// </summary>
        /// <param name="output">Array de strings com as vendas</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Venda venda in l_vendas)
            {
                if (venda.Id == -1)
                    continue;
                output[i] = venda.Listar();
                i++;
            }
        }
        #endregion
        #endregion
    }
}
