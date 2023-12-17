using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZooDLL;

namespace FilesDLL
{
    public class FileVenda
    {
        #region ATRIBUTOS
        private const string ficheiro = "vendas.zoo";
        private static readonly string caminho = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\" + ficheiro;
        #endregion
        #region METODOS
        /// <summary>
        /// Metodo para guardar as vendas num ficheiro binario
        /// </summary>
        /// <param name="lVendas">Lista de vendas</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se guardar e false se nao guardar</returns>
        public static bool Guardar(List<Venda> lVendas, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenWrite(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, lVendas);
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
        /// Metodo para carregar as vendas de um ficheiro binario
        /// </summary>
        /// <param name="lVendas">Lista de vendas</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se carregar e false se nao carregar</returns>
        public static bool Carregar(out List<Venda> lVendas, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenRead(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                lVendas = (List<Venda>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                ex = e.Message;
                lVendas = null;
                return false;
            }
        }
        #endregion
    }
}
