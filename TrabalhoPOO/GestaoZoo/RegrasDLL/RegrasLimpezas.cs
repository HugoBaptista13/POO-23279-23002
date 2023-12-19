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
    public class RegrasLimpezas
    {
        #region Inserir
        public static bool Inserir(Limpeza limpeza)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (limpeza is null)
                    throw new ArgumentNullException("Limpeza", "limpeza não pode ser nulo");

                if (limpeza.Id <= 0)
                    throw new InvalidIDException(limpeza.Id.ToString());

                if (limpeza.Recinto <= 0)
                    throw new InvalidIDException(limpeza.Recinto.ToString());

                if (limpeza.Funcionario <= 0)
                    throw new InvalidIDException(limpeza.Funcionario.ToString());

                if (limpeza.Data == null)
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
                if (!Recintos.Existe(limpeza.Recinto))
                    throw new DoesNotExistException(limpeza.Recinto.ToString());
                
                if (!Funcionarios.Existe(limpeza.Funcionario))
                    throw new DoesNotExistException(limpeza.Funcionario.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 3º fase de validações
            /// </summary>
            try
            {
                bool result = Funcionarios.Procurar(limpeza.Funcionario, out Funcionario aux);

                if (result && aux.Cargo != "Zelador")
                    throw new InvalidRoleException(aux.Cargo);

                if (Limpezas.Existe(limpeza.Id))
                    throw new AlreadyExistsException(limpeza.Id.ToString());
            }
            catch
            {
                return false;
            }

            if (!Limpezas.Inserir(limpeza))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Limpeza limpeza)
        {

            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (limpeza is null)
                    throw new ArgumentNullException("Limpeza", "limpeza não pode ser nulo");

                if (limpeza.Id <= 0)
                    throw new InvalidIDException(limpeza.Id.ToString());

                if (limpeza.Recinto <= 0)
                    throw new InvalidIDException(limpeza.Recinto.ToString());

                if (limpeza.Funcionario <= 0)
                    throw new InvalidIDException(limpeza.Funcionario.ToString());

                if (limpeza.Data == null)
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
                if (!Recintos.Existe(limpeza.Recinto))
                    throw new DoesNotExistException(limpeza.Recinto.ToString());

                if (!Funcionarios.Existe(limpeza.Funcionario))
                    throw new DoesNotExistException(limpeza.Funcionario.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 3º fase de validações
            /// </summary>
            try
            {
                bool result = Funcionarios.Procurar(limpeza.Funcionario, out Funcionario aux);

                if (result && aux.Cargo != "Zelador")
                    throw new InvalidRoleException(aux.Cargo);

                if (!Limpezas.Existe(limpeza.Id))
                    throw new DoesNotExistException(limpeza.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Limpezas.Alterar(limpeza))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int limpeza)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (limpeza <= 0)
                    throw new InvalidIDException(limpeza.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Limpezas.Existe(limpeza))
                    throw new DoesNotExistException(limpeza.ToString());
            }
            catch
            {
                return false;
            }
            if (!Limpezas.Remover(limpeza))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int limpeza, out Limpeza output)
        {
            output = null;
            /// <summary
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (limpeza <= 0)
                    throw new InvalidIDException(limpeza.ToString());
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
                if (!Limpezas.Existe(limpeza))
                    throw new DoesNotExistException(limpeza.ToString());
            }
            catch
            {
                return false;
            }
            if (!Limpezas.Procurar(limpeza, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int limpeza)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (limpeza <= 0)
                    throw new InvalidIDException(limpeza.ToString());
            }
            catch
            {
                return false;
            }
            if (!Limpezas.Existe(limpeza))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Limpeza> lLimpezas)
        {
            bool aux = true;
            try
            {
                if (lLimpezas == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileLimpeza.Guardar(lLimpezas, out string ex))
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
        public static bool Carregar(out List<Limpeza> lLimpezas)
        {
            lLimpezas = null;
            string ex = string.Empty;
            try
            {
                if (!FileLimpeza.Carregar(out lLimpezas, out ex))
                    return false;
                if (ex != string.Empty)
                    throw new Exception(ex);
            }
            catch { return false; }
            return true;
        }
        #endregion
    }
}
