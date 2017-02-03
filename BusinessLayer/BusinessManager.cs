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
        private DalManager dalManager{ get; set; }
        private DalManagerSQL dalManagerSQL { get; set; }
   
        public BusinessManager()
        {
            dalManager = new DalManager();
            dalManagerSQL = new DalManagerSQL();
        }

        public List<string> DisplaAllStades()
        {
            return dalManager.GetAllStades().Select(s => s.ToString()).ToList();
        }

        public List<string> DisplaStadesSupPlaces(int placeMin)
        {
            return dalManager.GetAllStades().Where(s => s.NbPlaces >= placeMin ).Select(s => s.ToString()).ToList();
        }

        public List<string> DisplayPokemonByType(ETypeElement type)
        {
            return dalManager.GetPokemonsByType(type).Select(s => s.ToString()).ToList();
        }

        public List<string> DisplayPokemonBizarre()
        {
            return dalManager.GetAllPokemons().Where( p => p.Caracteristiques.PV >= 50 && p.Caracteristiques.Atk >= 3).Select( p => p.ToString()).ToList();
        }

        public ObservableCollection<EntityObject> GetAllStades()
        {
            ObservableCollection<EntityObject> listStadeEntity = new ObservableCollection<EntityObject>();
            foreach (Stade stade in dalManager.GetAllStades())
            {
                listStadeEntity.Add(stade);
            }
            return listStadeEntity;
        }

        public ObservableCollection<EntityObject> GetAllTournois()
        {
            ObservableCollection<EntityObject> listTournoisEntity = new ObservableCollection<EntityObject>();
            foreach (Tournoi tournoi in dalManager.GetAllTournois())
            {
                listTournoisEntity.Add(tournoi);
            }
            return listTournoisEntity;
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

        public ObservableCollection<EntityObject> GetAllPokemons()
        {
            ObservableCollection<EntityObject> listPokemonEntity = new ObservableCollection<EntityObject>();
            foreach (Pokemon pok in dalManagerSQL.GetAllPokemons())
            {
                listPokemonEntity.Add(pok);
            }
            return listPokemonEntity;
        }

        public ObservableCollection<EntityObject> GetAllMatchs()
        {
            ObservableCollection<EntityObject> listMatchEntity = new ObservableCollection<EntityObject>();
            foreach (Match match in dalManager.GetAllMatchs())
            {
                listMatchEntity.Add(match);
            }
            return listMatchEntity;
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

        public void SupprimerEntity(EntityObject aSupprimer)
        {
            if (aSupprimer != null)
                dalManager.SupprimerEntity(aSupprimer.ID);
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
