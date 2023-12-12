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
        int Id 
        { get; set; }
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
    public interface IBilhete
    {
        int Id { get; set; }
        string Tipo { get; set; }
        double Preco { get; set; }
        double Desconto { get; set; }
        string Listar();
    }
    public interface IComida
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Tipo { get; set; }
        string Dieta { get; set; }
        int Stock { get; set; }
        string Listar();
    }
    public interface IConsulta
    {
        int Id { get; set; }
        int Animal { get; set; }
        int Funcionario { get; set; }
        DateTime Data { get; set; }
        string Listar();
    }
    public interface IEvento
    {
        int Id { get; set; }
        string Nome { get; set; }
        int Lotacao { get; set; }
        int LotacaoTotal { get; set; }
        string Local { get; set; }
        DateTime DataInicio { get; set; }
        DateTime DataFim { get; set; }
        string Listar();
    }
    public interface IRecintos
    {
        void Listar();
        bool Inserir();
        bool Alterar();
        bool Remover();
        bool Existe();
    }

}
