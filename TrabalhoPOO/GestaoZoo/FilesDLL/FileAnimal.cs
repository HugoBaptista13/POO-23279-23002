using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZooDLL;

namespace FilesDLL
{
    public class FileAnimal
    {
		#region ATRIBUTOS
		private const string ficheiro = "animais.zoo";
		private static readonly string caminho = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\" + ficheiro;
		#endregion
        #region METODOS
        /// <summary>
        /// Metodo para guardar os animais num ficheiro binario
        /// </summary>
        /// <param name="lAnimais">Lista de animais</param>
		/// <param name="ex">Exceção</param>
        /// <returns>Retorna true se guardar e false se nao guardar</returns>
		public static bool Guardar(List<Animal> lAnimais, out string ex)
		{
			ex = string.Empty;
			try
			{
				Stream stream = File.OpenWrite(caminho);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, lAnimais);
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
		/// Metodo para carregar os animais de um ficheiro binario
		/// </summary>
		/// <param name="lAnimais">Lista de animais</param>
		/// <param name="ex">Exceção</param>
		/// <returns>Retorna true se carregar e false se nao carregar</returns>
		public static bool Carregar(out List<Animal> lAnimais, out string ex)
		{
			ex = string.Empty;
            try
            {
				Stream stream = File.OpenRead(caminho);
				BinaryFormatter bin = new BinaryFormatter();
				lAnimais = (List<Animal>)bin.Deserialize(stream);
				stream.Close();
				return true;
			}
			catch (IOException e)
			{
                ex = e.Message;
                lAnimais = null;
				return false;
			}
		}
		#endregion
    }
}
