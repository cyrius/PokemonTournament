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
        List<Tournoi> GetAllTournois();
        List<Match> GetAllMatchs();
        List<Stade> GetAllStades();
        List<Caracteristiques> GetAllCaracteristiques();
        void ModifierStade(Stade stade, string nom, int nbPlaces, ETypeElement element);
        void SupprimerEntity(int id);
    }
}
