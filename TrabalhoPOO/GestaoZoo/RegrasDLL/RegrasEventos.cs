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
    public class RegrasEventos
    {
        #region outros
        private static bool IsAllLettersAndNumbers(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c) || c != ' ')
                    return false;
            }
            return true;
        }
        #endregion
        #region Inserir
        public static bool Inserir(Evento evento)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (evento == null)
                    throw new ArgumentNullException("Evento", "Evento não pode ser nulo");

                if (evento.Id <= 0)
                    throw new InvalidIDException(evento.Id.ToString());

                if (evento.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (evento.Lotacao <= 0)
                    throw new NegativeNumberException(evento.Lotacao.ToString());

                if (evento.LotacaoTotal <= 0)
                    throw new NegativeNumberException(evento.LotacaoTotal.ToString());

                if (evento.Local == null)
                    throw new ArgumentNullException("Local", "Nome não pode ser nulo");

                if (evento.DataInicio == null)
                    throw new InvalidDateException();

                if (evento.DataFim == null)
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
                if (!IsAllLettersAndNumbers(evento.Nome.Trim()) || evento.Nome == string.Empty)
                    throw new InvalidNameException(evento.Nome.Trim());

                if (!IsAllLettersAndNumbers(evento.Local.Trim()) || evento.Local == string.Empty)
                    throw new InvalidTextException(evento.Local.Trim());

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
                if (evento.DataInicio > evento.DataFim)
                    throw new GreaterThanPreviousDateException(evento.DataInicio.ToString(), evento.DataFim.ToString());

                if (evento.Lotacao > evento.LotacaoTotal)
                    throw new GreaterThanMaxCapacityException(evento.Lotacao.ToString(), evento.LotacaoTotal.ToString());

                if (Eventos.Existe(evento.Id))
                    throw new AlreadyExistsException(evento.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Eventos.Inserir(evento))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Evento evento)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (evento == null)
                    throw new ArgumentNullException("Evento", "Evento não pode ser nulo");

                if (evento.Id <= 0)
                    throw new InvalidIDException(evento.Id.ToString());

                if (evento.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (evento.Lotacao <= 0)
                    throw new NegativeNumberException(evento.Lotacao.ToString());

                if (evento.LotacaoTotal <= 0)
                    throw new NegativeNumberException(evento.LotacaoTotal.ToString());

                if (evento.Local == null)
                    throw new ArgumentNullException("Local", "Local não pode ser nulo");

                if (evento.DataInicio == null)
                    throw new InvalidDateException();

                if (evento.DataFim == null)
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
                if (!IsAllLettersAndNumbers(evento.Nome.Trim()) || evento.Nome == string.Empty)
                    throw new InvalidNameException(evento.Nome.Trim());

                if (!IsAllLettersAndNumbers(evento.Local.Trim()) || evento.Local == string.Empty)
                    throw new InvalidTextException(evento.Local.Trim());

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
                if (evento.DataInicio > evento.DataFim)
                    throw new GreaterThanPreviousDateException(evento.DataInicio.ToString(), evento.DataFim.ToString());

                if (evento.Lotacao > evento.LotacaoTotal)
                    throw new GreaterThanMaxCapacityException(evento.Lotacao.ToString(), evento.LotacaoTotal.ToString());

                if (!Eventos.Existe(evento.Id))
                    throw new DoesNotExistException(evento.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Eventos.Alterar(evento))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int evento)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (evento <= 0)
                    throw new InvalidIDException(evento.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Eventos.Existe(evento))
                    throw new DoesNotExistException(evento.ToString());
            }
            catch
            {
                return false;
            }
            if (!Eventos.Remover(evento))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int evento, out Evento output)
        {
            output = null;
            /// <summary
            /// 
            /// </summary>
            try
            {
                if (evento <= 0)
                    throw new InvalidIDException(evento.ToString());
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
                if (!Eventos.Existe(evento))
                    throw new DoesNotExistException(evento.ToString());
            }
            catch
            {
                return false;
            }
            if (!Eventos.Procurar(evento, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int evento)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (evento <= 0)
                    throw new InvalidIDException(evento.ToString());
            }
            catch
            {
                return false;
            }
            if (!Eventos.Existe(evento))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Evento> lEventos)
        {
            bool aux = true;
            try
            {
                if (lEventos == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileEvento.Guardar(lEventos, out string ex))
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
        public static bool Carregar(out List<Evento> lEventos, out string ex)
        {
            lEventos = null;
            ex = string.Empty;
            try
            {
                if (!FileEvento.Carregar(out lEventos, out ex))
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
