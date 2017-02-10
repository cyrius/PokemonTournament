using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubDataAccessLayer
{
    public interface IDalManager
    {
        List<Pokemon> GetAllPokemons();
        Pokemon GetPokemonById(int id);
        List<Stade> GetAllStades();
        Stade GetStadeById(int Id);
        List<Match> GetAllMatchs();
        Caracteristiques GetCaracteristiqueById(int id);
        bool InsertPokemon(Pokemon pokemon);
        bool InsertStade(Stade stade);
        bool InsertCaracteristique(Caracteristiques carac);
        bool InsertMatch(Match match);
        bool UpdatePokemon(Pokemon pokemon);
        bool UpdateStade(Stade stade);
        bool UpdateCaracteristique(Caracteristiques carac);
        void DeletePokemon(Pokemon pokemon);
        void DeleteStade(Stade stade);
        void DeleteMatch(Match match);
        void DeleteCaracteristique(Caracteristiques carac);
    }
}
