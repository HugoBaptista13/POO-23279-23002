using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;
using FilesDLL;
using ExcecaoDLL;
using DadosDLL;

namespace RegrasDLL
{
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasAnimais
    {
        #region Inserir
        public static bool Inserir(Animal animal)
        {
            try
            {
                if (animal == null)
                    throw new ArgumentNullException("Animal", "Animal não pode ser nulo");
                if (animal.Id <= 0)
                    throw new InvalidIDException(animal.Id.ToString());
                if (animal.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");
                if (animal.Idade <= 0)
                    throw new NegativeNumberException(animal.Idade.ToString());
                if (animal.Sexo == null)
                    throw new ArgumentNullException("Sexo", "Sexo não pode ser nulo");
                if (animal.Classe == null)
                    throw new ArgumentNullException("Classe", "Classe não pode ser nulo");
                if (animal.Especie == null)
                    throw new ArgumentNullException("Especie", "Especie não pode ser nulo");
                if (animal.Dieta == null)
                    throw new ArgumentNullException("Dieta", "Dieta não pode ser nulo");
                if (animal.DataUltimaConsulta == null)
                    throw new ArgumentNullException();
                if (animal.DataProximaConsulta == null)
                    throw new ArgumentNullException();
                if (animal.Estado == null)
                    throw new ArgumentNullException("Estado", "Estado não pode ser nulo");
            }
            catch (Exception)
            {
                return false;
            }
            try
            {

            }
            catch (Exception)
            {
                return false;
            }
            if (!Animais.Inserir(animal))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasFuncionarios
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasEventos
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasBilhete
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasComidas
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasConsultas
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasLimpezas
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasRecintos
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }
    /// <summary>
    /// Regras de negócio
    /// </summary>
    public class RegrasVendas
    {
        #region Inserir
        #endregion
        #region Alterar
        #endregion
        #region Remover
        #endregion
        #region Procurar
        #endregion
        #region Existe
        #endregion
        #region Guardar
        #endregion
    }

}
