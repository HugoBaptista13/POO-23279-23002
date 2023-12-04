using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace DadosDLL
{
    /// <summary>
    /// Classe para guardar as consultas
    /// </summary>
    public class Consultas
    {
        #region ATRIBUTOS
        private const int MAXCONSULTAS = 100;
        private static Consulta[] l_consultas;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Consultas()
        {
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                l_consultas[i] = new Consulta();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Consulta[] LConsultas
        {
            set { l_consultas = value; }
            get { return l_consultas; }
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
            if (obj is Consultas e)
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
            if (LConsultas == null)
                return String.Format(output);
            else
            {
                foreach (Consulta consulta in l_consultas)
                {
                    output += consulta.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        /// <summary>
        /// Método para listar as consultas todas
        /// </summary>
        /// <param name="output">Array de strings com as consultas</param>
        public void Listar(out string[] output)
        {
            int i = 0;
            output = null;
            foreach (Consulta consulta in l_consultas)
            {
                if (consulta.Id == -1)
                    continue;
                output[i] = consulta.Listar();
                i++;
            }
        }
        public bool Inserir(Consulta consulta)
        {
            if (l_consultas == null || consulta == null)
            {
                return false;
            }
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (l_consultas[i] == consulta)
                {
                    return false;
                }
                if (l_consultas[i].Id == -1)
                {
                    l_consultas[i].Id = consulta.Id;
                    l_consultas[i].Animal = consulta.Animal;
                    l_consultas[i].Funcionario = consulta.Funcionario;
                    l_consultas[i].Data = consulta.Data;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um consulta
        /// </summary>
        /// <param name="consulta">Objeto do tipo consulta</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public bool Alterar(Consulta consulta)
        {
            if (consulta == null || l_consultas == null)
                return false;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (l_consultas[i] != consulta)
                {
                    return false;
                }
                if (l_consultas[i].Id == consulta.Id)
                {
                    l_consultas[i].Id = consulta.Id;
                    l_consultas[i].Animal = consulta.Animal;
                    l_consultas[i].Funcionario = consulta.Funcionario;
                    l_consultas[i].Data = consulta.Data;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de uma consulta
        /// </summary>
        /// <param name="consulta">Objeto do tipo consulta</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public bool Remover(Consulta consulta)
        {
            if (consulta == null || l_consultas == null)
                return false;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (l_consultas[i] != consulta)
                {
                    return false;
                }
                if (l_consultas[i].Id == consulta.Id)
                {
                    l_consultas[i].Id = -1;
                    l_consultas[i].Animal = -1;
                    l_consultas[i].Funcionario = -1;
                    l_consultas[i].Data = DateTime.MinValue;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma consulta
        /// </summary>
        /// <param name="consulta">Objeto do tipo consulta</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public bool Existe(Consulta consulta)
        {
            if (consulta == null || l_consultas == null)
                return false;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (l_consultas[i] != consulta)
                {
                    return false;
                }
                if (l_consultas[i].Id == consulta.Id)
                {
                    break;
                }
            }
            return true;
        }
        #endregion
        #endregion
    }
}
