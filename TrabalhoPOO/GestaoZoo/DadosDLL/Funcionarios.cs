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
    /// Classe para guardar os funcionários
    /// </summary>
    public class Funcionarios
    {
        #region ATRIBUTOS
        private const int MAXFUNCIONARIOS = 100;
        private static Funcionario[] lFuncionarios;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Funcionarios()
        {
            lFuncionarios = new Funcionario[MAXFUNCIONARIOS];
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                lFuncionarios[i] = new Funcionario();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Funcionario[] LFuncionarios
        {
            set { lFuncionarios = value; }
            get { return lFuncionarios; }
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
            if (obj is Funcionarios f)
            {
                if (this == f)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string output = "";
            if (LFuncionarios == null)
                return String.Format(output);
            else
            {
                foreach (Funcionario funcionario in lFuncionarios)
                {
                    output += funcionario.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar os funcionários todos
        /// Retorna um array de strings com os dados de todos os funcionários
        /// </summary>
        public string[] Listar()
        {
            int j = 0;
            string[] output = new string[100];
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (lFuncionarios[i].Id == -1)
                    for (int k = i; k < MAXFUNCIONARIOS; k++)
                    {
                        if (lFuncionarios[k].Id != -1)
                            break;
                        else
                            continue;
                    }
                output[j] = lFuncionarios[i].Listar();
                j++;
            }
            return output;
        }
        /// <summary>
        /// Método para adicionar um funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public bool Inserir(Funcionario funcionario)
        {
            if (lFuncionarios == null || funcionario == null)
            {
                return false;
            }
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (Existe(funcionario.Id))
                {
                    return false;
                }
                if (lFuncionarios[i].Id == -1)
                {
                    lFuncionarios[i].Id = funcionario.Id;
                    lFuncionarios[i].Nome = funcionario.Nome;
                    lFuncionarios[i].Idade = funcionario.Idade;
                    lFuncionarios[i].Telefone = funcionario.Telefone;
                    lFuncionarios[i].Email = funcionario.Email;
                    lFuncionarios[i].Cargo = funcionario.Cargo;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Funcionario funcionario)
        {
            if (funcionario == null || lFuncionarios == null)
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (!Existe(funcionario.Id))
                {
                    return false;
                }
                if (Existe(funcionario.Id))
                {
                    lFuncionarios[i].Nome = funcionario.Nome;
                    lFuncionarios[i].Idade = funcionario.Idade;
                    lFuncionarios[i].Telefone = funcionario.Telefone;
                    lFuncionarios[i].Email = funcionario.Email;
                    lFuncionarios[i].Cargo = funcionario.Cargo;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de um funcionario
        /// </summary>
        /// <param name="funcionario">Identificador do funcionario</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(int funcionario)
        {
            if (funcionario == -1 || lFuncionarios == null)
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (!Existe(funcionario))
                {
                    return false;
                }
                if (Existe(funcionario))
                {
                    lFuncionarios[i].Id = -1;
                    lFuncionarios[i].Nome = "";
                    lFuncionarios[i].Idade = -1;
                    lFuncionarios[i].Telefone = -1;
                    lFuncionarios[i].Email = "";
                    lFuncionarios[i].Cargo = "";
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um funcionario
        /// </summary>
        /// <param name="funcionario">Identificador do funcionario</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(int funcionario)
        {
            if (funcionario == -1 || lFuncionarios == null)
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (lFuncionarios[i].Id == funcionario)
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
