using DadosDLL;
using ExcecaoDLL;
using FilesDLL;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using ZooDLL;

namespace RegrasDLL
{
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasFuncionarios
    {
        #region OUTROS
        private static readonly string[] cargos = { "Veterinário", "Tratador", "Zelador", "Rececionista" };
        private static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) || c != ' ')
                    return false;
            }
            return true;
        }
        private static bool IsValidEmail(string email)
        {
            if (email.EndsWith("."))
            {
                return false;
            }
            try
            {
                MailAddress addr = new MailAddress(email);
                return (addr.Address == email);
            }
            catch
            {
                return false;
            }
        }
        private static bool IsValidPhone(int phone)
        {
            if (phone.ToString().Length != 9)
                return false;
            return true;
        }
        private static bool IsValidRole(string role)
        {
            foreach (string cargo in cargos)
            {
                if (cargo == role)
                    return true;
            }
            return false;
        }
        #endregion
        #region Inserir
        public static bool Inserir(Funcionario funcionario)
        {
            /// <summary>
            /// 1º fase de validações
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
            /// 2º fase de validações
            /// </summary>
            try
            {
                if (!IsAllLetters(funcionario.Nome.Trim()) || funcionario.Nome == string.Empty)
                    throw new InvalidNameException(funcionario.Nome.Trim());

                if (funcionario.Email == string.Empty)
                    throw new InvalidTextException(funcionario.Email.Trim());

                if (!IsAllLetters(funcionario.Cargo.Trim()) || funcionario.Cargo == string.Empty)
                    throw new InvalidTextException(funcionario.Cargo.Trim());

                if (!IsValidEmail(funcionario.Email.Trim()))
                    throw new InvalidEmailException(funcionario.Email.Trim());

                if (!IsValidPhone(funcionario.Telefone))
                    throw new InvalidPhoneException(funcionario.Telefone.ToString());

                if (!IsValidRole(funcionario.Cargo.Trim()))
                    throw new InvalidRoleException(funcionario.Cargo.Trim());
            } 
            catch
            {
                return false;
            }
            /// <summary>
            /// 3º fase de validações
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
        public static bool Alterar(Funcionario funcionario)
        {
            /// <summary>
            /// 1º fase de validações
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
            /// 2º fase de validações
            /// </summary>
            try
            {
                if (!IsAllLetters(funcionario.Nome.Trim()) || funcionario.Nome == string.Empty)
                    throw new InvalidNameException(funcionario.Nome.Trim());

                if (funcionario.Email == string.Empty)
                    throw new InvalidTextException(funcionario.Email.Trim());

                if (!IsAllLetters(funcionario.Cargo.Trim()) || funcionario.Cargo == string.Empty)
                    throw new InvalidTextException(funcionario.Cargo.Trim());

                if (!IsValidEmail(funcionario.Email.Trim()))
                    throw new InvalidEmailException(funcionario.Email.Trim());

                if (!IsValidPhone(funcionario.Telefone))
                    throw new InvalidPhoneException(funcionario.Telefone.ToString());

                if (!IsValidRole(funcionario.Cargo.Trim()))
                    throw new InvalidRoleException(funcionario.Cargo.Trim());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 3º fase de validações
            /// </summary>
            try
            {
                if (!Funcionarios.Existe(funcionario.Id))
                    throw new DoesNotExistException(funcionario.Id.ToString());
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
        #region Remover
        public static bool Remover(int funcionario)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (funcionario <= 0)
                    throw new InvalidIDException(funcionario.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Funcionarios.Existe(funcionario))
                    throw new DoesNotExistException(funcionario.ToString());
            }
            catch
            {
                return false;
            }
            if (!Funcionarios.Remover(funcionario))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int funcionario, out Funcionario output)
        {
            output = null;
            /// <summary
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (funcionario <= 0)
                    throw new InvalidIDException(funcionario.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary
            /// 2º fase de validações
            /// </summary>
            try
            {
                if (!Funcionarios.Existe(funcionario))
                    throw new DoesNotExistException(funcionario.ToString());
            }
            catch
            {
                return false;
            }
            if (!Funcionarios.Procurar(funcionario, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int funcionario)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (funcionario <= 0)
                    throw new InvalidIDException(funcionario.ToString());
            }
            catch
            {
                return false;
            }
            if (!Funcionarios.Existe(funcionario))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Funcionario> lFuncionarios)
        {
            bool aux = true;
            try
            {
                if (lFuncionarios == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileFuncionario.Guardar(lFuncionarios, out string ex))
                    aux = false;
                if (ex != string.Empty)
                    throw new Exception(ex);
            }
            catch
            {
                return false;
            }
            return aux;
        }
        #endregion
        #region Carregar
        public static bool Carregar(out List<Funcionario> lFuncionarios, out string ex)
        {
            lFuncionarios = null;
            ex = string.Empty;
            try
            {
                if (!FileFuncionario.Carregar(out lFuncionarios, out ex))
                    return false;
                if (ex != string.Empty)
                    throw new Exception(ex);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
