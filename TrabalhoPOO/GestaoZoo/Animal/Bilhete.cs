﻿using InterfaceDLL;
using System;

namespace ZooDLL
{
    /// <summary>
    /// Classe para descrever um bilhete
    /// </summary>
    [Serializable]
    public class Bilhete : IBilhete
    {
        #region ATRIBUTOS
        private int id;
        private string tipo;
        private double preco;
        private double desconto;
        #endregion

        #region METODOS
        #region CONSTRUTORES
        /// <summary>
        /// Construtor por defeito, sem argumentos
        /// </summary>
        public Bilhete()
        {
            this.id = -1;
            this.tipo = string.Empty;
            this.preco = -1;
            this.desconto = 0;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="id">Id do bilhete</param>
        /// <param name="tipo">Tipo do bilhete</param>
        /// <param name="preco">Preço do bilhete</param>
        /// <param name="desconto">Desconto do bilhete</param>
        public Bilhete(int id, string tipo, double preco, double desconto)
        {
            this.id = id;
            this.tipo = tipo;
            this.preco = preco;
            this.desconto = desconto;
        }
        /// <summary>
        /// Construtor com argumentos
        /// </summary>
        /// <param name="bilhete">Objeto do tipo bilhete</param>
        public Bilhete(Bilhete bilhete)
        {
            this.id = bilhete.id;
            this.tipo = bilhete.tipo;
            this.preco = bilhete.preco;
            this.desconto = bilhete.desconto;
        }
        #endregion
        #region PROPRIEDADES
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Tipo
        {
            set { tipo = value; }
            get { return tipo; }
        }
        public double Preco
        {
            set { preco = value; }
            get { return preco; }
        }
        public double Desconto
        {
            set { desconto = value; }
            get { return desconto; }
        }
        #endregion
        #region OPERADORES
        public static bool operator ==(Bilhete b1, Bilhete b2)
        {
            if ((b1.Id == b2.Id))
                return true;
            return false;
        }
        public static bool operator !=(Bilhete b1, Bilhete b2)
        {
            if ((b1.Id == b2.Id))
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
            if (obj is Bilhete b)
            {
                if (this == b)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};", this.id.ToString(), this.tipo.ToString(), this.preco.ToString(), this.desconto.ToString());
        }
        #endregion
        #region OUTROS
        public string Listar()
        {
            return this.ToString();
        }
        public double CalcularPreco()
        {
            double precodes = preco - (preco * desconto);
            return precodes;
        }
        #endregion
        #endregion
    }
}
