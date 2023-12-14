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
        private static Bilhete[] lBilhetes;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Bilhetes()
        {
            lBilhetes = new Bilhete[MAXBILHETES];
            for (int i = 0; i < MAXBILHETES; i++)
            {
                lBilhetes[i] = new Bilhete();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Bilhete[] LBilhetes
        {
            set { lBilhetes = value; }
            get { return lBilhetes; }
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
                foreach (Bilhete bilhete in lBilhetes)
                {
                    output += bilhete.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXBILHETES; i++)
            {
                if (lBilhetes[i].Id != -1)
                    c++;
            }
            return c;
        }

        /// <summary>
        /// Método para listar os bilhetes todos
        /// </summary>
        /// <param name="output">Array de strings com os bilhetes</param>
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXBILHETES; i++)
            {
                if (j < Contar() && lBilhetes[i].Id != -1)
                {
                    output[j] = lBilhetes[i].Listar();
                    j++;
                }
                if (j == Contar() && lBilhetes[i].Id == -1)
                    break;

            }
            return output;
        }
        public static bool Inserir(Bilhete bilhete)
        {
            if (lBilhetes == null || bilhete is null || Existe(bilhete.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXBILHETES; i++)
            {
                if (lBilhetes[i].Id == -1)
                {
                    lBilhetes[i].Id = bilhete.Id;
                    lBilhetes[i].Tipo = bilhete.Tipo;
                    lBilhetes[i].Preco = bilhete.Preco;
                    lBilhetes[i].Desconto = bilhete.Desconto;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um bilhete
        /// </summary>
        /// <param name="bilhete">Objeto do tipo bilhete</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Bilhete bilhete)
        {
            if (bilhete is null || lBilhetes == null || !Existe(bilhete.Id))
                return false;
            for (int i = 0; i < MAXBILHETES; i++)
            {
                if (lBilhetes[i].Id == bilhete.Id)
                {
                    lBilhetes[i].Id = bilhete.Id;
                    lBilhetes[i].Tipo = bilhete.Tipo;
                    lBilhetes[i].Preco = bilhete.Preco;
                    lBilhetes[i].Desconto = bilhete.Desconto;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de um bilhete, recebe o identificador do bilhete
        /// </summary>
        /// <param name="bilhete">Identificar do bilhete</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int bilhete)
        {
            if (bilhete == -1 || lBilhetes == null || !Existe(bilhete))
                return false;
            for (int i = 0; i < MAXBILHETES; i++)
            {
                if (lBilhetes[i].Id == bilhete)
                {
                    lBilhetes[i].Id = -1;
                    lBilhetes[i].Tipo = "";
                    lBilhetes[i].Preco = -1;
                    lBilhetes[i].Desconto = -1;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um bilhete
        /// </summary>
        /// <param name="bilhete">identificador do bilhete</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int bilhete)
        {
            if (bilhete == -1 || lBilhetes == null)
                return false;
            for (int i = 0; i < MAXBILHETES; i++)
            {
                if (lBilhetes[i].Id == bilhete)
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
