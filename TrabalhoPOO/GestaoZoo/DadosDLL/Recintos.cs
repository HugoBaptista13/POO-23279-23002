using System;
using System.Collections.Generic;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar os recintos
    /// </summary>
    [Serializable]
    public class Recintos 
    {
        #region ATRIBUTOS
        private static List<Recinto> lRecintos;
        [NonSerialized]
        private const int MAXRECINTOS = 100;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Recintos()
        {
            lRecintos = new List<Recinto>();
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                lRecintos.Add(new Recinto());
            }
        }
        #endregion
        #region PROPRIEDADES
        public static List<Recinto> LRecintos
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

        /// <summary>
        /// Método para contar os recintos que existem
        /// </summary>
        /// <returns>Retorna o número de recintos existentes</returns>
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
        /// Retorna uma lista com os dados dos recintos 
        /// </summary>
        public static List<Recinto> Listar()
        {
            int j = 0;
            List<Recinto> output = new List<Recinto>();
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (j < Contar() && lRecintos[i].Id != -1)
                {
                    output.Add(lRecintos[i]);
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
        /// <summary>
        /// Método para procurar um recinto, recebe o identificador do recinto
        /// </summary>
        /// <param name="recinto">Identificador do recinto</param>
        /// <param name="output">Objeto do tipo recinto</param>
        /// <returns>Retorna true quando encontra o objeto a procurar, se não conseguir retorna false</returns>
        public static bool Procurar(int recinto, out Recinto output)
        {
            output = new Recinto();
            if (recinto == -1 || lRecintos == null || !Existe(recinto))
                return false;
            for (int i = 0; i < MAXRECINTOS; i++)
            {
                if (lRecintos[i].Id == recinto)
                {
                    output = new Recinto(lRecintos[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion
    }
}
