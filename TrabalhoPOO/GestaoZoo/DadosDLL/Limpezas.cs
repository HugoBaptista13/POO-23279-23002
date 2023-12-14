using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar as limpezas
    /// </summary>
    public class Limpezas
    {
        #region ATRIBUTOS
        private const int MAXLIMPEZAS = 100;
        private static Limpeza[] lLimpezas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Limpezas()
        {
            lLimpezas = new Limpeza[MAXLIMPEZAS];
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                lLimpezas[i] = new Limpeza();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Limpeza[] LLimpezas
        {
            set { lLimpezas = value; }
            get { return lLimpezas; }
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
            if (obj is Limpezas e)
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
            string output = "";
            if (lLimpezas == null)
                return String.Format(output);
            else
            {
                foreach (Limpeza limpeza in lLimpezas)
                {
                    output += limpeza.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS

        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (lLimpezas[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar as limpezas todas
        /// Retorna um array de strings com os dados de todos os animais
        /// </summary
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (j < Contar() && lLimpezas[i].Id != -1)
                {
                    output[j] = lLimpezas[i].Listar();
                    j++;
                }
                if (j == Contar() && lLimpezas[i].Id == -1)
                    break;
            }
            return output;
        }
        /// <summary>
        /// Método para adicionar um funcionario, recebe um objeto do tipo funcionario com os dados do funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Limpeza limpeza)
        {
            if (lLimpezas == null || limpeza is null || Existe(limpeza.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (lLimpezas[i].Id == -1)
                {
                    lLimpezas[i].Id = limpeza.Id;
                    lLimpezas[i].Recinto = limpeza.Recinto;
                    lLimpezas[i].Funcionario = limpeza.Funcionario;
                    lLimpezas[i].Data = limpeza.Data;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de uma limpeza
        /// </summary>
        /// <param name="limpeza">Objeto do tipo limpeza</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Limpeza limpeza)
        {
            if (limpeza is null || lLimpezas == null || !Existe(limpeza.Id))
                return false;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            { 
                if (lLimpezas[i].Id == limpeza.Id)
                {
                    lLimpezas[i].Recinto = limpeza.Recinto;
                    lLimpezas[i].Funcionario = limpeza.Funcionario;
                    lLimpezas[i].Data = limpeza.Data;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de uma Limpeza
        /// </summary>
        /// <param name="limpeza">Identificador da limpeza</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int limpeza)
        {
            if (limpeza == -1 || lLimpezas == null || !Existe(limpeza))
                return false;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (lLimpezas[i].Id == limpeza)
                {
                    lLimpezas[i].Id = -1;
                    lLimpezas[i].Recinto = -1;
                    lLimpezas[i].Funcionario = -1;
                    lLimpezas[i].Data = DateTime.MinValue;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma Limpeza
        /// </summary>
        /// <param name="limpeza">Identificador da limpeza</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int limpeza)
        {
            if (limpeza == -1 || lLimpezas == null)
                return false;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (lLimpezas[i].Id == limpeza)
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
