using DadosDLL;
using ExcecaoDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;

namespace RegrasDLL
{
    public class RegrasRecintos
    {
        #region outros
        private static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) || c != ' ')
                    return false;
            }
            return true;
        }
        #endregion
        #region Inserir
        public static bool Inserir(Recinto recinto)
        {
            /// <summary>
            /// 
            /// </summary>
            try
            {
                if (recinto == null)
                    throw new ArgumentNullException("Recinto", "Funcionario não pode ser nulo");

                if (recinto.Id <= 0)
                    throw new InvalidIDException(recinto.Id.ToString());

                if (recinto.Nome == null)
                    throw new ArgumentNullException("Nome", "Nome não pode ser nulo");

                if (recinto.Tipo == null)
                    throw new ArgumentNullException("Tipo", "Tipo não pode ser nulo");

                if (recinto.Comprimento <= 0)
                    throw new NegativeNumberException(recinto.Comprimento.ToString());

                if (recinto.Largura <= 0)
                    throw new NegativeNumberException(recinto.Largura.ToString());

                if (recinto.Altura <= 0)
                    throw new NegativeNumberException(recinto.Altura.ToString());
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
                if (!IsAllLetters(recinto.Nome.Trim()) || recinto.Nome == string.Empty)
                    throw new InvalidNameException(recinto.Nome.Trim());
                if (!IsAllLetters(recinto.Tipo.Trim()) || recinto.Tipo == string.Empty)
                    throw new InvalidTextException(recinto.Tipo.Trim());
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

                if (Recintos.Existe(recinto.Id))
                    throw new AlreadyExistsException(recinto.Id.ToString());
            }
            catch
            {
                return false;
            }
            if (!Recintos.Inserir(recinto))
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
}
