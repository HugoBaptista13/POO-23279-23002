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
    public class RegrasComidas
    {
        #region OUTROS
        private static readonly string[] tipos = { "Seca", "Enlatada", "Congelada", "Viva", "Restos", "Molhada" };
        private static readonly string[] dietas = { "Carnívoro", "Herbívoro", "Omnívoro", "Piscívoro", "Frugívoro", "Insetívoro", "Granívoro", "Necrófago" };
        private static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) || c != ' ')
                    return false;
            }
            return true;
        }
        private static bool IsValidType(string s)
        {
            foreach (string tipo in tipos)
            {
                if (s == tipo)
                    return true;
            }
            return false;
        }
        private static bool IsValidDiet(string s)
        {
            foreach (string a in dietas)
            {
                if (a != s)
                    return false;
            }
            return true;
        }
        #endregion
        #region Inserir
        public static bool Inserir(Comida comida)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (comida == null)
                    throw new ArgumentNullException("Comida", "Comida não pode ser nulo");

                if (comida.Id <= 0)
                    throw new InvalidIDException(comida.Id.ToString());

                if (comida.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (comida.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (comida.Dieta == null)
                    throw new ArgumentNullException("Dieta", "Dieta não pode ser nulo");

                if (comida.Stock <= 0)
                    throw new NegativeNumberException(comida.Stock.ToString());

                if (comida.DataValidade == null)
                    throw new InvalidDateException();
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
                if (!IsAllLetters(comida.Nome.Trim()) || comida.Nome == string.Empty)
                    throw new InvalidNameException(comida.Nome.Trim());

                if (!IsAllLetters(comida.Tipo.Trim()) || comida.Tipo == string.Empty)
                    throw new InvalidTextException(comida.Tipo.Trim());

                if (!IsAllLetters(comida.Dieta.Trim()) || comida.Dieta == string.Empty)
                    throw new InvalidTextException(comida.Dieta.Trim());

                if (!IsValidDiet(comida.Dieta.Trim()))
                    throw new InvalidDietException(comida.Dieta.Trim());

                if (!IsValidType(comida.Tipo.Trim()))
                    throw new InvalidTypeException(comida.Tipo.Trim());
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
                if (comida.DataValidade > DateTime.Today)
                    throw new OutOfExpirationDateException(comida.DataValidade.ToString());

                if (Comidas.Existe(comida.Id))
                    throw new AlreadyExistsException(comida.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Comidas.Inserir(comida))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Comida comida)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (comida == null)
                    throw new ArgumentNullException("Comida", "Comida não pode ser nulo");

                if (comida.Id <= 0)
                    throw new InvalidIDException(comida.Id.ToString());

                if (comida.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (comida.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (comida.Dieta == null)
                    throw new ArgumentNullException("Dieta", "Dieta não pode ser nulo");

                if (comida.Stock <= 0)
                    throw new NegativeNumberException(comida.Stock.ToString());

                if (comida.DataValidade == null)
                    throw new InvalidDateException();
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
                if (!IsAllLetters(comida.Nome.Trim()) || comida.Nome == string.Empty)
                    throw new InvalidNameException(comida.Nome.Trim());

                if (!IsAllLetters(comida.Tipo.Trim()) || comida.Tipo == string.Empty)
                    throw new InvalidTextException(comida.Tipo.Trim());

                if (!IsAllLetters(comida.Dieta.Trim()) || comida.Dieta == string.Empty)
                    throw new InvalidTextException(comida.Dieta.Trim());

                if (!IsValidDiet(comida.Dieta.Trim()))
                    throw new InvalidDietException(comida.Dieta.Trim());

                if (!IsValidType(comida.Tipo.Trim()))
                    throw new InvalidTypeException(comida.Tipo.Trim());
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
                if (comida.DataValidade > DateTime.Today)
                    throw new OutOfExpirationDateException(comida.DataValidade.ToString());

                if (!Comidas.Existe(comida.Id))
                    throw new DoesNotExistException(comida.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Comidas.Alterar(comida))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int comida)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (comida <= 0)
                    throw new InvalidIDException(comida.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Comidas.Existe(comida))
                    throw new DoesNotExistException(comida.ToString());
            }
            catch
            {
                return false;
            }
            if (!Comidas.Remover(comida))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int comida, out Comida output)
        {
            output = null;
            /// <summary
            /// 
            /// </summary>
            try
            {
                if (comida <= 0)
                    throw new InvalidIDException(comida.ToString());
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
                if (!Comidas.Existe(comida))
                    throw new DoesNotExistException(comida.ToString());
            }
            catch
            {
                return false;
            }
            if (!Comidas.Procurar(comida, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int comida)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (comida <= 0)
                    throw new InvalidIDException(comida.ToString());
            }
            catch
            {
                return false;
            }
            if (!Comidas.Existe(comida))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Comida> lComidas)
        {
            bool aux = true;
            try
            {
                if (lComidas == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileComida.Guardar(lComidas, out string ex))
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
        public static bool Carregar(out List<Comida> lComidas, out string ex)
        {
            lComidas = null;
            ex = string.Empty;
            try
            {
                if (!FileComida.Carregar(out lComidas, out ex))
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