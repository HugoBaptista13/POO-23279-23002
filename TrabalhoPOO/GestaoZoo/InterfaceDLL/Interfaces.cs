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

    public interface IAnimal
    {
        int Id { get; set; }
        string Nome { get; set; }
        int Idade { get; set; }
        string Sexo { get; set; }
        string Classe { get; set; }
        string Especie { get; set; }
        string Dieta { get; set; }
        int Estado { get; set; }
        DateTime DataUltimaConsulta { get; set; }
        DateTime DataProximaConsulta { get; set; }
        string Recinto { get; set; }
        string Descricao { get; set; }
    }
    public interface IRecintos
    {
        void Listar();
        bool Inserir();
        bool Alterar();
        bool Remover();
        bool existe();
    }

}
