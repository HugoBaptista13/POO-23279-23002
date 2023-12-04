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
        #endregion
        #endregion
    }
}
