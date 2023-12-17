using InterfaceDLL;
using System;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever um recinto
    /// </summary>
    public class Recinto : IRecinto
    {
        #region ATRIBUTOS
        private int id;
        private string nome;
        private string tipo;
        private double comprimento;
        private double largura;
        private double altura;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Recinto()
        {
            this.id = -1;
            this.nome = string.Empty;
            this.tipo = string.Empty;
            this.comprimento = -1;
            this.largura = -1;
            this.altura = -1;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id do recinto</param>
        /// <param name="nome">Nome do recinto</param>
        /// <param name="tipo">Tipo do recinto</param>
        /// <param name="comprimento">Comprimento do recinto</param>
        /// <param name="largura">Largura do recinto</param>
        /// <param name="altura">Altura do recinto</param>
        public Recinto(int id, string nome, string tipo, double comprimento, double largura, double altura)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.comprimento = comprimento;
            this.largura = largura;
            this.altura = altura;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="recinto">Objeto do tipo recinto</param>
        public Recinto(Recinto recinto)
        {
            this.id = recinto.id;
            this.nome = recinto.nome;
            this.tipo = recinto.tipo;
            this.comprimento = recinto.comprimento;
            this.largura = recinto.largura;
            this.altura = recinto.altura;
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
        public string Tipo
        {
            set { tipo = value; }
            get { return tipo; }
        }
        public double Comprimento
        {
            set { comprimento = value; }
            get { return comprimento; }
        }
        public double Largura
        {
            set { largura = value; }
            get { return largura; }
        }
        public double Altura
        {
            set { altura = value; }
            get { return altura; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Recinto r1, Recinto r2)
        {
            if ((r1.Id == r2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Recinto r1, Recinto r2)
        {
            if ((r1.Id == r2.Id))
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
            if (obj is Recinto r)
            {
                if (this == r)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};", this.id.ToString(), this.nome.ToString(), this.tipo.ToString(), this.comprimento.ToString(), this.largura.ToString(), this.altura.ToString());
        }
        #endregion
        #region OUTROS
        public string Listar()
        {
            return this.ToString();
        }
        public double CalculaArea()
        {
            return largura * comprimento;
        }
        #endregion
        #endregion
    }
}
