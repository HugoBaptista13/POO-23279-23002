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
    public class RegrasRecintos
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
        public static bool Inserir(Recinto recinto)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (recinto == null)
                    throw new ArgumentNullException("Recinto", "Recinto não pode ser nulo");

                if (recinto.Id <= 0)
                    throw new InvalidIDException(recinto.Id.ToString());

                if (recinto.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (recinto.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (recinto.Comprimento <= 0)
                    throw new NegativeNumberException(recinto.Comprimento.ToString());

                if (recinto.Largura <= 0)
                    throw new NegativeNumberException(recinto.Largura.ToString());

                if (recinto.Altura <= 0)
                    throw new NegativeNumberException(recinto.Altura.ToString());
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
                if (!IsAllLetters(recinto.Nome.Trim()) || recinto.Nome == string.Empty)
                    throw new InvalidNameException(recinto.Nome.Trim());

                if (!IsAllLetters(recinto.Tipo.Trim()) || recinto.Tipo == string.Empty)
                    throw new InvalidTextException(recinto.Tipo.Trim());
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

                if (Recintos.Existe(recinto.Id))
                    throw new AlreadyExistsException(recinto.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Recintos.Inserir(recinto))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Recinto recinto)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (recinto == null)
                    throw new ArgumentNullException("Recinto", "Recinto não pode ser nulo");

                if (recinto.Id <= 0)
                    throw new InvalidIDException(recinto.Id.ToString());

                if (recinto.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (recinto.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (recinto.Comprimento <= 0)
                    throw new NegativeNumberException(recinto.Comprimento.ToString());

                if (recinto.Largura <= 0)
                    throw new NegativeNumberException(recinto.Largura.ToString());

                if (recinto.Altura <= 0)
                    throw new NegativeNumberException(recinto.Altura.ToString());
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
                if (!IsAllLetters(recinto.Nome.Trim()) || recinto.Nome == string.Empty)
                    throw new InvalidNameException(recinto.Nome.Trim());

                if (!IsAllLetters(recinto.Tipo.Trim()) || recinto.Tipo == string.Empty)
                    throw new InvalidTextException(recinto.Tipo.Trim());
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
                if (!Recintos.Existe(recinto.Id))
                    throw new DoesNotExistException(recinto.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Recintos.Alterar(recinto))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int recinto)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (recinto <= 0)
                    throw new InvalidIDException(recinto.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Recintos.Existe(recinto))
                    throw new DoesNotExistException(recinto.ToString());
            }
            catch
            {
                return false;
            }
            if (!Recintos.Remover(recinto))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int recinto, out Recinto output)
        {
            output = null;
            /// <summary
            /// 
            /// </summary>
            try
            {
                if (recinto <= 0)
                    throw new InvalidIDException(recinto.ToString());
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
                if (!Recintos.Existe(recinto))
                    throw new DoesNotExistException(recinto.ToString());
            }
            catch
            {
                return false;
            }
            if (!Recintos.Procurar(recinto, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int recinto)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (recinto <= 0)
                    throw new InvalidIDException(recinto.ToString());
            }
            catch
            {
                return false;
            }
            if (!Recintos.Existe(recinto))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Recinto> lRecintos)
        {
            bool aux = true;
            try
            {
                if (lRecintos == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileRecinto.Guardar(lRecintos, out string ex))
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
        public static bool Carregar(out List<Recinto> lRecintos, out string ex)
        {
            lRecintos = null;
            ex = string.Empty;
            try
            {
                if (!FileRecinto.Carregar(out lRecintos, out ex))
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
