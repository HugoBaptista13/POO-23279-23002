using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDLL
{
    public interface IRecinto
    {
        int Id
        { 
            get; set; 
        }
        string Nome 
        { 
            get; set; 
        }
        string Tipo
        { 
            get; set;
        }
        double Comprimento 
        {
            get; set; 
        }
        double Largura 
        { 
            get; set;
        }
        double Altura
        { 
            get; set; 
        }
        string Listar();
        double CalculaArea();
    }
    public interface IRecintos
    {
        void Listar();
        bool Inserir();
        bool Alterar();
        bool Remover();
    }
}
