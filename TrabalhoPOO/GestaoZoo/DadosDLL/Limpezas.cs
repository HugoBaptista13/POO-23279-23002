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
        private static Limpeza[] l_limpezas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Limpezas()
        {
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                l_limpezas[i] = new Limpeza();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Limpeza[] LLimpezas
        {
            set { l_limpezas = value; }
            get { return l_limpezas; }
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
            if (LLimpezas == null)
                return String.Format(output);
            else
            {
                foreach (Limpeza limpeza in l_limpezas)
                {
                    output += limpeza.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar as limpezas todas
        /// </summary>
        /// <param name="output">Array de strings com as limpezas</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Limpeza limpeza in l_limpezas)
            {
                if (limpeza.Id == -1)
                    continue;
                output[i] = limpeza.Listar();
                i++;
            }
        }

        public bool Inserir(Limpeza limpeza)
        {
            if (l_limpezas == null || limpeza == null)
            {
                return false;
            }
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (l_limpezas[i] == limpeza)
                {
                    return false;
                }
                if (l_limpezas[i].Id == -1)
                {
                    l_limpezas[i].Id = limpeza.Id;
                    l_limpezas[i].Recinto = limpeza.Recinto;
                    l_limpezas[i].Funcionario = limpeza.Funcionario;
                    l_limpezas[i].Data = limpeza.Data;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de uma limpeza
        /// </summary>
        /// <param name="limpeza">Objeto do tipo limpeza</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Limpeza limpeza)
        {
            if (limpeza == null || l_limpezas == null)
                return false;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (l_limpezas[i] != limpeza)
                {
                    return false;
                }
                if (l_limpezas[i].Id == limpeza.Id)
                {
                    l_limpezas[i].Recinto = limpeza.Recinto;
                    l_limpezas[i].Funcionario = limpeza.Funcionario;
                    l_limpezas[i].Data = limpeza.Data;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de uma Limpeza
        /// </summary>
        /// <param name="limpeza">Objeto do tipo limpeza</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(int limpeza)
        {
            if (limpeza == -1 || l_limpezas == null)
                return false;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (l_limpezas[i].Id != limpeza)
                {
                    return false;
                }
                if (l_limpezas[i].Id == limpeza)
                {
                    l_limpezas[i].Id = -1;
                    l_limpezas[i].Recinto = -1;
                    l_limpezas[i].Funcionario = -1;
                    l_limpezas[i].Data = DateTime.MinValue;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma Limpeza
        /// </summary>
        /// <param name="limpeza">Objeto do tipo limpeza</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(int limpeza)
        {
            if (limpeza == -1 || l_limpezas == null)
                return false;
            for (int i = 0; i < MAXLIMPEZAS; i++)
            {
                if (l_limpezas[i].Id != limpeza)
                {
                    return false;
                }
                if (l_limpezas[i].Id == limpeza)
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
