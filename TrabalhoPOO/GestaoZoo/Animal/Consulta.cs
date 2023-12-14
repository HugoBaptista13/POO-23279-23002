using InterfaceDLL;
using System;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever uma consulta
    /// </summary>
    public class Consulta : IConsulta
    {
        #region ATRIBUTOS
        private int id;
        private int animal;
        private int funcionario;
        private DateTime data;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Consulta()
        {
            this.id = -1;
            this.animal = -1;
            this.funcionario = -1;
            this.data = DateTime.Now;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="animal">Animal, paciente da consulta</param>
        /// <param name="funcionario">Funcionário, médico da consulta</param>
        /// <param name="data">Data da consulta</param>
        public Consulta(int id, int animal, int funcionario, DateTime data)
        {
            this.id = id;
            this.animal = animal;
            this.funcionario = funcionario;
            this.data = data;
        }
        #endregion
        #region PROPRIEDADES
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int Animal
        {
            set { animal = value; }
            get { return animal; }
        }
        public int Funcionario
        {
            set { funcionario = value; }
            get { return funcionario; }
        }
        public DateTime Data
        {
            set { data = value; }
            get { return data; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Consulta c1, Consulta c2)
        {
            if ((c1.Id == c2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Consulta c1, Consulta c2)
        {
            if ((c1.Id == c2.Id))
                return true;
            return false;
        }
        #endregion
        #region OVERRIDES
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Consulta c)
            {
                if (this == c)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};", this.id.ToString(), this.animal.ToString(), this.funcionario.ToString(), this.data.ToString());
        }
        #endregion
        #region OUTROS
        public string Listar()
        {
            return this.ToString();
        }
        #endregion
        #endregion
    }
}
