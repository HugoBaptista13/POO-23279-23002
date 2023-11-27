using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    public class Comidas
    {
        #region ATRIBUTOS
        private const int MAXCOMIDA = 100;
        private static Comida[] l_comidas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Comidas()
        {
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                l_comidas[i] = new Comida();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Comida[] LComidas
        {
            set { l_comidas = value; }
            get { return l_comidas; }
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
            if (obj is Comidas c)
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
            string output = "";
            if (LComidas == null)
                return String.Format(output);
            else
            {
                foreach (Comida comida in l_comidas)
                {
                    output += comida.Listar();
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
            foreach (Comida comida in l_comidas)
            {
                if (comida.Id == -1)
                    continue;
                output[i] = comida.Listar();
                i++;
            }
        }
        #endregion
        #endregion
    }
}
