using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
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

        /// <summary>
        /// Método para adicionar uma venda
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public bool Inserir(Venda venda)
        {
            if (l_vendas == null || venda == null)
            {
                return false;
            }
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (l_vendas[i] == venda)
                {
                    return false;
                }
                if (l_vendas[i].Id == -1)
                {
                    l_vendas[i].Id = venda.Id;
                    l_vendas[i].Bilhete = venda.Bilhete;
                    l_vendas[i].NumBilhetes = venda.NumBilhetes;
                    l_vendas[i].Valor = venda.Valor;
                    l_vendas[i].DataVenda = venda.DataVenda;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de uma venda
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Venda venda)
        {
            if (venda == null || l_vendas == null)
                return false;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (l_vendas[i] != venda)
                {
                    return false;
                }
                if (l_vendas[i].Id == venda.Id)
                {
                    l_vendas[i].Id = venda.Id;
                    l_vendas[i].Bilhete = venda.Bilhete;
                    l_vendas[i].NumBilhetes = venda.NumBilhetes;
                    l_vendas[i].Valor = venda.Valor;
                    l_vendas[i].DataVenda = venda.DataVenda;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de uma venda
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(Venda venda)
        {
            if (venda == null || l_vendas == null)
                return false;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (l_vendas[i] != venda)
                {
                    return false;
                }
                if (l_vendas[i].Id == venda.Id)
                {
                    l_vendas[i].Id = -1;
                    l_vendas[i].Bilhete = -1;
                    l_vendas[i].NumBilhetes = -1;
                    l_vendas[i].Valor = -1;
                    l_vendas[i].DataVenda = DateTime.MinValue;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma venda
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(Venda venda)
        {
            if (venda == null || l_vendas == null)
                return false;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (l_vendas[i] != venda)
                {
                    return false;
                }
                if (l_vendas[i].Id == venda.Id)
                {
                    break;
                }
            }
            return true;
        }
        #endregion
        #endregion
    }
}
