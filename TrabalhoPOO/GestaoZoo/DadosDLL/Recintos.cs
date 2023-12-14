using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;
using InterfaceDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar os recintos
    /// </summary>
    public class Recintos 
    {
        #region ATRIBUTOS
        private const int MAXRECINTOS = 100;
        private static Recinto[] lRecintos;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Recintos()
        {
            lRecintos = new Recinto[MAXRECINTOS];
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                lRecintos[i] = new Recinto();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Recinto[] LRecintos
        {
            set { lRecintos = value; }
            get { return lRecintos; }
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
            if (LRecintos == null)
                return String.Format(output);
            else
            {
                foreach (Recinto recinto in lRecintos)
                {
                    output += recinto.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS

        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (lRecintos[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar os recintos todos
        /// Retorna um array de strings com os dados de todos os recintos 
        /// </summary>
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (j < Contar() && lRecintos[i].Id != -1)
                {
                    output[j] = lRecintos[i].Listar();
                    j++;
                }
                if (j == Contar() && lRecintos[i].Id == -1)
                    break;
            }
            return output;
        }

        /// <summary>
        /// Método para adicionar um recinto
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Recinto recinto)
        {
            if (lRecintos == null || recinto is null || Existe(recinto.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (lRecintos[i].Id == -1)
                {
                    lRecintos[i].Id = recinto.Id;
                    lRecintos[i].Nome = recinto.Nome;
                    lRecintos[i].Tipo = recinto.Tipo;
                    lRecintos[i].Comprimento = recinto.Comprimento;
                    lRecintos[i].Largura = recinto.Largura;
                    lRecintos[i].Altura = recinto.Altura;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um recinto
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Recinto recinto)
        {
            if (recinto is null || lRecintos == null || !Existe(recinto.Id))
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (lRecintos[i].Id == recinto.Id)
                {
                    lRecintos[i].Nome = recinto.Nome;
                    lRecintos[i].Tipo = recinto.Tipo;
                    lRecintos[i].Comprimento = recinto.Comprimento;
                    lRecintos[i].Largura = recinto.Largura;
                    lRecintos[i].Altura = recinto.Altura;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de um recinto
        /// </summary>
        /// <param name="recinto">Identificador do recinto</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int recinto)
        {
            if (recinto == -1 || lRecintos == null || !Existe(recinto))
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (lRecintos[i].Id == recinto) 
                {
                    lRecintos[i].Id = -1;
                    lRecintos[i].Nome = "";
                    lRecintos[i].Tipo = "";
                    lRecintos[i].Comprimento = -1;
                    lRecintos[i].Largura = -1;
                    lRecintos[i].Altura = -1;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um recinto
        /// </summary>
        /// <param name="recinto">Identificador do recinto</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int recinto)
        {
            if (recinto == -1 || lRecintos == null)
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (lRecintos[i].Id == recinto)
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
