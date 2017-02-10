using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;
using EntitiesLayer;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private IDalManager dalManager { get; set; }

        private static volatile BusinessManager instance;
        private static object syncRoot = new Object();       

        public static BusinessManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new BusinessManager();
                    }
                }

                return instance;
            }
        }

        private BusinessManager()
        {
            useDalStub();
        }

        public void useDalStub()
        {
            dalManager = new DalManager();
        }

        public void useDalSQL()
        {
            dalManager = new DalManagerSQL();
        }

        #region stades

        public List<string> DisplaAllStades()
        {
            return dalManager.GetAllStades().Select(s => s.ToString()).ToList();
        }

        public List<Stade> GetAllStades()
        {
            return dalManager.GetAllStades();
        }

        public List<Stade> GetStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().FindAll(s => s.NbPlaces >= placeMin);
        }
        
        public List<string> DisplayStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().Where(s => s.NbPlaces >= placeMin ).Select(s => s.ToString()).ToList();
        }

        public bool AddStade(Stade stade)
        {
            return dalManager.InsertStade(stade);
        }

        public bool UpdateStade(Stade stade)
        {
            return dalManager.UpdateStade(stade);
        }
        public void DeleteStade(Stade stade)
        {
            dalManager.DeleteStade(stade);
        }

        #endregion

        #region pokemons

        public List<Pokemon> GetAllPokemons()
        {
            return dalManager.GetAllPokemons();
        }

        public List<string> DisplayPokemonBizarre()
        {
            return dalManager.GetAllPokemons().Where( p => p.Caracteristiques.PV >= 50 && p.Caracteristiques.Atk >= 3).Select( p => p.ToString()).ToList();
        }

        public List<Pokemon> GetPokemonBizarre()
        {
            return dalManager.GetAllPokemons().FindAll(p => p.Caracteristiques.PV >= 50 && p.Caracteristiques.Atk >= 3);
        }

        public bool AddPokemon(Pokemon pokemon)
        {
            return dalManager.InsertPokemon(pokemon);
        }
        public bool UpdatePokemon(Pokemon pokemon)
        {
            return dalManager.UpdatePokemon(pokemon);
        }
        public void DeletePokemon(Pokemon pokemon)
        {
            dalManager.DeletePokemon(pokemon);
        }

        #endregion

        #region matchs

        public List<Match> GetAllMatchs()
        {
            return dalManager.GetAllMatchs();
        }

        #endregion

        #region tournoi


        #endregion

        public bool CheckConnexionUser(string username, string password)
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
