
using _7DaysOfCode.Service;
using _7DaysOfCode.View;

namespace _7DaysOfCode
{
    public class ControllerPokemon

    {
        private string nomeJogador { get; set; }
        private List<InfoPokemon> PokemonAdotados { get; set; }
        private Menus Mensagens { get; set; }


        public ControllerPokemon()
        {
            this.PokemonAdotados = new List<InfoPokemon>();
            this.Mensagens = new Menus();
        }

        public void Jogar()
        {
            string opcaoUsuario;
            int jogar = 1;

            while (jogar == 1)
            {
                Mensagens.MenuInicial();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        MenuAdocao();
                        break;
                    case "2":
                        MenuInteracao();
                        break;
                    case "3":
                        jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida! Tente Novamente. ");
                        break;
                }
            }
        }
        private void MenuAdocao()
        {
            string opcaoUsuario = "1", especie;
            InfoPokemon pokemon = new();


            especie = Mensagens.MenuAdocao();

            while (opcaoUsuario != "3")
            {
                opcaoUsuario = Mensagens.SaberMais(especie);

                switch (opcaoUsuario)
                {
                    case "1":
                        pokemon = PesquisaPokemon.BuscaPorEspecie(especie);
                        Mensagens.DetalhesPokemon(pokemon);
                        break;

                    case "2":
                        pokemon = PesquisaPokemon.BuscaPorEspecie(especie);
                        this.PokemonAdotados.Add(pokemon);
                        Mensagens.AdocaoBemSucedida(nomeJogador);
                        return;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Opção Inválida! Tente Novamente: ");
                        break;
                }


            }
        }

        private void MenuInteracao()
        {
            string opcaoUsuario = "0";
            int indicePokemon;

            indicePokemon = Mensagens.MenuConsultarPokemon(PokemonAdotados);
            while (opcaoUsuario != "5")
            {
                opcaoUsuario = Mensagens.InteragirComMascotes(PokemonAdotados[indicePokemon]);

                switch (opcaoUsuario)
                {
                    case "1":
                        Mensagens.DetalhesPokemonAdotado(PokemonAdotados[indicePokemon]);
                        break;
                    case "2":
                        PokemonAdotados[indicePokemon].Alimentar();
                        Mensagens.AlimentarPokemon();

                        if (!PokemonAdotados[indicePokemon].Saude())
                            Mensagens.GameOver(PokemonAdotados[indicePokemon]);

                        break;
                    case "3":
                        PokemonAdotados[indicePokemon].Brincar();
                        Mensagens.BrincarComPokemon();
                        if (!PokemonAdotados[indicePokemon].Saude())
                        {
                            Mensagens.GameOver(PokemonAdotados[indicePokemon]);
                        }
                        break;
                    case "4":
                        PokemonAdotados[indicePokemon].Dormir();
                        Mensagens.ColocarPokemonParaDormir();
                        if (!PokemonAdotados[indicePokemon].Saude())
                        {
                            Mensagens.GameOver(PokemonAdotados[indicePokemon]);
                        }
                        break;
                        case "5":
                        return;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }

        }
    }
}
