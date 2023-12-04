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
        private static Evento[] l_eventos;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Eventos()
        {
            for (int i = 0; i < MAXEVENTOS; i++)
            {
                l_eventos[i] = new Evento();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Evento[] LEventos
        {
            set { l_eventos = value; }
            get { return l_eventos; }
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
                foreach (Evento evento in l_eventos)
                {
                    output += evento.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar os eventos todos
        /// </summary>
        /// <param name="output">Array de strings com os eventos</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Evento evento in l_eventos)
            {
                if (evento.Id == -1)
                    continue;
                output[i] = evento.Listar();
                i++;
            }
        }
        #endregion
        #endregion
    }
}
