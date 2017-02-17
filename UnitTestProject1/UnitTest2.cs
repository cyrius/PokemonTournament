using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using StubDataAccessLayer;
using EntitiesLayer;
using System.Collections.Generic;

namespace UnitTestPokemon
{
    [TestClass]
    public class UnitTest2
    {
        IDalManager manager;
        Match match;
        Pokemon pok;

        public UnitTest2()
        {
            manager = new DalManagerSQL();
        }


        [TestMethod]
        public void TestGetAllStades()
        {
            List<Stade> stades = manager.GetAllStades();
            Assert.IsNotNull(stades, "error ! la liste est vide");
        }

        public void TestGetAllPokemon()
        {
            List<Pokemon> Pokemons = manager.GetAllPokemons();
            Assert.IsNotNull(Pokemons, "error ! la liste est vide");
        }

        [TestMethod]
        public void TestGetAllMatchs()
        {
           List<Match> matchs = manager.GetAllMatchs();
            Assert.IsNotNull(matchs, "La liste des matchs est vide"); 
        }        

        [TestMethod]
        public void TestMatch()
        {
            /* Création d'un match */
            Pokemon p = new Pokemon("pika",new Caracteristiques(10, 20, 10, 40), 0);
            Pokemon p1 = new Pokemon("dragon", new Caracteristiques(100, 20, 10, 40), 0);
            Match match = new Match(p, p1, new Stade(8, "test"), EPhaseTournoi.QuartFinale);
            Assert.AreNotEqual(match.Pokemon1.ID,0);
            Assert.AreNotEqual(match.Pokemon2.ID,0);
            Assert.AreEqual(match.PhaseTournoi, EPhaseTournoi.QuartFinale);
                   
        }

        [TestMethod]
        public void TestUser()
        {
            /* Création d'un utilisateur */
            Utilisateur u = new Utilisateur("Hamza", "DH28Z1NB", "Achil", "Pelai");
            Assert.IsFalse(u.Password.Length < 8, "le mot de passe doit contient 8 caractères au minimum");
            Assert.AreNotEqual(u.Login, "", "Error ! login empty");
            u.Nom = "Pierre";
            u.Prenom = "Lucas";
            Assert.AreEqual(u.Nom, "Pierre", "Error nom");
            Assert.AreEqual(u.Prenom, "Lucas", "Error prenom");
        }
    
 
    }
}
