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
    public class RegrasConsultas
    {
        #region Inserir
        public static bool Inserir(Consulta consulta)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (consulta == null)
                    throw new ArgumentNullException("Consulta", "Consulta não pode ser nulo");

                if (consulta.Id <= 0)
                    throw new InvalidIDException(consulta.Id.ToString());
                
                if (consulta.Animal <= 0)
                    throw new InvalidIDException(consulta.Animal.ToString());

                if (consulta.Funcionario <= 0)
                    throw new InvalidIDException(consulta.Funcionario.ToString());

                if (consulta.Data == null)
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
                if (!Animais.Existe(consulta.Animal))
                    throw new DoesNotExistException(consulta.Animal.ToString());

                if (!Funcionarios.Existe(consulta.Funcionario))
                    throw new DoesNotExistException(consulta.Funcionario.ToString());
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
                bool result = Funcionarios.Procurar(consulta.Funcionario, out Funcionario aux);

                if (result && aux.Cargo != "Veterinário")
                    throw new InvalidRoleException(aux.Cargo);

                if (Consultas.Existe(consulta.Id))
                    throw new AlreadyExistsException(consulta.Id.ToString());
            }
            catch
            {
                return false;
            }

            if (!Consultas.Inserir(consulta))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Consulta consulta)
        {

            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (consulta == null)
                    throw new ArgumentNullException("Consulta", "Consulta não pode ser nulo");

                if (consulta.Id <= 0)
                    throw new InvalidIDException(consulta.Id.ToString());

                if (consulta.Animal <= 0)
                    throw new InvalidIDException(consulta.Animal.ToString());

                if (consulta.Funcionario <= 0)
                    throw new InvalidIDException(consulta.Funcionario.ToString());

                if (consulta.Data == null)
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
                if (!Animais.Existe(consulta.Animal))
                    throw new DoesNotExistException(consulta.Animal.ToString());

                if (!Funcionarios.Existe(consulta.Funcionario))
                    throw new DoesNotExistException(consulta.Funcionario.ToString());
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
                bool result = Funcionarios.Procurar(consulta.Funcionario, out Funcionario aux);

                if (result && aux.Cargo != "Veterinário")
                    throw new InvalidRoleException(aux.Cargo);

                if (!Consultas.Existe(consulta.Id))
                    throw new DoesNotExistException(consulta.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Consultas.Alterar(consulta))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int consulta)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (consulta <= 0)
                    throw new InvalidIDException(consulta.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Consultas.Existe(consulta))
                    throw new DoesNotExistException(consulta.ToString());
            }
            catch
            {
                return false;
            }
            if (!Consultas.Remover(consulta))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int consulta, out Consulta output)
        {
            output = null;
            /// <summary
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (consulta <= 0)
                    throw new InvalidIDException(consulta.ToString());
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
                if (!Consultas.Existe(consulta))
                    throw new DoesNotExistException(consulta.ToString());
            }
            catch
            {
                return false;
            }
            if (!Consultas.Procurar(consulta, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int consulta)
        {
            /// <summary>
            /// 1º fase de validações
            /// </summary>
            try
            {
                if (consulta <= 0)
                    throw new InvalidIDException(consulta.ToString());
            }
            catch
            {
                return false;
            }
            if (!Consultas.Existe(consulta))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Consulta> lConsultas)
        {
            bool aux = true;
            try
            {
                if (lConsultas == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileConsulta.Guardar(lConsultas, out string ex))
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
        public static bool Carregar(out List<Consulta> lConsultas, out string ex)
        {
            lConsultas = null;
            ex = string.Empty;
            try
            {
                if (!FileConsulta.Carregar(out lConsultas, out ex))
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
