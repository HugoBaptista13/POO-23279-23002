using DadosDLL;
using ExcecaoDLL;
using FilesDLL;
using System;
using System.Collections.Generic;
using ZooDLL;

namespace RegrasDLL
{
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasVendas
    {
        #region Inserir
        public static bool Inserir(Venda venda)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (venda == null)
                    throw new ArgumentNullException("Venda", "Venda não pode ser nulo");

                if (venda.Id <= 0)
                    throw new InvalidIDException(venda.Id.ToString());

                if (venda.Bilhete <= 0)
                    throw new InvalidIDException(venda.Bilhete.ToString());

                if (venda.NumBilhetes <= 0)
                    throw new NegativeNumberException(venda.Valor.ToString());

                if (venda.Valor <= 0)
                    throw new NegativeNumberException(venda.Valor.ToString());

                if (venda.DataVenda == null)
                    throw new InvalidDateException();
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 2º fase de validações
            /// </summary>
            try
            {
                if (!Bilhetes.Existe(venda.Bilhete))
                    throw new DoesNotExistException(venda.Bilhete.ToString());

                if (Vendas.Existe(venda.Id))
                    throw new AlreadyExistsException(venda.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Vendas.Inserir(venda))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Venda venda)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (venda == null)
                    throw new ArgumentNullException("Venda", "Venda não pode ser nulo");

                if (venda.Id <= 0)
                    throw new InvalidIDException(venda.Id.ToString());

                if (venda.Bilhete <= 0)
                    throw new InvalidIDException(venda.Bilhete.ToString());

                if (venda.NumBilhetes <= 0)
                    throw new NegativeNumberException(venda.Valor.ToString());

                if (venda.Valor <= 0)
                    throw new NegativeNumberException(venda.Valor.ToString());

                if (venda.DataVenda == null)
                    throw new InvalidDateException();
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 2º fase de validações
            /// </summary>
            try
            {
                if (!Bilhetes.Existe(venda.Bilhete))
                    throw new DoesNotExistException(venda.Bilhete.ToString());

                if (!Vendas.Existe(venda.Id))
                    throw new DoesNotExistException(venda.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Vendas.Alterar(venda))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int venda)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (venda <= 0)
                    throw new InvalidIDException(venda.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Vendas.Existe(venda))
                    throw new DoesNotExistException(venda.ToString());
            }
            catch
            {
                return false;
            }
            if (!Vendas.Remover(venda))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int venda, out Venda output)
        {
            output = null;
            /// <summary
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (venda <= 0)
                    throw new InvalidIDException(venda.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary
            /// 2º fase de validações
            /// </summary>
            try
            {
                if (!Vendas.Existe(venda))
                    throw new DoesNotExistException(venda.ToString());
            }
            catch
            {
                return false;
            }
            if (!Vendas.Procurar(venda, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int venda)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (venda <= 0)
                    throw new InvalidIDException(venda.ToString());
            }
            catch
            {
                return false;
            }
            if (!Vendas.Existe(venda))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Venda> lVendas)
        {
            bool aux = true;
            try
            {
                if (lVendas == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileVenda.Guardar(lVendas, out string ex))
                    aux = false;
                if (ex != string.Empty)
                    throw new Exception(ex);
            }
            catch
            {
                return false;
            }
            return aux;
        }
        #endregion
        #region Carregar
        public static bool Carregar(out List<Venda> lVendas, out string ex)
        {
            lVendas = null;
            ex = string.Empty;
            try
            {
                if (!FileVenda.Carregar(out lVendas, out ex))
                    return false;
                if (ex != string.Empty)
                    throw new Exception(ex);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
