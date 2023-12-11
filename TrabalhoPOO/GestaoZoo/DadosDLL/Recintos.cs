using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar os recintos
    /// </summary>
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
        /// Método para listar os recintos todos
        /// </summary>
        /// <param name="output">Array de strings com os recintos</param>
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

        /// <summary>
        /// Método para adicionar um recinto
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public bool Inserir(Recinto recinto)
        {
            if (l_recintos == null || recinto == null)
            {
                return false;
            }
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (l_recintos[i] == recinto)
                {
                    return false;
                }
                if (l_recintos[i].Id == -1)
                {
                    l_recintos[i].Id = recinto.Id;
                    l_recintos[i].Nome = recinto.Nome;
                    l_recintos[i].Tipo = recinto.Tipo;
                    l_recintos[i].Comprimento = recinto.Comprimento;
                    l_recintos[i].Largura = recinto.Largura;
                    l_recintos[i].Altura = recinto.Altura;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um recinto
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Recinto recinto)
        {
            if (recinto == null || l_recintos == null)
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (l_recintos[i] != recinto)
                {
                    return false;
                }
                if (l_recintos[i].Id == recinto.Id)
                {
                    l_recintos[i].Nome = recinto.Nome;
                    l_recintos[i].Tipo = recinto.Tipo;
                    l_recintos[i].Comprimento = recinto.Comprimento;
                    l_recintos[i].Largura = recinto.Largura;
                    l_recintos[i].Altura = recinto.Altura;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de um recinto
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(int recinto)
        {
            if (recinto == -1 || l_recintos == null)
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (l_recintos[i].Id != recinto)
                {
                    return false;
                }
                if (l_recintos[i].Id == recinto)
                {
                    l_recintos[i].Id = -1;
                    l_recintos[i].Nome = "";
                    l_recintos[i].Tipo = "";
                    l_recintos[i].Comprimento = -1;
                    l_recintos[i].Largura = -1;
                    l_recintos[i].Altura = -1;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um recinto
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(int recinto)
        {
            if (recinto == -1 || l_recintos == null)
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (l_recintos[i].Id != recinto)
                {
                    return false;
                }
                if (l_recintos[i].Id == recinto)
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
