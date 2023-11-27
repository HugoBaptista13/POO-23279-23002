using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    /// <summary>
    /// Classe para guardar os animais
    /// </summary>
    public class Animais
    {
        #region ATRIBUTOS
        private const int MAXANIMAIS = 100;
        private static Animal[] l_animais;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Animais()
        {
           for (int i = 0; i < MAXANIMAIS; i++) 
           {
                l_animais[i] = new Animal();     
           }
        }
        #endregion
        #region PROPRIEDADES
        public static Animal[] LAnimais
        {
            set { l_animais = value; }
            get { return l_animais; }
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
            if (obj is Animais a)
            {
                if (this == a)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string output = "";
            if (l_animais == null)
                return String.Format(output);
            else
            {
                foreach (Animal animal in l_animais)
                {
                    output += animal.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar os animais todos
        /// </summary>
        /// <param name="output">Array de strings com os animais</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Animal animal in l_animais)
            {
                if (animal.Id == -1)
                    break;
                output[i] = animal.Listar();
                i++;
            }
        }
        /// <summary>
        /// Método para adicionar um animal
        /// </summary>
        /// <param name="animal">Objeto do tipo animal</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public bool Inserir(Animal animal)
        {
            if (l_animais==null || animal == null)
            {
                return false;
            }
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (l_animais[i] == animal)
                {
                    return false;
                }
                if (l_animais[i].Id == -1)
                {
                    l_animais[i].Id = animal.Id;
                    l_animais[i].Nome = animal.Nome;
                    l_animais[i].Idade = animal.Idade;
                    l_animais[i].Sexo = animal.Sexo;
                    l_animais[i].Classe = animal.Classe;
                    l_animais[i].Especie = animal.Especie;
                    l_animais[i].Dieta = animal.Dieta;
                    l_animais[i].Estado = animal.Estado;
                    l_animais[i].DataUltimaConsulta = animal.DataUltimaConsulta;
                    l_animais[i].DataProximaConsulta = animal.DataProximaConsulta;
                    l_animais[i].Recinto = animal.Recinto;
                    l_animais[i].Descricao = animal.Descricao;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um animal
        /// </summary>
        /// <param name="animal">Objeto do tipo animal</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Animal animal)
        {
            if (animal == null || l_animais == null) 
                return false;
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (l_animais[i] != animal)
                {
                    return false;
                }
                if (l_animais[i].Id == animal.Id)
                {
                    l_animais[i].Id = animal.Id;
                    l_animais[i].Nome = animal.Nome;
                    l_animais[i].Idade = animal.Idade;
                    l_animais[i].Sexo = animal.Sexo;
                    l_animais[i].Classe = animal.Classe;
                    l_animais[i].Especie = animal.Especie;
                    l_animais[i].Dieta = animal.Dieta;
                    l_animais[i].Estado = animal.Estado;
                    l_animais[i].DataUltimaConsulta = animal.DataUltimaConsulta;
                    l_animais[i].DataProximaConsulta = animal.DataProximaConsulta;
                    l_animais[i].Recinto = animal.Recinto;
                    l_animais[i].Descricao = animal.Descricao;
                }
            }
            return true;
        }
        #endregion
        #endregion
    }
}
