using DadosDLL;
using ExcecaoDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace RegrasDLL
{
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasFuncionarios
    {
        #region outros
        private static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) || c != ' ')
                    return false;
            }
            return true;
        }
        #endregion
        #region Inserir
        public static bool Inserir(Funcionario funcionario)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (funcionario == null)
                    throw new ArgumentNullException("Funcionario", "Funcionario não pode ser nulo");

                if (funcionario.Id <= 0)
                    throw new InvalidIDException(funcionario.Id.ToString());

                if (funcionario.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (funcionario.Idade <= 0)
                    throw new NegativeNumberException(funcionario.Idade.ToString());

                if (funcionario.Telefone <= 0)
                    throw new NegativeNumberException(funcionario.Telefone.ToString());

                if (funcionario.Email == null)
                    throw new ArgumentNullException("Email", "Email não pode ser nulo");

                if (funcionario.Cargo == null)
                    throw new ArgumentNullException("Cargo", "Cargo não pode ser nulo");
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (!IsAllLetters(funcionario.Nome.Trim()) || funcionario.Nome == string.Empty)
                    throw new InvalidNameException(funcionario.Nome.Trim());
                if (!IsAllLetters(funcionario.Email.Trim()) || funcionario.Email == string.Empty)
                    throw new InvalidTextException(funcionario.Email.Trim());
                if (!IsAllLetters(funcionario.Cargo.Trim()) || funcionario.Cargo == string.Empty)
                    throw new InvalidTextException(funcionario.Cargo.Trim());
            } 
            catch
            {
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            try
            {

                if (Funcionarios.Existe(funcionario.Id))
                    throw new AlreadyExistsException(funcionario.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Funcionarios.Inserir(funcionario))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
}
