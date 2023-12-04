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
        private static Funcionario[] l_funcionarios;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Funcionarios()
        {
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                l_funcionarios[i] = new Funcionario();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Funcionario[] LFuncionarios
        {
            set { l_funcionarios = value; }
            get { return l_funcionarios; }
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
                foreach (Funcionario funcionario in l_funcionarios)
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
        /// </summary>
        /// <param name="output">Array de strings com os funcionários</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Funcionario funcionario in l_funcionarios)
            {
                if (funcionario.Id == -1)
                    continue;
                output[i] = funcionario.Listar();
                i++;
            }
        }
        /// <summary>
        /// Método para adicionar um funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public bool Inserir(Funcionario funcionario)
        {
            if (l_funcionarios == null || funcionario == null)
            {
                return false;
            }
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (l_funcionarios[i] == funcionario)
                {
                    return false;
                }
                if (l_funcionarios[i].Id == -1)
                {
                    l_funcionarios[i].Id = funcionario.Id;
                    l_funcionarios[i].Nome = funcionario.Nome;
                    l_funcionarios[i].Idade = funcionario.Idade;
                    l_funcionarios[i].Telefone = funcionario.Telefone;
                    l_funcionarios[i].Email = funcionario.Email;
                    l_funcionarios[i].Cargo = funcionario.Cargo;
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
            if (funcionario == null || l_funcionarios == null)
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (l_funcionarios[i] != funcionario)
                {
                    return false;
                }
                if (l_funcionarios[i].Id == funcionario.Id)
                {
                    l_funcionarios[i].Id = funcionario.Id;
                    l_funcionarios[i].Nome = funcionario.Nome;
                    l_funcionarios[i].Idade = funcionario.Idade;
                    l_funcionarios[i].Telefone = funcionario.Telefone;
                    l_funcionarios[i].Email = funcionario.Email;
                    l_funcionarios[i].Cargo = funcionario.Cargo;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de um Funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(Funcionario funcionario)
        {
            if (funcionario == null || l_funcionarios == null)
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (l_funcionarios[i] != funcionario)
                {
                    return false;
                }
                if (l_funcionarios[i].Id == funcionario.Id)
                {
                    l_funcionarios[i].Id = -1;
                    l_funcionarios[i].Nome = "";
                    l_funcionarios[i].Idade = -1;
                    l_funcionarios[i].Telefone = -1;
                    l_funcionarios[i].Email = "";
                    l_funcionarios[i].Cargo = "";
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo animal</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(Funcionario funcionario)
        {
            if (funcionario == null || l_funcionarios == null)
                return false;
            for (int i = 0; i < MAXFUNCIONARIOS; i++)
            {
                if (l_funcionarios[i] != funcionario)
                {
                    return false;
                }
                if (l_funcionarios[i].Id == funcionario.Id)
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
