using System;
using System.Collections.Generic;
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
        private static List<Evento> lEventos;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Eventos()
        {
            lEventos = new List<Evento>();
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                lEventos.Add(new Evento());
            }
        }
        #endregion
        #region PROPRIEDADES
        public static List<Evento> LEventos
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
        /// <summary>
        /// Método para contar os eventos que existem
        /// </summary>
        /// <returns>Retorna o número de eventos existentes</returns>
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
        /// Retorna uma lista com os dados dos eventos
        /// </summary>
        public static List<Evento> Listar()
        {
            int j = 0;
            List<Evento> output = new List<Evento>();
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (j < Contar() && lEventos[i].Id != -1)
                {
                    output.Add(lEventos[i]);
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
        /// <summary>
        /// Método para procurar um evento, recebe o identificador do evento
        /// </summary>
        /// <param name="evento">Identificador do evento</param>
        /// <param name="output">Objeto do tipo evento</param>
        /// <returns>Retorna true quando retorna encontra o objeto a procurar, se não conseguir retorna false</returns>
        public static bool Procurar(int evento, out Evento output)
        {
            output = new Evento();
            if (evento == -1 || lEventos == null || !Existe(evento))
                return false;
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                if (lEventos[i].Id == evento)
                {
                    output = new Evento(lEventos[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion
    }
}
