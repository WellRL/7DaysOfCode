using RestSharp;
using System;
using System.Text.Json;



namespace _7DaysOfCode.Service
{
    public static class PesquisaPokemon
    {

        public static InfoPokemon BuscaPorEspecie(string especie)
        {

            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.ToLower()}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            return JsonSerializer.Deserialize<InfoPokemon>(response.Content);




        }
    }
}
