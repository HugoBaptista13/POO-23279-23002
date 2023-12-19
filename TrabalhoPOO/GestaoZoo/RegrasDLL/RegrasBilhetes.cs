using DadosDLL;
using ExcecaoDLL;
using FilesDLL;
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
    public class RegrasBilhete
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
        public static bool Inserir(Bilhete bilhete)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (bilhete == null)
                    throw new ArgumentNullException("Bilhete", "Bilhete não pode ser nulo");

                if (bilhete.Id <= 0)
                    throw new InvalidIDException(bilhete.Id.ToString());

                if (bilhete.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (bilhete.Preco <= 0)
                    throw new NegativeNumberException(bilhete.Preco.ToString());

                if (bilhete.Desconto <= 0)
                    throw new NegativeNumberException(bilhete.Desconto.ToString());

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
                if (!IsAllLetters(bilhete.Tipo.Trim()) || bilhete.Tipo == string.Empty)
                    throw new InvalidNameException(bilhete.Tipo.Trim());
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
            /// 
            /// </summary>
            try
            {
                if (bilhete == null)
                    throw new ArgumentNullException("Bilhete", "Bilhete não pode ser nulo");

                if (bilhete.Id <= 0)
                    throw new InvalidIDException(bilhete.Id.ToString());

                if (bilhete.Tipo == null)
                    throw new ArgumentNullException("Bilhete", "Bilhete não pode ser nulo");

                if (bilhete.Preco <= 0)
                    throw new NegativeNumberException(bilhete.Preco.ToString());

                if (bilhete.Desconto <= 0)
                    throw new NegativeNumberException(bilhete.Desconto.ToString());
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
                if (!IsAllLetters(bilhete.Tipo.Trim()) || bilhete.Tipo == string.Empty)
                    throw new InvalidNameException(bilhete.Tipo.Trim());
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
            /// 
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
            /// 
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
            /// 
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
            /// 
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
        public static bool Carregar(out List<Bilhete> lBilhetes, out string ex)
        {
            lBilhetes = null;
            ex = string.Empty;
            try
            {
                if (!FileBilhete.Carregar(out lBilhetes, out ex))
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
