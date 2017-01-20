using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;
using EntitiesLayer;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private DalManager dalManager{ get; set; }
        public BusinessManager()
        {
            dalManager = new DalManager();
        }

        public List<string> DisplaAllStades()
        {
            return dalManager.GetAllStades().Select(s => s.ToString()).ToList();
        }

        public List<string> DisplaStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().Where( s => s.NbPlaces >= placeMin ).Select(s => s.ToString()).ToList();
        }

        public List<string> DisplayPokemonByType(ETypeElement type)
        {
            return dalManager.GetPokemonsByType(type).Select(s => s.ToString()).ToList();
        }

        public List<string> DisplayPokemonBizarre()
        {
            return dalManager.GetAllPokemons().Where( p => p.Caracteristiques.PV >= 50 && p.Caracteristiques.Atk >= 3).Select( p => p.ToString()).ToList();
        }

        public List<Stade> GetAllStades()
        {
            return dalManager.GetAllStades();
        }

        public List<Stade> GetStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().FindAll(s => s.NbPlaces >= placeMin);
        }

        public List<Pokemon> GetPokemonByType(ETypeElement type)
        {
            return dalManager.GetPokemonsByType(type);
        }

        public List<Pokemon> GetPokemonBizarre()
        {
            return dalManager.GetAllPokemons().FindAll(p => p.Caracteristiques.PV >= 50 && p.Caracteristiques.Atk >= 3);
        }
        public List<Pokemon> GetAllPokemons()
        {
            return dalManager.GetAllPokemons();
        }
        public List<Match> GetAllMatchs()
        {
            return dalManager.GetAllMatchs();
        }
        public List<Caracteristiques> GetAllCaracteristique()
        {
            return dalManager.GetAllCaracteristiques();
        }

        public void AjouterStade(Stade stade)
        {
            dalManager.AjouterStade(stade);
        }

        public void SupprimerStade(Stade stade)
        {
            dalManager.SupprimerStade(stade);
        }

        public void ModifierStade(Stade stade, String nom, int nbPlaces, ETypeElement element)
        {
            dalManager.ModifierStade(stade, nom, nbPlaces, element);
        }

        public static bool CheckConnexionUser(string username, string password)
        {
            Utilisateur user = DalManager.GetUtilisateurByLogin(username);
            if(user != null && user.Password == password)
            {
                return true;
            }
            return false;
        }



    }

}
