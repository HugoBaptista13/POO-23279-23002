using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZooDLL;

namespace FilesDLL
{
    public class FileFuncionario
    {
        #region ATRIBUTOS
        private const string ficheiro = "funcionarios.zoo";
        private static readonly string caminho = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\" + ficheiro;
        #endregion
        #region METODOS
        /// <summary>
        /// Metodo para guardar os funcionarios num ficheiro binario
        /// </summary>
        /// <param name="lFuncionarios">Lista de funcionarios</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se guardar e false se nao guardar</returns>
        public static bool Guardar(List<Funcionario> lFuncionarios, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenWrite(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, lFuncionarios);
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
        /// Metodo para carregar os funcionarios de um ficheiro binario
        /// </summary>
        /// <param name="lFuncionarios">Lista de funcionarios</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se carregar e false se nao carregar</returns>
        public static bool Carregar(out List<Funcionario> lFuncionarios, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenRead(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                lFuncionarios = (List<Funcionario>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                ex = e.Message;
                lFuncionarios = null;
                return false;
            }
        }
        #endregion
    }
}
