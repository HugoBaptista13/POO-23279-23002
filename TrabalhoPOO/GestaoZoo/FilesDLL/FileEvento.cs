﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZooDLL;

namespace FilesDLL
{
    public class FileEvento
    {
        #region ATRIBUTOS
        private const string ficheiro = "eventos.zoo";
        private static readonly string caminho = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\" + ficheiro;
        #endregion
        #region METODOS
        /// <summary>
        /// Metodo para guardar os eventos num ficheiro binario
        /// </summary>
        /// <param name="lEventos">Lista de eventos</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se guardar e false se nao guardar</returns>
        public static bool Guardar(List<Evento> lEventos, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenWrite(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, lEventos);
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
        /// Metodo para carregar os eventos de um ficheiro binario
        /// </summary>
        /// <param name="lEventos">Lista de eventos</param>
        /// <param name="ex">Exceção</param>
        /// <returns>Retorna true se carregar e false se nao carregar</returns>
        public static bool Carregar(out List<Evento> lEventos, out string ex)
        {
            ex = string.Empty;
            try
            {
                Stream stream = File.OpenRead(caminho);
                BinaryFormatter bin = new BinaryFormatter();
                lEventos = (List<Evento>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                ex = e.Message;
                lEventos = null;
                return false;
            }
        }
        #endregion
    }
}
