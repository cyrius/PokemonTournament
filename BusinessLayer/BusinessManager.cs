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

        /// <summary>
        /// Change la DAL pour utiliser le Stub
        /// </summary>
        public void useDalStub()
        {
            dalManager = new DalManager();
        }

        /// <summary>
        /// Change la DAL pour utiliser la BDD SQL
        /// </summary>
        public void useDalSQL()
        {
            dalManager = new DalManagerSQL();
        }

        #region stades

        /// <summary>
        /// Renvoie les Stades sosu format texte
        /// </summary>
        /// <returns>Une liste de string</returns>
        public List<string> DisplaAllStades()
        {
            return dalManager.GetAllStades().Select(s => s.ToString()).ToList();
        }

        /// <summary>
        /// Renvoie une liste de stade
        /// </summary>
        /// <returns>La liste des stade</returns>
        public List<Stade> GetAllStades()
        {
            return dalManager.GetAllStades();
        }

        /// <summary>
        /// Renvoi les stades ayant plsu de x places
        /// </summary>
        /// <param name="placeMin">le nombre de place min</param>
        /// <returns>liste de stade</returns>
        public List<Stade> GetStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().FindAll(s => s.NbPlaces >= placeMin);
        }
        
        /// <summary>
        /// Renvoi les stades ayant plus de x places en format texte
        /// </summary>
        /// <param name="placeMin">le nombre de place min</param>
        /// <returns>Une liste de String</returns>
        public List<string> DisplayStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().Where(s => s.NbPlaces >= placeMin ).Select(s => s.ToString()).ToList();
        }

        /// <summary>
        /// Ajoute un stade à la DAL
        /// </summary>
        /// <param name="stade">le stade à ajouter</param>
        /// <returns></returns>
        public bool AddStade(Stade stade)
        {
            return dalManager.InsertStade(stade);
        }

        /// <summary>
        /// Met à jour le Stade dans la DAL
        /// </summary>
        /// <param name="stade">Le stade à mettre à jour</param>
        /// <returns>boolen si réussi true</returns>
        public bool UpdateStade(Stade stade)
        {
            return dalManager.UpdateStade(stade);
        }

        /// <summary>
        /// Supprime un Stade de la DAL 
        /// </summary>
        /// <param name="stade">Le stade à supprimer</param>
        public void DeleteStade(Stade stade)
        {
            dalManager.DeleteStade(stade);
        }

        #endregion

        #region pokemons

        /// <summary>
        /// Récupère tout les pokemons
        /// </summary>
        /// <returns>Liste de Pokemon</returns>
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
            return dalManager.GetAllPokemons().FindAll(p => p.Caracteristiques.PV >= 100 && p.Caracteristiques.Atk >= 25);
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
        public bool AddMatch(Match match)
        {
            return dalManager.InsertMatch(match);
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
