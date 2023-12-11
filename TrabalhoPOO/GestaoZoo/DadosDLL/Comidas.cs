using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar as comidas
    /// </summary>
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
        /// Método para listar as comidas todas
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
        public bool Inserir(Comida comida)
        {
            if (l_comidas == null || comida == null)
            {
                return false;
            }
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (l_comidas[i] == comida)
                {
                    return false;
                }
                if (l_comidas[i].Id == -1)
                {
                    l_comidas[i].Id = comida.Id;
                    l_comidas[i].Nome = comida.Nome;
                    l_comidas[i].Tipo = comida.Tipo;
                    l_comidas[i].Dieta = comida.Dieta;
                    l_comidas[i].Stock = comida.Stock;
                    l_comidas[i].DataValidade = comida.DataValidade;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de uma comida
        /// </summary>
        /// <param name="comida">Objeto do tipo comida</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Comida comida)
        {
            if (comida == null || l_comidas == null)
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (l_comidas[i] != comida)
                {
                    return false;
                }
                if (l_comidas[i].Id == comida.Id)
                {
                    l_comidas[i].Id = comida.Id;
                    l_comidas[i].Nome = comida.Nome;
                    l_comidas[i].Tipo = comida.Tipo;
                    l_comidas[i].Dieta = comida.Dieta;
                    l_comidas[i].Stock = comida.Stock;
                    l_comidas[i].DataValidade = comida.DataValidade;
                }
            }
            return true;
        }
        public bool Remover(Comida comida)
        {
            if (comida == null || l_comidas == null)
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (l_comidas[i] != comida)
                {
                    return false;
                }
                if (l_comidas[i].Id == comida.Id)
                {
                    l_comidas[i].Id = -1;
                    l_comidas[i].Nome = "";
                    l_comidas[i].Tipo = "";
                    l_comidas[i].Dieta = "";
                    l_comidas[i].Stock = -1;
                    l_comidas[i].DataValidade = DateTime.MinValue;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma comida
        /// </summary>
        /// <param name="comida">Objeto do tipo comida</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(Comida comida)
        {
            if (comida == null || l_comidas == null)
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (l_comidas[i] != comida)
                {
                    return false;
                }
                if (l_comidas[i].Id == comida.Id)
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
