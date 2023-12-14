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
    /// Classe para guardar as consultas
    /// </summary>
    public class Consultas
    {
        #region ATRIBUTOS
        private const int MAXCONSULTAS = 100;
        private static Consulta[] lConsultas;
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
                lConsultas[i] = new Consulta();
            }
        }
        #endregion
        #region PROPRIEDADES
        public static Consulta[] LConsultas
        {
            set { lConsultas = value; }
            get { return lConsultas; }
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
                foreach (Consulta consulta in lConsultas)
                {
                    output += consulta.Listar();
                }
                return String.Format(output);
            }
        }
        #endregion
        #region OUTROS
        public static int Contar()
        {
            int c = 0;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (lConsultas[i].Id != -1)
                    c++;
            }
            return c;
        }
        /// <summary>
        /// Método para listar as consultas todas
        /// </summary>
        /// <param name="output">Array de strings com as consultas</param>
        public static string[] Listar()
        {
            int j = 0;
            string[] output = new string[Contar()];
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (j < Contar() && lConsultas[i].Id != -1)
                {
                    output[j] = lConsultas[i].Listar();
                    j++;
                }
                if (j == Contar() && lConsultas[i].Id == -1)
                    break;

            }
            return output;
        }
        /// <summary>
        /// Método para adicionar uma consulta, recebe um objeto do tipo consulta com os dados da consulta
        /// </summary>
        /// <param name="consulta">Objeto do tipo consulta</param>
        /// <returns>Se conseguir adicionar retorna true, senão retorna false</returns>
        public static bool Inserir(Consulta consulta)
        {
            if (lConsultas == null || consulta is null || Existe(consulta.Id))
            {
                return false;
            }
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (lConsultas[i].Id == -1)
                {
                    lConsultas[i].Id = consulta.Id;
                    lConsultas[i].Animal = consulta.Animal;
                    lConsultas[i].Funcionario = consulta.Funcionario;
                    lConsultas[i].Data = consulta.Data;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para alterar os dados de um consulta
        /// </summary>
        /// <param name="consulta">Objeto do tipo consulta</param>
        /// <returns>Se conseguir alterar retorna true, senão retorna false</returns>
        public static bool Alterar(Consulta consulta)
        {
            if (consulta is null || lConsultas == null || !Existe(consulta.Id))
                return false;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (lConsultas[i].Id == consulta.Id)
                {
                    return false;
                }
                if (lConsultas[i].Id == consulta.Id)
                {
                    lConsultas[i].Animal = consulta.Animal;
                    lConsultas[i].Funcionario = consulta.Funcionario;
                    lConsultas[i].Data = consulta.Data;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Método para remover os dados de uma consulta, recebe o identificador da consulta
        /// </summary>
        /// <param name="consulta">Identificador da consulta</param>
        /// <returns>Se conseguir remover retorna true, senão retorna false</returns>
        public static bool Remover(int consulta)
        {
            if (consulta == -1 || lConsultas == null || !Existe(consulta))
                return false;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (lConsultas[i].Id == consulta)
                {
                    lConsultas[i].Id = -1;
                    lConsultas[i].Animal = -1;
                    lConsultas[i].Funcionario = -1;
                    lConsultas[i].Data = DateTime.MinValue;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Método para verificar se existe uma consulta
        /// </summary>
        /// <param name="consulta">identificador da consulta</param>
        /// <returns>Se verificar que existe retorna true, senão retorna false</returns>
        public static bool Existe(int consulta)
        {
            if (consulta == -1 || lConsultas == null)
                return false;
            for (int i = 0; i < MAXCONSULTAS; i++)
            {
                if (lConsultas[i].Id == consulta)
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
