using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZooDLL;

namespace FilesDLL
{
    public class FileBilhete
    {
        #region ATRIBUTOS
        private const string ficheiro = "bilhetes.zoo";
        private static readonly string caminho = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\" + ficheiro;
        #endregion
        #region METODOS
        /// <summary>
        /// Metodo para guardar os bilhetes num ficheiro binario
        /// </summary>
        /// <param name="lBilhetes">Lista de bilhetes</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se guardar e false se nao guardar</returns>
        public static bool Guardar(List<Bilhete> lBilhetes, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenWrite(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, lBilhetes);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                ex = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Metodo para carregar os bilhetes de um ficheiro binario
        /// </summary>
        /// <param name="lBilhetes">Lista de bilhetes</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se carregar e false se nao carregar</returns>
        public static bool Carregar(out List<Bilhete> lBilhetes, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenRead(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                lBilhetes = (List<Bilhete>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                ex = e.Message;
                lBilhetes = null;
                return false;
            }
        }
        #endregion
    }
}
