using InterfaceDLL;
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
        private static Venda[] lVendas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Vendas()
        {
            lVendas = new Venda[MAXVENDAS];
            for (int i = 0; i < MAXVENDAS; i++)
            {
                lVendas[i] = new Venda();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Venda[] LVendas
        {
            set { lVendas = value; }
            get { return lVendas; }
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
                foreach (Venda venda in lVendas)
                {
                    output += venda.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS

        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (lVendas[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar as vendas todas
        /// Retorna um array de strings com os dados de todos as vendas
        /// </summary>
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (j < Contar() && lVendas[i].Id != -1)
                {
                    output[j] = lVendas[i].Listar();
                    j++;
                }
                if (j == Contar() && lVendas[i].Id == -1)
                    break;
            }
            return output;
        }

        /// <summary>
        /// Método para adicionar uma venda
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Venda venda)
        {
            if (lVendas == null || venda is null || Existe(venda.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (lVendas[i].Id == -1)
                {
                    lVendas[i].Id = venda.Id;
                    lVendas[i].Bilhete = venda.Bilhete;
                    lVendas[i].NumBilhetes = venda.NumBilhetes;
                    lVendas[i].Valor = venda.Valor;
                    lVendas[i].DataVenda = venda.DataVenda;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de uma venda
        /// </summary>
        /// <param name="venda">Objeto do tipo venda</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Venda venda)
        {
            if (venda is null || lVendas == null || !Existe(venda.Id))
                return false;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (lVendas[i].Id == venda.Id)
                {
                    lVendas[i].Bilhete = venda.Bilhete;
                    lVendas[i].NumBilhetes = venda.NumBilhetes;
                    lVendas[i].Valor = venda.Valor;
                    lVendas[i].DataVenda = venda.DataVenda;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de uma venda
        /// </summary>
        /// <param name="venda">Identificador da venda</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int venda)
        {
            if (venda == -1 || lVendas == null || !Existe(venda))
                return false;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (lVendas[i].Id == venda)
                {
                    lVendas[i].Id = -1;
                    lVendas[i].Bilhete = -1;
                    lVendas[i].NumBilhetes = -1;
                    lVendas[i].Valor = -1;
                    lVendas[i].DataVenda = DateTime.MinValue;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma venda
        /// </summary>
        /// <param name="venda">Identificador da venda</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int venda)
        {
            if (venda == -1 || lVendas == null)
                return false;
            for (int i = 0; i < MAXVENDAS; i++)
            {
                if (lVendas[i].Id == venda)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion
    }
}
