using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    public class Recintos
    {
        #region ATRIBUTOS
        private const int MAXRECINTOS = 100;
        private static Recinto[] l_recintos;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Recintos()
        {
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                l_recintos[i] = new Recinto();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Recinto[] LRecinto
        {
            set { l_recintos = value; }
            get { return l_recintos; }
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
            if (obj is Recintos r)
            {
                if (this == r)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string output = "";
            if (LRecinto == null)
                return String.Format(output);
            else
            {
                foreach (Recinto recinto in l_recintos)
                {
                    output += recinto.Listar();
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
            foreach (Recinto recinto in l_recintos)
            {
                if (recinto.Id == -1)
                    continue;
                output[i] = recinto.Listar();
                i++;
            }
        }
        #endregion
        #endregion
    }
}
