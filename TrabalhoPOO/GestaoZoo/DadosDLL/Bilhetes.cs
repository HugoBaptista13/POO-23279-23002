using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar os bilhetes
    /// </summary>
    public class Bilhetes
    {
        #region ATRIBUTOS
        private const int MAXBILHETES = 100;
        private static Bilhete[] l_bilhetes;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Bilhetes()
        {
            for (int i = 0; i < MAXBILHETES; i++)
            {
                l_bilhetes[i] = new Bilhete();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Bilhete[] LBilhetes
        {
            set { l_bilhetes = value; }
            get { return l_bilhetes; }
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
            if (obj is Bilhetes b)
            {
                if (this == b)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string output = "";
            if (LBilhetes == null)
                return String.Format(output);
            else
            {
                foreach (Bilhete bilhete in l_bilhetes)
                {
                    output += bilhete.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar os bilhetes todos
        /// </summary>
        /// <param name="output">Array de strings com os bilhetes</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Bilhete bilhete in l_bilhetes)
            {
                if (bilhete.Id == -1)
                    continue;
                output[i] = bilhete.Listar();
                i++;
            }
        }
        #endregion
        #endregion
    }
}
