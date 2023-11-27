using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever um funcionário
    /// </summary>
    public class Funcionario
    {
        #region ATRIBUTOS
        private int id;
        private string nome;
        private int idade;
        private int telefone;
        private string email;
        private string cargo;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Funcionario()
        {
            this.id = -1;
            this.nome = string.Empty;
            this.idade = -1;
            this.telefone = -1;
            this.email = string.Empty;
            this.cargo = string.Empty;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id do funcionário</param>
        /// <param name="nome">Nome do funcionário</param>
        /// <param name="idade">Idade do funcionário</param>
        /// <param name="telefone">Telefone do funcionário</param>
        /// <param name="email">Email do funcionário</param>
        /// <param name="cargo">Cargo do funcionário</param>
        public Funcionario(int id, string nome, int idade, int telefone, string email, string cargo)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.telefone = telefone;
            this.email = email;
            this.cargo = cargo;
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
            get { return nome; }
        }
        public int Idade
        {
            set { idade = value; }
            get { return idade; }
        }
        public int Telefone
        {
            set { telefone = value; }
            get { return telefone; }
        }
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        public string Cargo
        {
            set { cargo = value; }
            get { return cargo; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Funcionario f1, Funcionario f2)
        {
            if ((f1.Id == f2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Funcionario f1, Funcionario f2)
        {
            if ((f1.Id == f2.Id))
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
            if (obj is Funcionario f)
            {
                if (this == f)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};", this.id, this.nome, this.idade, this.telefone, this.email, this.cargo);
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
