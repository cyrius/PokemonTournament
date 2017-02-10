using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Collections.ObjectModel;

namespace StubDataAccessLayer
{
    public class DalManager : IDalManager
    {

        private List<Pokemon> listPkm;
        private List<Match> listMatch;
        private List<Stade> listStade;
        private List<Caracteristiques> listCarac;
        private List<Tournoi> listTournoi;
        private static List<Utilisateur> listUser =  new List<Utilisateur>() { new Utilisateur("test", "test", "test", "test")};

        public DalManager()
        {
            listPkm = new List<Pokemon>();
            listMatch = new List<Match>();
            listStade = new List<Stade>();
            listCarac = new List<Caracteristiques>();
            listTournoi = new List<Tournoi>();
            //listUser = new List<Utilisateur>();
            loadFakeData();
        }

        private void loadFakeData()
        {
            Pokemon pok1 = new Pokemon("DracoFeu", new Caracteristiques(100, 20, 10, 10), ETypeElement.Feu);
            Pokemon pok2 = new Pokemon("Tortank", new Caracteristiques(100, 20, 10, 10), ETypeElement.Eau);
            Pokemon pok3 = new Pokemon("Miaou", new Caracteristiques(520, 80, 10, 10), ETypeElement.Feu);
            Pokemon pok4 = new Pokemon("Florizarre", new Caracteristiques(250, 50, 30, 50), ETypeElement.Plante);
            Pokemon pok5 = new Pokemon("PIKACHU", new Caracteristiques(150, 20, 10, 10), ETypeElement.Tonnerre);
            Pokemon pok6 = new Pokemon("Nidoran", new Caracteristiques(175, 70, 10, 20), ETypeElement.Insecte);
            Pokemon pok7 = new Pokemon("Roucarnage", new Caracteristiques(350, 20, 10, 20), ETypeElement.Feu);
            Pokemon pok8 = new Pokemon("Rondoudou", new Caracteristiques(200, 50, 10, 20), ETypeElement.Terre);
            Pokemon pok9 = new Pokemon("Aspicot", new Caracteristiques(120, 40, 10, 20), ETypeElement.Terre);
            Pokemon pok10 = new Pokemon("Papilution", new Caracteristiques(125, 30, 10, 20), ETypeElement.Insecte);
            Pokemon pok11 = new Pokemon("Abra", new Caracteristiques(210, 30, 10, 20), ETypeElement.Plante);
            Pokemon pok12 = new Pokemon("Lamantine", new Caracteristiques(325, 40, 30, 60), ETypeElement.Eau);
            Pokemon pok13 = new Pokemon("Onix", new Caracteristiques(110, 50, 10, 20), ETypeElement.Sol);
            Pokemon pok14 = new Pokemon("Rhinocorne", new Caracteristiques(190, 50, 20, 10), ETypeElement.Sol);
            Pokemon pok15 = new Pokemon("Evoli", new Caracteristiques(230, 50, 20, 30), ETypeElement.Eau);
            Pokemon pok16 = new Pokemon("Feurisson", new Caracteristiques(300, 40, 30, 20), ETypeElement.Feu);
            listPkm.Add(pok1);
            listPkm.Add(pok2);
            listPkm.Add(pok3);
            listPkm.Add(pok4);
            listPkm.Add(pok5);
            listPkm.Add(pok6);
            listPkm.Add(pok7);
            listPkm.Add(pok8);
            listPkm.Add(pok9);
            listPkm.Add(pok10);
            listPkm.Add(pok11);
            listPkm.Add(pok12);
            listPkm.Add(pok13);
            listPkm.Add(pok14);
            listPkm.Add(pok15);
            listPkm.Add(pok16);

            Stade stade1 = new Stade(10000, "HotArena", ETypeElement.Feu);
            listStade.Add(stade1);
            listStade.Add(new Stade(7000, "GoutteArena", ETypeElement.Eau));
            listStade.Add(new Stade(12000, "JardinArena", ETypeElement.Plante));
            listStade.Add(new Stade(10000, "BoueArena", ETypeElement.Terre));

            listTournoi.Add(new Tournoi("PlopTournament"));

            listMatch.Add(new Match(pok1, pok2, stade1, EPhaseTournoi.Finale));
        }

        public List<Pokemon> GetAllPokemons()
        {
            return listPkm;
        }

        public List<Tournoi> GetAllTournois()
        {
            return listTournoi;
        }

        public List<Match> GetAllMatchs()
        {
            return listMatch;
        }
        public List<Stade> GetAllStades()
        {
            return listStade;
        }
        public List<Caracteristiques> GetAllCaracteristiques()
        {
            return listCarac;
        }


        public void ModifierStade(Stade stade, string nom, int nbPlaces, ETypeElement element)
        {
            stade.Nom = nom;
            stade.NbPlaces = nbPlaces;
            stade.Element = element;
        }

        public void SupprimerEntity(int id)
        {
            listStade.Remove(listStade.Find(s => s.ID == id));
            listPkm.Remove(listPkm.Find(s => s.ID == id));
            listMatch.Remove(listMatch.Find(s => s.ID == id));
        }

        public static Utilisateur GetUtilisateurByLogin(string login)
        {
            return listUser.Find(u => u.Login.ToLower() == login.ToLower());
        }

        public Pokemon GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }

        public Stade GetStadeById(int Id)
        {
            throw new NotImplementedException();
        }

        public Caracteristiques GetCaracteristiqueById(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertPokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public bool InsertStade(Stade stade)
        {
            throw new NotImplementedException();
        }

        public bool InsertCaracteristique(Caracteristiques carac)
        {
            throw new NotImplementedException();
        }

        public bool InsertMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStade(Stade stade)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCaracteristique(Caracteristiques carac)
        {
            throw new NotImplementedException();
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public void DeleteStade(Stade stade)
        {
            throw new NotImplementedException();
        }

        public void DeleteMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void DeleteCaracteristique(Caracteristiques carac)
        {
            throw new NotImplementedException();
        }
    }
}
