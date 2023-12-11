using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InterfaceDLL;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever um animal
    /// </summary>
    public class Animal : IAnimal
    {
        #region ATRIBUTOS
        private int id;
        private string nome;
        private int idade;
        private string sexo;
        private string classe;
        private string especie;
        private string dieta;
        private int estado;
        private DateTime data_ultima_consulta;
        private DateTime data_proxima_consulta;
        private string recinto;
        private string descricao;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Animal()
        {
            this.id = -1;
            this.nome = string.Empty;
            this.idade = -1;
            this.sexo = string.Empty;
            this.classe = string.Empty;
            this.especie = string.Empty;
            this.dieta = string.Empty;
            this.estado = -1;
            this.data_ultima_consulta = DateTime.Now;
            this.data_proxima_consulta = new DateTime(DateTime.Today.Year+1,DateTime.Today.Month,DateTime.Today.Day);
            this.recinto = string.Empty;
            this.descricao = string.Empty;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id do animal</param>
        /// <param name="nome">Nome do animal</param>
        /// <param name="idade">Idade do animal</param>
        /// <param name="sexo">Sexo do animal</param>
        /// <param name="classe">Classe do animal</param>
        /// <param name="especie">Espécie do animal</param>
        /// <param name="dieta">Dieta do animal</param>
        /// <param name="estado">Estado do animal</param>
        /// <param name="data_ultima_consulta">Data da última consulta</param>
        /// <param name="data_proxima_consulta">Data da próxima consulta</param>
        /// <param name="recinto">Recinto do animal</param>
        /// <param name="descricao">Descrição do animal</param>
        public Animal(int id, string nome, int idade, string sexo, string classe, string especie, string dieta, int estado, DateTime data_ultima_consulta, DateTime data_proxima_consulta, string recinto, string descricao)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.sexo = sexo;
            this.classe = classe;
            this.especie = especie;
            this.dieta = dieta;
            this.estado = estado;
            this.data_ultima_consulta = data_ultima_consulta;
            this.data_proxima_consulta = data_proxima_consulta;
            this.recinto = recinto;
            this.descricao = descricao;
        }
        #endregion
        #region PROPRIEDADES
        public int Id
        { 
            set { id = value; }
            get { return id; } 
        }
        public string Nome 
        { 
            set { nome = value; }
            get { return nome;}
        }
        public int Idade
        { 
            set { idade = value; }
            get { return idade; } 
        }
        public string Sexo
        {
            set { sexo = value; }
            get { return sexo; }
        }
        public string Classe
        { 
            set { classe = value; }
            get { return classe; } 
        }
        public string Especie
        { 
            set { especie = value; }
            get { return especie; } 
        }
        public string Dieta
        { 
            set { dieta = value; }
            get { return dieta; } 
        }
        public int Estado
        {
            set { estado = value; }
            get { return estado; }
        }
        public DateTime DataUltimaConsulta
        {
            set { data_ultima_consulta = value; }
            get { return data_ultima_consulta; }
        }
        public DateTime DataProximaConsulta
        {
            set { data_proxima_consulta = value; }
            get { return data_proxima_consulta; }
        }
        public string Recinto
        {
            set { recinto = value; }
            get { return recinto; }
        }
        public string Descricao
        {
            set { descricao = value; }
            get { return descricao; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Animal a1, Animal a2)
        {
            if ((a1.Id == a2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Animal a1, Animal a2)
        {
            if ((a1.Id == a2.Id))
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
            if (obj is Animal a)
            {
                if (this == a)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};",this.id.ToString(), this.nome.ToString(), this.idade.ToString(), this.sexo.ToString(), this.classe.ToString(),this.especie.ToString(),this.dieta.ToString(),this.estado.ToString(),this.data_ultima_consulta.ToString(),this.data_proxima_consulta.ToString(),this.recinto.ToString(),this.descricao.ToString());
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
