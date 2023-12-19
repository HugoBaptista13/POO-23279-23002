using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDLL;
using DadosDLL;
using FilesDLL;
using RegrasDLL;
using System.Net;

namespace GestaoZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region INICIALIZACAO
            new Animais();
            new Bilhetes();
            new Vendas();
            new Recintos();
            new Funcionarios();
            new Eventos();
            new Consultas();
            new Limpezas();
            new Comidas();

            bool cAnimais = RegrasAnimais.Carregar(out List<Animal> animais);
            if (cAnimais)
                Animais.LAnimais = animais;

            bool cRecintos = RegrasRecintos.Carregar(out List<Recinto> recintos);
            if (cRecintos)
                Recintos.LRecintos = recintos;

            bool cBilhetes = RegrasBilhetes.Carregar(out List<Bilhete> bilhetes);
            if (cBilhetes)
                Bilhetes.LBilhetes = bilhetes;

            bool cVendas = RegrasVendas.Carregar(out List<Venda> vendas);
            if (cVendas)
                Vendas.LVendas = vendas;

            bool cFuncionarios = RegrasFuncionarios.Carregar(out List<Funcionario> funcionarios);
            if (cFuncionarios)
                Funcionarios.LFuncionarios = funcionarios;

            bool cEventos = RegrasEventos.Carregar(out List<Evento> eventos);
            if (cEventos)
                Eventos.LEventos = eventos;

            bool cConsultas = RegrasConsultas.Carregar(out List<Consulta> consultas);
            if (cConsultas)
                Consultas.LConsultas = consultas;

            bool cLimpezas = RegrasLimpezas.Carregar(out List<Limpeza> limpezas);
            if (cLimpezas)
                Limpezas.LLimpezas = limpezas;

            bool cComidas = RegrasComidas.Carregar(out List<Comida> comidas);
            if (cComidas)
                Comidas.LComidas = comidas;

            #endregion
            #region TESTES_ANIMAIS
            //new Animais();
            //Animal a = new Animal(1,"Peppa",6,"feminino","mamífero","Sus domesticus", "omnívoro","Muito Bom",new DateTime(2023,11,12),new DateTime(2024,1,15),2,"Porca de estimação");
            //bool aux1 = Animais.Inserir(a);
            //bool aux2 = Animais.Inserir(new Animal(2, "Piggy", 6, "feminino", "mamífero", "Sus domesticus", "omnívoro", "Muito Bom", new DateTime(2023, 11, 12), new DateTime(2024, 1, 15), 2, "Porca de estimação"));
            //bool aux3 = Animais.Alterar(new Animal(2, "MissP", 8, "feminino", "mamífero", "Sus domesticus", "omnívoro", "Muito Bom", new DateTime(2023, 11, 10), new DateTime(2024, 1, 15), 2, "Porca de estimação"));
            //Animal b = new Animal(3, "Leandro", 4, "masculino", "mamífero", "Panthera leo", "carnívoro", "Muito Bom", new DateTime(2023, 10, 24), new DateTime(2024, 1, 26), 7, "Leão mais novo");
            //bool aux4 = Animais.Inserir(b);
            //List<Animal> aux5 = new List<Animal>();
            //aux5 = Animais.Listar();
            //bool aux6 = Animais.Remover(2);
            //List<Animal> aux7 = new List<Animal>();
            //aux7 = Animais.Listar();
            //bool aux8 = Animais.Inserir(new Animal(4, "Sifa", 7, "feminino", "mamífero", "Panthera leo", "carnívoro", "Bom", new DateTime(2023, 10, 22), new DateTime(2024, 1, 24), 7, "Leoa agressiva"));
            //List<Animal> aux9 = new List<Animal>();
            //aux9 = Animais.Listar();
            //bool aux10 = Animais.Procurar(2, out Animal c);
            //string aux11 = c.Listar();

            //bool aux12 = FileAnimal.Guardar(Animais.LAnimais, out string ex);
            //bool aux13 = FileAnimal.Carregar(out List<Animal> lAnimais, out string ex2);
            #endregion

            #region TESTES_REGRAS_ANIMAIS

            Recinto r1 = new Recinto(2, "Recinto dos Porcos", "Normal", 40, 40, 10);
            Recinto r2 = new Recinto(7, "Santuário dos Leões", "Santuário", 600, 400, 20);
            Recinto r3 = new Recinto(4, "Recinto das Focas", "Misto", 100, 100, 20);

            bool aux1 = RegrasRecintos.Inserir(r1);
            bool aux2 = RegrasRecintos.Inserir(r2);
            bool aux3 = RegrasRecintos.Inserir(r3);

            bool guardarR = RegrasRecintos.Guardar(Recintos.LRecintos);


            if (aux1 && aux2 && aux3)
                return;

            Animal a = new Animal(1, "Peppa", 6, "Feminino", "Mamífero", "Sus domesticus", "Omnívoro", "Muito Bom", new DateTime(2023, 11, 12), new DateTime(2024, 1, 15), 2, "Porca de estimação");
            bool aux4 = RegrasAnimais.Inserir(a);
            Animal b = new Animal(3, "Leandro", 4, "Masculino", "Mamífero", "Panthera leo", "Carnívoro", "Muito Bom", new DateTime(2023, 10, 24), new DateTime(2024, 1, 26), 7, "Leão mais novo");
            bool aux5 = RegrasAnimais.Inserir(new Animal(2, "Piggy", 6, "Feminino", "Mamífero", "Sus domesticus", "Omnívoro", "Muito Bom", new DateTime(2023, 11, 12), new DateTime(2024, 1, 15), 2, "Porca de estimação"));
            bool aux6 = RegrasAnimais.Alterar(new Animal(2, "MissP", 8, "Feminino", "Mamífero", "Sus domesticus", "Omnívoro", "Muito Bom", new DateTime(2023, 11, 10), new DateTime(2024, 1, 15), 2, "Porca de estimação"));
            bool aux7 = RegrasAnimais.Inserir(b);
            bool aux8 = RegrasAnimais.Inserir(new Animal(2, "Teste", 4, "Masculino", "Mamífero", "Especie", "Necrófago", "Sólido", new DateTime(2023, 11, 10), new DateTime(2024, 1, 15), 2, "Teste"));
            #endregion
        }
    }
}
