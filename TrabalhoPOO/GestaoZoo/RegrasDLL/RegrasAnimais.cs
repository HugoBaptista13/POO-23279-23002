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
        #region OUTROS
        private static readonly string[] estados = {"Morto", "Mau", "Vivo", "Bom", "Muito Bom"};
        private static readonly string[] classes = { "Mamífero", "Ave", "Réptil", "Anfíbio", "Peixe", "Artrópode" };
        private static readonly string[] dietas = { "Carnívoro", "Herbívoro", "Omnívoro", "Piscívoro", "Frugívoro", "Insetívoro", "Granívoro", "Necrófago"};
        private static readonly string[] sexos = { "Feminino", "Masculino", "Assexuado"};
        private static bool IsAllLetters(string s)
        { 
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) || c != ' ')
                    return false;
            }
            return true;
        }
        private static bool IsValidState(string s)
        {
            foreach (string a in estados)
            {
                if (a!=s)
                    return false;
            }
            return true;
        }
        private static bool IsValidClass(string s)
        {
            foreach (string a in classes)
            {
                if (a != s)
                    return false;
            }
            return true;
        }
        private static bool IsValidDiet(string s)
        {
            foreach (string a in dietas)
            {
                if (a != s)
                    return false;
            }
            return true;
        }
        private static bool IsValidSex(string s)
        {
            foreach (string a in sexos)
            {
                if (a != s)
                    return false;
            }
            return true;
        }
        #endregion
        #region Inserir
        public static bool Inserir(Animal animal)
        {
            /// <summary>
            /// 
            /// </summary>
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
                    throw new InvalidDateException();

                if (animal.DataProximaConsulta == null)
                    throw new InvalidDateException();

                if (animal.Estado == null)
                    throw new ArgumentNullException("Estado", "Estado não pode ser nulo");

                if (animal.Recinto <= 0)
                    throw new NegativeNumberException(animal.Recinto.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (!IsAllLetters(animal.Nome.Trim()) || animal.Nome == string.Empty)
                    throw new InvalidNameException(animal.Nome.Trim());

                if (!IsAllLetters(animal.Sexo.Trim()) || animal.Sexo == string.Empty)
                    throw new InvalidTextException(animal.Sexo.Trim());

                if (!IsAllLetters(animal.Classe.Trim()) || animal.Classe == string.Empty)
                    throw new InvalidTextException(animal.Classe.Trim());

                if (!IsAllLetters(animal.Especie.Trim()) || animal.Especie == string.Empty)
                    throw new InvalidTextException(animal.Especie.Trim());

                if (!IsAllLetters(animal.Dieta.Trim()) || animal.Dieta == string.Empty)
                    throw new InvalidTextException(animal.Dieta.Trim());

                if (!IsAllLetters(animal.Estado.Trim()) || animal.Estado == string.Empty)
                    throw new InvalidTextException(animal.Estado.Trim());

                if (!IsValidState(animal.Estado.Trim()))
                    throw new InvalidStateException(animal.Estado.Trim());

                if (!IsValidClass(animal.Classe.Trim()))
                    throw new InvalidClassException(animal.Classe.Trim());

                if (!IsValidDiet(animal.Dieta.Trim()))
                    throw new InvalidDietException(animal.Dieta.Trim());

                if (!IsValidSex(animal.Sexo.Trim()))
                    throw new InvalidSexException(animal.Sexo.Trim());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (!Recintos.Existe(animal.Recinto))
                    throw new DoesNotExistException(animal.Recinto.ToString());

                if (animal.DataUltimaConsulta > animal.DataProximaConsulta)
                    throw new GreaterThanPreviousDateException(animal.DataUltimaConsulta.ToString(), animal.DataProximaConsulta.ToString());

                if (Animais.Existe(animal.Id))
                    throw new AlreadyExistsException(animal.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Animais.Inserir(animal))
                return false;
            return true;
        }
        #endregion
        #region Alterar
        public static bool Alterar(Animal animal)
        {
            /// <summary>
            /// 
            /// </summary>
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
                    throw new InvalidDateException();

                if (animal.DataProximaConsulta == null)
                    throw new InvalidDateException();

                if (animal.Estado == null)
                    throw new ArgumentNullException("Estado", "Estado não pode ser nulo");

                if (animal.Recinto <= 0)
                    throw new NegativeNumberException(animal.Recinto.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (!IsAllLetters(animal.Nome.Trim()) || animal.Nome == string.Empty)
                    throw new InvalidNameException(animal.Nome.Trim());

                if (!IsAllLetters(animal.Sexo.Trim()) || animal.Sexo == string.Empty)
                    throw new InvalidTextException(animal.Sexo.Trim());

                if (!IsAllLetters(animal.Classe.Trim()) || animal.Classe == string.Empty)
                    throw new InvalidTextException(animal.Classe.Trim());

                if (!IsAllLetters(animal.Especie.Trim()) || animal.Especie == string.Empty)
                    throw new InvalidTextException(animal.Especie.Trim());

                if (!IsAllLetters(animal.Dieta.Trim()) || animal.Dieta == string.Empty)
                    throw new InvalidTextException(animal.Dieta.Trim());

                if (!IsAllLetters(animal.Estado.Trim()) || animal.Estado == string.Empty)
                    throw new InvalidTextException(animal.Estado.Trim());

                if (!IsValidState(animal.Estado.Trim()))
                    throw new InvalidStateException(animal.Estado.Trim());

                if (!IsValidClass(animal.Classe.Trim()))
                    throw new InvalidClassException(animal.Classe.Trim());

                if (!IsValidDiet(animal.Dieta.Trim()))
                    throw new InvalidDietException(animal.Dieta.Trim());

                if (!IsValidSex(animal.Sexo.Trim()))
                    throw new InvalidSexException(animal.Sexo.Trim());
            }
            catch
            {
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (!Recintos.Existe(animal.Recinto))
                    throw new DoesNotExistException(animal.Recinto.ToString());

                if (animal.DataUltimaConsulta > animal.DataProximaConsulta)
                    throw new GreaterThanPreviousDateException(animal.DataUltimaConsulta.ToString(), animal.DataProximaConsulta.ToString());

                if (!Animais.Existe(animal.Id))
                    throw new DoesNotExistException(animal.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Animais.Alterar(animal))
                return false;
            return true;
        }
        #endregion
        #region Remover
        public static bool Remover(int animal)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (animal <= 0)
                    throw new InvalidIDException(animal.ToString());
            }
            catch
            {
                return false;
            }
            try
            {
                if (!Animais.Existe(animal))
                    throw new DoesNotExistException(animal.ToString());
            }
            catch
            {
                return false;
            }
            if (!Animais.Remover(animal))
                return false;
            return true;
        }
        #endregion
        #region Procurar
        public static bool Procurar(int animal, out Animal output)
        {
            output = null;
            /// <summary
            /// 
            /// </summary>
            try
            {
                if (animal <= 0)
                    throw new InvalidIDException(animal.ToString());
            }
            catch
            {
                return false;
            }
            /// <summary
            /// 
            /// </summary>
            try
            {
                if (!Animais.Existe(animal))
                    throw new DoesNotExistException(animal.ToString());
            }
            catch
            {
                return false;
            }
            if (!Animais.Procurar(animal, out output))
                return false;
            return true;
        }
        #endregion
        #region Existe
        public static bool Existe(int animal)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (animal <= 0)
                    throw new InvalidIDException(animal.ToString());}
            catch
            {
                return false;
            }
            if (!Animais.Existe(animal))
                return false;
            return true;
        }
        #endregion
        #region Guardar
        public static bool Guardar(List<Animal> lAnimais)
        {
            bool aux = true;
            try
            {
                if (lAnimais == null)
                    throw new InvalidDataException();
            }
            catch
            {
                return false;
            }
            try
            {
                if (!FileAnimal.Guardar(lAnimais, out string ex))
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
