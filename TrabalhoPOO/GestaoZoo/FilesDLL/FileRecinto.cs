using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZooDLL;

namespace FilesDLL
{
    public class FileRecinto
    {
        #region ATRIBUTOS
        private const string ficheiro = "recintos.zoo";
        private static readonly string caminho = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\" + ficheiro;
        #endregion
        #region METODOS
        /// <summary>
        /// Metodo para guardar os recintos num ficheiro binario
        /// </summary>
        /// <param name="lRecintos">Lista de recintos</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se guardar e false se nao guardar</returns>
        public static bool Guardar(List<Recinto> lRecintos, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenWrite(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, lRecintos);
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
        /// Metodo para carregar os recintos de um ficheiro binario
        /// </summary>
        /// <param name="lRecintos">Lista de recintos</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se carregar e false se nao carregar</returns>
        public static bool Carregar(out List<Recinto> lRecintos, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenRead(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                lRecintos = (List<Recinto>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                ex = e.Message;
                lRecintos = null;
                return false;
            }
        }
        #endregion
    }
}
