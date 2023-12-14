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
    /// Classe para guardar os eventos
    /// </summary>
    public class Eventos
    {
        #region ATRIBUTOS
        private const int MAXEVENTOS = 100;
        private static Evento[] lEventos;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Eventos()
        {
            lEventos = new Evento[MAXEVENTOS];
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                lEventos[i] = new Evento();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Evento[] LEventos
        {
            set { lEventos = value; }
            get { return lEventos; }
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
            if (obj is Eventos e)
            {
                if (this == e)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string output = "";
            if (LEventos == null)
                return String.Format(output);
            else
            {
                foreach (Evento evento in lEventos)
                {
                    output += evento.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (lEventos[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar os eventos todos
        /// </summary>
        /// <param name="output">Array de strings com os eventos</param>
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (j < Contar() && lEventos[i].Id != -1)
                {
                    output[j] = lEventos[i].Listar();
                    j++;
                }
                if (j == Contar() && lEventos[i].Id == -1)
                    break;

            }
            return output;
        }
        /// <summary>
        /// Método para adicionar um evento, recebe um objeto do tipo evento com os dados do evento
        /// </summary>
        /// <param name="evento">Objeto do tipo evento</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Evento evento)
        {
            if (lEventos == null || evento is null || Existe(evento.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (lEventos[i] == evento)
                {
                    return false;
                }
                if (lEventos[i].Id == -1)
                {
                    lEventos[i].Id = evento.Id;
                    lEventos[i].Nome = evento.Nome;
                    lEventos[i].Lotacao = evento.Lotacao;
                    lEventos[i].LotacaoTotal = evento.LotacaoTotal;
                    lEventos[i].Local = evento.Local;
                    lEventos[i].DataInicio = evento.DataInicio;
                    lEventos[i].DataFim = evento.DataFim;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um evento
        /// </summary>
        /// <param name="evento">Objeto do tipo evento</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Evento evento)
        {
            if (evento is null || lEventos == null || !Existe(evento.Id))
                return false;
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (lEventos[i].Id == evento.Id)
                {
                    lEventos[i].Nome = evento.Nome;
                    lEventos[i].Lotacao = evento.Lotacao;
                    lEventos[i].LotacaoTotal = evento.LotacaoTotal;
                    lEventos[i].Local = evento.Local;
                    lEventos[i].DataInicio = evento.DataInicio;
                    lEventos[i].DataFim = evento.DataFim;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de um evento, recebe o identificador do evento
        /// </summary>
        /// <param name="evento">Identificador do evento</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int evento)
        {
            if (evento == -1 || lEventos == null || !Existe(evento))
                return false;
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (lEventos[i].Id == evento)
                {
                    lEventos[i].Id = -1;
                    lEventos[i].Nome = "";
                    lEventos[i].Lotacao = -1;
                    lEventos[i].LotacaoTotal = -1;
                    lEventos[i].Local = "";
                    lEventos[i].DataInicio = DateTime.MinValue;
                    lEventos[i].DataFim = DateTime.MinValue;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe um evento
        /// </summary>
        /// <param name="evento">identificador do evento</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int evento)
        {
            if (evento == -1 || lEventos == null)
                return false;
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (lEventos[i].Id == evento)
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
