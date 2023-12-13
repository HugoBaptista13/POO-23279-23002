using InterfaceDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar os animais todos
    /// </summary>
    public class Animais
    {
        #region ATRIBUTOS
        private const int MAXANIMAIS = 100;
        private static Animal[] lAnimais;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Animais()
        {
           lAnimais = new Animal[MAXANIMAIS];  
           for (int i = 0; i < MAXANIMAIS; i++) 
           {
                lAnimais[i] = new Animal();     
           }
        }
        #endregion
        #region PROPRIEDADES
        public static Animal[] LAnimais
        {
            set { lAnimais = value; }
            get { return lAnimais; }
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
            if (lAnimais == null)
                return String.Format(output);
            else
            {
                foreach (Animal animal in lAnimais)
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
        /// Retorna um array de strings com os dados de todos os animais
        /// </summary>
        public string[] Listar()
        {
            int j = 0;
            string[] output = new string[100];
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (lAnimais[i].Id == -1)
                    for (int k = i; k < MAXANIMAIS; k++)
                    {
                        if (lAnimais[k].Id != -1)
                            break;
                        else
                            continue;
                    }
                output[j] = lAnimais[i].Listar();
                j++;
            }
            return output;
        }
        /// <summary>
        /// Método para adicionar um animal, recebe um objeto do tipo animal com os dados do animal
        /// </summary>
        /// <param name="animal">Objeto do tipo animal</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public bool Inserir(Animal animal)
        {
            if (lAnimais==null || animal == null)
            {
                return false;
            }
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (Existe(animal.Id))
                {
                    return false;
                }
                if (lAnimais[i].Id == -1)
                {
                    lAnimais[i].Id = animal.Id;
                    lAnimais[i].Nome = animal.Nome;
                    lAnimais[i].Idade = animal.Idade;
                    lAnimais[i].Sexo = animal.Sexo;
                    lAnimais[i].Classe = animal.Classe;
                    lAnimais[i].Especie = animal.Especie;
                    lAnimais[i].Dieta = animal.Dieta;
                    lAnimais[i].Estado = animal.Estado;
                    lAnimais[i].DataUltimaConsulta = animal.DataUltimaConsulta;
                    lAnimais[i].DataProximaConsulta = animal.DataProximaConsulta;
                    lAnimais[i].Recinto = animal.Recinto;
                    lAnimais[i].Descricao = animal.Descricao;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um animal, recebe um objeto do tipo animal com os novos dados do animal
        /// </summary>
        /// <param name="animal">Objeto do tipo animal</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Animal animal)
        {
            if (animal == null || lAnimais == null) 
                return false;
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (!Existe(animal.Id))
                {
                    return false;
                }
                if (Existe(animal.Id))
                {
                    lAnimais[i].Nome = animal.Nome;
                    lAnimais[i].Idade = animal.Idade;
                    lAnimais[i].Sexo = animal.Sexo;
                    lAnimais[i].Classe = animal.Classe;
                    lAnimais[i].Especie = animal.Especie;
                    lAnimais[i].Dieta = animal.Dieta;
                    lAnimais[i].Estado = animal.Estado;
                    lAnimais[i].DataUltimaConsulta = animal.DataUltimaConsulta;
                    lAnimais[i].DataProximaConsulta = animal.DataProximaConsulta;
                    lAnimais[i].Recinto = animal.Recinto;
                    lAnimais[i].Descricao = animal.Descricao;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para remover os dados de um animal, recebe o identificador do animal
        /// </summary>
        /// <param name="animal">Identificar do animal</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(int animal)
        {
            if (animal == -1 || lAnimais == null)
                return false;
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (!Existe(animal))
                {
                    return false;
                }
                if (Existe(animal))
                {
                    lAnimais[i].Id = -1;
                    lAnimais[i].Nome = "";
                    lAnimais[i].Idade = -1;
                    lAnimais[i].Sexo = "";
                    lAnimais[i].Classe = "";
                    lAnimais[i].Especie = "";
                    lAnimais[i].Dieta = "";
                    lAnimais[i].Estado = -1;
                    lAnimais[i].DataUltimaConsulta = DateTime.MinValue;
                    lAnimais[i].DataProximaConsulta = DateTime.MinValue;
                    lAnimais[i].Recinto = "";
                    lAnimais[i].Descricao = "";
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um animal, recebe o identificador do animal
        /// </summary>
        /// <param name="animal">Identificador do animal</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(int animal)
        {
            if (animal == -1 || lAnimais == null)
                return false;
            for (int i = 0; i < MAXANIMAIS; i++)
            {
                if (lAnimais[i].Id == animal)
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
