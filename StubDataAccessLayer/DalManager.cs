﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {

        private List<Pokemon> listPkm;
        private List<Match> listMatch;
        private List<Stade> listStade;
        private List<Caracteristiques> listCarac;
        private static List<Utilisateur> listUser =  new List<Utilisateur>() { new Utilisateur("test", "test", "test", "test")};

        public DalManager()
        {
            listPkm = new List<Pokemon>();
            listMatch = new List<Match>();
            listStade = new List<Stade>();
            listCarac = new List<Caracteristiques>();
            //listUser = new List<Utilisateur>();
            loadFakeData();
        }

        private void loadFakeData()
        {
            listPkm.Add(new Pokemon("DracoFeu", new Caracteristiques(10, 1, 1, 1, 1, 1), ETypeElement.Feu));
            listPkm.Add(new Pokemon("Tortank", new Caracteristiques(10, 1, 1, 1, 1, 1), ETypeElement.Eau));
            listPkm.Add(new Pokemon("Florizarre", new Caracteristiques(10, 5, 5, 5, 5, 5), ETypeElement.Plante));
            listPkm.Add(new Pokemon("PIKACHU", new Caracteristiques(100, 10, 10, 10, 10, 10), ETypeElement.Terre));

            listStade.Add(new Stade(10000, "HotArena",ETypeElement.Feu));
            listStade.Add(new Stade(7000, "GoutteArena", ETypeElement.Eau));
            listStade.Add(new Stade(12000, "JardinArena", ETypeElement.Plante));
            listStade.Add(new Stade(10000, "BoueArena", ETypeElement.Terre));

        }

        public List<Pokemon> GetAllPokemons()
        {
            return listPkm;
        }
        public List<Pokemon> GetPokemonsByType(ETypeElement type)
        {
            return listPkm.FindAll(p => p.Type == type);
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

        
        public void AjouterStade(Stade stade)
        {
            listStade.Add(stade);
        }

        public static Utilisateur GetUtilisateurByLogin(string login)
        {
            return listUser.Find(u => u.Login.ToLower() == login.ToLower());
        }


    }
}