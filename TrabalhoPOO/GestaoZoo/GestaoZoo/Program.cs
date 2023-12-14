using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;
using DadosDLL;

namespace GestaoZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Animais();
            Animal a = new Animal(1,"Peppa",6,"feminino","mamífero","Sus domesticus", "omnívoro",5,new DateTime(2023,11,12),new DateTime(2024,1,15),2,"Porca de estimação");
            bool aux1 = Animais.Inserir(a);
            bool aux2 = Animais.Inserir(new Animal(2, "Piggy", 6, "feminino", "mamífero", "Sus domesticus", "omnívoro", 5, new DateTime(2023, 11, 12), new DateTime(2024, 1, 15), 2, "Porca de estimação"));
            bool aux3 = Animais.Alterar(new Animal(2, "MissP", 8, "feminino", "mamífero", "Sus domesticus", "omnívoro", 5, new DateTime(2023, 11, 10), new DateTime(2024, 1, 15), 2, "Porca de estimação"));
            Animal b = new Animal(3, "Leandro", 4, "masculino", "mamífero", "Panthera leo", "carnívoro", 5, new DateTime(2023, 10, 24), new DateTime(2024, 1, 26), 7, "Leão mais novo");
            bool aux4 = Animais.Inserir(b);
            string[] aux5 = new string[Animais.Contar()];
            aux5 = Animais.Listar();
            bool aux6 = Animais.Remover(2);
            string[] aux7 = new string[Animais.Contar()];
            aux7 = Animais.Listar();
            bool aux8 = Animais.Inserir(new Animal(4, "Sifa", 7, "feminino", "mamífero", "Panthera leo", "carnívoro", 5, new DateTime(2023, 10, 22), new DateTime(2024, 1, 24), 7, "Leoa agressiva"));
            string[] aux9 = new string[Animais.Contar()];
            aux9 = Animais.Listar();
            bool aux10 = Animais.Procurar(2, out Animal c);
            string aux11 = c.Listar();
        }
    }
}
