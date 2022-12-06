using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7DaysOfCode.Modelos;
using _7DaysOfCode;

namespace _7DaysOfCode.View
{
    internal class Menus
    {
        private string nomeJogador { get; set; }

        public Menus()
        {
            BoasVindas();
        }
        public void BoasVindas()
        {
            Console.WriteLine(@" 
                                                                         
      █████     ██    █    █    ██     ████    ████   █████   ████   █    █  █ 
        █      █  █   ██  ██   █  █   █    █  █    █    █    █    █  █    █  █ 
        █     █    █  █ ██ █  █    █  █       █    █    █    █       ██████  █ 
        █     ██████  █    █  ██████  █  ███  █    █    █    █       █    █  █ 
        █     █    █  █    █  █    █  █    █  █    █    █    █    █  █    █  █ 
        █     █    █  █    █  █    █   ████    ████     █     ████   █    █  █

");

            Console.WriteLine("Olá! Qual é o seu nome?");
            nomeJogador = Console.ReadLine().ToUpper();
        }

        public void MenuInicial()
        {
            Console.WriteLine("\n\n=================== MENU ===================");
            Console.WriteLine($"{nomeJogador} Você deseja:");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus macotes");
            Console.WriteLine("3 - Sair");
            Console.WriteLine($"Digite o número da opção desejada:");

            

        }

        public string MenuAdocao()
        {
            Console.WriteLine("\n============== ADOTAR UM MASCOTE ==============");
            Console.WriteLine($"{nomeJogador} Escolha uma espécie:");
            Console.WriteLine("Eevee");
            Console.WriteLine("Pikachu");
            Console.WriteLine("Bulbasaur");
            Console.WriteLine("Charmander");
            Console.WriteLine("Squirtle");
            Console.WriteLine("Digite o nome do Pokemon que quer escolher: ");
            return Console.ReadLine().ToUpper();
            
        }

        public string SaberMais(string especie)
        {
            Console.WriteLine("\n\n=================== MENU ===================");
            Console.WriteLine($"{nomeJogador} você deseja:");
            Console.WriteLine($"1 - saber mais sobre o {especie}");
            Console.WriteLine($"2 - adotar {especie}");
            Console.WriteLine($"3 - voltar");
            Console.WriteLine($"Digite o número da opção desejada");

            return Console.ReadLine().ToUpper();
            
        }

        public void DetalhesPokemon(InfoPokemon pokemon)
        {
            Console.WriteLine("\n================ INFORMAÇÕES ================");
            Console.WriteLine($"Nome: {pokemon.name.ToUpper()}");
            Console.WriteLine($"Altura: {pokemon.height}m");
            Console.WriteLine($"Peso:  {pokemon.weight}kg");



            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidade in pokemon.abilities)
            {
                Console.Write(habilidade.ability.name.ToUpper() + "\r\n");
            }
            Console.WriteLine();
            
        }

        public void DetalhesPokemonAdotado(InfoPokemon pokemon)
        {
            Console.WriteLine("\n================ INFORMAÇÕES ================");
            
            Console.WriteLine($"Nome: {pokemon.name.ToUpper()}");
            Console.WriteLine($"Altura: {pokemon.height}m");
            Console.WriteLine($"Peso:  {pokemon.weight}kg");

            TimeSpan idade = DateTime.Now.Subtract(pokemon.DataNascimento);

            Console.WriteLine($"Idade: {idade.Minutes} anos");

            if (pokemon.Fome())
                Console.WriteLine($"{pokemon.name.ToUpper()} Está com fome!");
            else
                Console.WriteLine($"{pokemon.name.ToUpper()} Está alimentado!");

            if (pokemon.Humor > 5)
                Console.WriteLine($"{pokemon.name.ToUpper()} Está feliz!");
            else
                Console.WriteLine($"{pokemon.name.ToUpper()} Está triste!");
            if (pokemon.Sono())
                Console.WriteLine($"{pokemon.name.ToUpper()} Está cansado!");
            else
                Console.WriteLine($"{pokemon.name.ToUpper()} Está descansado!");
            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidade in pokemon.abilities)
            {
                Console.Write(habilidade.ability.name.ToUpper() + "\n\n");
            }
            
        }

        public void AdocaoBemSucedida(string especie)
        {
            Console.WriteLine($"{nomeJogador} seu Pokemon foi adotado com sucesso, o ovo está chocando: ");

            Console.WriteLine(@"
               ███╗
             ███████╗
            █████████╗
            █████████║
            █████████║
            ╚███████╔╝
             ╚═════╝");
        }

        public int MenuConsultarPokemon(List<InfoPokemon> Pokemons)
        {
            Console.WriteLine("===============================================\n\n");
            Console.WriteLine($"Você possui {Pokemons.Count} Pokemon adotados.");
            for (int indicePokemon = 0; indicePokemon < Pokemons.Count; indicePokemon++)
            {
                Console.WriteLine($"{indicePokemon} - {Pokemons[indicePokemon].name.ToUpper()}");
            }

            Console.WriteLine($"Qual Pokemon você deseja interagir?");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string InteragirComMascotes(InfoPokemon pokemon)
        {
            Console.WriteLine("===============================================\n\n");
            Console.WriteLine($"{nomeJogador} vocÊ deseja:");
            Console.WriteLine($"1 - saber como {pokemon.name.ToUpper()} está");
            Console.WriteLine($"2 - alimentar o {pokemon.name.ToUpper()}");
            Console.WriteLine($"3 - brincar com {pokemon.name.ToUpper()} ");
            Console.WriteLine($"4 - colocar {pokemon.name.ToUpper()} para dormir");
            Console.WriteLine($"5 - voltar");

            return Console.ReadLine().ToUpper();
        }

        public void AlimentarPokemon()
        {
            Console.WriteLine("===============================================\n\n");
            Console.WriteLine($" ( ◕ ◡ ◕ )");
            Console.WriteLine($"Pokemon Alimentado");
        }

        public void BrincarComPokemon()
        {
            Console.WriteLine("===============================================\n\n");
            Console.WriteLine($"( ^ ◡ ^ )");
            Console.WriteLine($"Pokemon está mais feliz");
        }

        public void ColocarPokemonParaDormir()
        {
            Console.WriteLine("===============================================\n\n");
            Console.WriteLine($"(∪ ◡ ∪)");
            Console.WriteLine($"Pokemon está descansado");
        }
        public void GameOver(InfoPokemon pokemon)
        {
            Console.WriteLine("===============================================\n\n");
            Console.WriteLine("O Mascote morreu de " + (pokemon.Humor > 0 ? "fome" : "tristeza" , "cansaço" ));

            Console.WriteLine(@"
              █████      █     █     █  ███████      ███████  █     █  ███████  ██████  
             █     █    █ █    ██   ██  █            █     █  █     █  █        █     █ 
             █         █   █   █ █ █ █  █            █     █  █     █  █        █     █ 
             █  ████  █     █  █  █  █  █████        █     █  █     █  █████    ██████  
             █     █  ███████  █     █  █            █     █   █   █   █        █   █   
             █     █  █     █  █     █  █            █     █    █ █    █        █    █  
              █████   █     █  █     █  ███████      ███████     █     ███████  █     █ ");
        }

    }
}
