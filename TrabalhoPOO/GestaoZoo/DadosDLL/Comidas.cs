using System;
using System.Collections.Generic;
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
        private static List<Comida> lComidas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Comidas()
        {
            lComidas = new List<Comida>();
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                lComidas.Add(new Comida());
            }
        }
        #endregion
        #region PROPRIEDADES
        public static List<Comida> LComidas
        {
            set { lComidas = value; }
            get { return lComidas; }
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
                foreach (Comida comida in lComidas)
                {
                    output += comida.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para contar as comidas que existem
        /// </summary>
        /// <returns>Retorna o número de comidas existentes</returns>
        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (lComidas[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar as comidas todos
        /// Retorna uma lista com os dados das comidas
        /// </summary>
        public static List<Comida> Listar()
        {
            int j = 0;
            List<Comida> output = new List<Comida>();
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (j < Contar() && lComidas[i].Id != -1)
                {
                    output.Add(lComidas[i]);
                    j++;
                }
                if (j == Contar() && lComidas[i].Id == -1)
                    break;

            }
            return output;
        }
        /// <summary>
        /// Método para adicionar uma comida, recebe um objeto do tipo comida com os dados da comida
        /// </summary>
        /// <param name="comida">Objeto do tipo comida</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Comida comida)
        {
            if (lComidas == null || comida is null || Existe(comida.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (lComidas[i].Id == -1)
                {
                    lComidas[i].Id = comida.Id;
                    lComidas[i].Nome = comida.Nome;
                    lComidas[i].Tipo = comida.Tipo;
                    lComidas[i].Dieta = comida.Dieta;
                    lComidas[i].Stock = comida.Stock;
                    lComidas[i].DataValidade = comida.DataValidade;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de uma comida
        /// </summary>
        /// <param name="comida">Objeto do tipo comida</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Comida comida)
        {
            if (comida is null || lComidas == null || !Existe(comida.Id))
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (lComidas[i].Id == comida.Id)
                {
                    lComidas[i].Id = comida.Id;
                    lComidas[i].Nome = comida.Nome;
                    lComidas[i].Tipo = comida.Tipo;
                    lComidas[i].Dieta = comida.Dieta;
                    lComidas[i].Stock = comida.Stock;
                    lComidas[i].DataValidade = comida.DataValidade;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para remover os dados de uma comida, recebe o identificador da comida
        /// </summary>
        /// <param name="comida">Identificador da comida</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int comida)
        {
            if (comida == -1 || lComidas == null || !Existe(comida))
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (lComidas[i].Id == comida)
                {
                    return false;
                }
                if (lComidas[i].Id == comida)
                {
                    lComidas[i].Id = -1;
                    lComidas[i].Nome = "";
                    lComidas[i].Tipo = "";
                    lComidas[i].Dieta = "";
                    lComidas[i].Stock = -1;
                    lComidas[i].DataValidade = DateTime.MinValue;

                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma comida
        /// </summary>
        /// <param name="comida">identificador da comida</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int comida)
        {
            if (comida == -1 || lComidas == null)
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (lComidas[i].Id == comida)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Método para procurar uma comida, recebe o identificador da comida
        /// </summary>
        /// <param name="comida">Identificador da comida</param>
        /// <param name="output">Objeto do tipo comida</param>
        /// <returns>Retorna true quando retorna encontra o objeto a procurar, se não conseguir retorna false</returns>
        public static bool Procurar(int comida, out Comida output)
        {
            output = new Comida();
            if (comida == -1 || lComidas == null || !Existe(comida))
                return false;
            for (int i = 0; i < MAXCOMIDA; i++)
            {
                if (lComidas[i].Id == comida)
                {
                    output = new Comida(lComidas[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion
    }
}
