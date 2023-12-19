using DadosDLL;
using ExcecaoDLL;
using FilesDLL;
using System;
using System.Collections.Generic;
using ZooDLL;

namespace RegrasDLL
{
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasBilhete
    {
        #region OUTROS
        private static readonly string[] tipos = { "Normal", "Estudante", "Senior", "Criança", "Família" };
        private static bool IsValidType(string s)
        {
            foreach (string tipo in tipos)
            {
                if (s == tipo)
                    return true;
            }
            return false;
        }
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
        public static bool Inserir(Bilhete bilhete)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (bilhete is null)
                    throw new ArgumentNullException("Bilhete", "Bilhete não pode ser nulo");

                if (bilhete.Id <= 0)
                    throw new InvalidIDException(bilhete.Id.ToString());

                if (bilhete.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (bilhete.Preco <= 0)
                    throw new NegativeNumberException(bilhete.Preco.ToString());

                if (bilhete.Desconto < 0)
                    throw new LessThanZeroNumberException(bilhete.Desconto.ToString());

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
                if (!IsAllLetters(bilhete.Tipo.Trim()) || bilhete.Tipo == string.Empty)
                    throw new InvalidNameException(bilhete.Tipo.Trim());

                if (!IsValidType(bilhete.Tipo.Trim()))
                    throw new InvalidTypeException(bilhete.Tipo.Trim());
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

                if (Bilhetes.Existe(bilhete.Id))
                    throw new AlreadyExistsException(bilhete.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Bilhetes.Inserir(bilhete))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Bilhete bilhete)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (bilhete is null)
                    throw new ArgumentNullException("Bilhete", "Bilhete não pode ser nulo");

                if (bilhete.Id <= 0)
                    throw new InvalidIDException(bilhete.Id.ToString());

                if (bilhete.Tipo == null)
                    throw new ArgumentNullException("Bilhete", "Bilhete não pode ser nulo");

                if (bilhete.Preco <= 0)
                    throw new NegativeNumberException(bilhete.Preco.ToString());

                if (bilhete.Desconto < 0)
                    throw new LessThanZeroNumberException(bilhete.Desconto.ToString());
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
                if (!IsAllLetters(bilhete.Tipo.Trim()) || bilhete.Tipo == string.Empty)
                    throw new InvalidNameException(bilhete.Tipo.Trim());

                if (!IsValidType(bilhete.Tipo.Trim()))
                    throw new InvalidTypeException(bilhete.Tipo.Trim());
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
                if (!Bilhetes.Existe(bilhete.Id))
                    throw new DoesNotExistException(bilhete.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Bilhetes.Alterar(bilhete))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int bilhete)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (bilhete <= 0)
                    throw new InvalidIDException(bilhete.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Bilhetes.Existe(bilhete))
                    throw new DoesNotExistException(bilhete.ToString());
            }
            catch
            {
                return false;
            }
            if (!Bilhetes.Remover(bilhete))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int bilhete, out Bilhete output)
        {
            output = null;
            /// <summary
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (bilhete <= 0)
                    throw new InvalidIDException(bilhete.ToString());
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
                if (!Bilhetes.Existe(bilhete))
                    throw new DoesNotExistException(bilhete.ToString());
            }
            catch
            {
                return false;
            }
            if (!Bilhetes.Procurar(bilhete, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int bilhete)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (bilhete <= 0)
                    throw new InvalidIDException(bilhete.ToString());
            }
            catch
            {
                return false;
            }
            if (!Bilhetes.Existe(bilhete))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Bilhete> lBilhetes)
        {
            bool aux = true;
            try
            {
                if (lBilhetes == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileBilhete.Guardar(lBilhetes, out string ex))
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
        public static bool Carregar(out List<Bilhete> lBilhetes)
        {
            lBilhetes = null;
            string ex = string.Empty;
            try
            {
                if (!FileBilhete.Carregar(out lBilhetes, out ex))
                    return false;
                if (ex != string.Empty)
                    throw new Exception(ex);
            }
            catch { return false; }
            return true;
        }
        #endregion
    }

}
