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

        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (lFuncionarios[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar os funcionários todos
        /// Retorna um array de strings com os dados de todos os funcionários
        /// </summary>
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (j < Contar() && lFuncionarios[i].Id != -1)
                {
                    output[j] = lFuncionarios[i].Listar();
                    j++;
                }
                if (j == Contar() && lFuncionarios[i].Id == -1)
                    break;

            }
            return output;
        }
        /// <summary>
        /// Método para adicionar um funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Funcionario funcionario)
        {
            if (lFuncionarios == null || funcionario is null || Existe(funcionario.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
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
        public static bool Alterar(Funcionario funcionario)
        {
            if (funcionario is null || lFuncionarios == null || !Existe(funcionario.Id))
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (lFuncionarios[i].Id == funcionario.Id)
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
        public static bool Remover(int funcionario)
        {
            if (funcionario == -1 || lFuncionarios == null || !Existe(funcionario))
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (lFuncionarios[i].Id == funcionario)
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
        public static bool Existe(int funcionario)
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
