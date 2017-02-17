using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusinessLayer;
using StubDataAccessLayer;
using EntitiesLayer;

namespace UnitTestPokemon
{
    [TestClass]
    public class UnitTest1
    {
        IDalManager manager;
        public UnitTest1(){
            manager = new DalManagerSQL();
        }
        
        [TestMethod]
        public void TestGetAllStades()
        {
            List<Stade> stades = manager.GetAllStades();
            Assert.IsNotNull(stades, "error ! la liste est vide");
            foreach (Stade s in stades)
            {
                Assert.IsNotNull(s.NbPlaces);
                Assert.IsNotNull(s.Nom);
                Assert.IsNotNull(s.Element);
            }
            Assert.AreNotEqual(stades, null, "error ! la liste est vide");

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
        public void TestAjouterStade()
        {
            /* Création d'un Stade */
            Stade expected = new Stade(10,"Test");
            expected.NbPlaces = 2000;
            /* Ajout du Stade dans la BD */
            manager.InsertStade(expected);
            /* Récupération d'un meme élément */
            Stade tmp = manager.GetStadeById(expected.ID);
            Assert.IsNotNull(tmp);
            Assert.AreEqual(tmp.ID, expected.ID);
            Assert.AreEqual(tmp.NbPlaces, expected.NbPlaces);
            Assert.AreEqual(tmp.Nom, expected.Nom);
        }

        [TestMethod]
        public void TestStade()
        {
            /* Création d'un Stade */
            Stade s1 = new Stade(0, "Stadium");
            Assert.AreEqual(s1.NbPlaces,0,"ce stade n'a pas de place au debut ");
            Assert.IsFalse(s1.NbPlaces<0,"le nombre de place est supérieur ou egal à 0 ");
            Assert.AreNotEqual(s1.Nom,"","un stade à toujours un nom");
            Stade s2 = new Stade(100, "Stade Pokemon", 0);
            s2.ID=10;
            s2.NbPlaces=1000;
            s2.Nom="Pokemons Arena";
            s2.Element=ETypeElement.Insecte;
            Assert.AreEqual(s2.Element, ETypeElement.Insecte, "le type du pokemon est incorrecte");
            Assert.AreNotEqual(s2.NbPlaces, 100);
            Assert.AreEqual(s2.ID, 10);
            Assert.AreEqual(s2.Nom, "Pokemons Arena");
        }
        
        [TestMethod]
        public void TestPokemon()
        {
            /* Création d'un pokemon */
            Caracteristiques caracteristiques = new Caracteristiques(10, 20, 10, 40);
            Pokemon p = new Pokemon("pika",caracteristiques, 0);
            

            Assert.AreNotEqual(p.Nom, "", "un pokemon à toujours un nom");
            Assert.AreEqual(p.Type, ETypeElement.Aucun, "le type du pokemon est incorrecte");
            Assert.AreEqual(p.Caracteristiques, caracteristiques, "probleme d'initialisation");
            
            p.ID = 10;
            Assert.AreEqual(p.ID, 10);
           
        }

        [TestMethod]
        public void TestMatch()
        {
            /* Création d'un match */
            Pokemon p = new Pokemon("pika",new Caracteristiques(10, 20, 10, 40), 0);
            Pokemon p1 = new Pokemon("dragon", new Caracteristiques(100, 20, 10, 40), 0);
            Match match = new Match(p, p1, new Stade(8, "test"), EPhaseTournoi.QuartFinale);
            Assert.AreEqual(match.Pokemon1, p);
            Assert.AreNotEqual(match.Pokemon2, p);
            Assert.AreNotEqual(match.PhaseTournoi, EPhaseTournoi.Finale);
            
        }

        [TestMethod]
        public void TestUser()
        {
            /* Création d'un utilisateur */
            Utilisateur u = new Utilisateur("Hamza", "test1234", "Achil", "Pelai");
            Assert.IsFalse(u.Password.Length < 8, "le mot de passe doit contenir 8 caractères au minimum");
            Assert.AreNotEqual(u.Login, "", "Error ! login empty");
            u.Nom = "Pierre";
            u.Prenom = "Lucas";
            Assert.AreEqual(u.Nom, "Pierre", "Error nom");
            Assert.AreEqual(u.Prenom, "Lucas", "Error prenom");
        }
        
        [TestMethod]
        public void TestTournoi()
        {
            /* Création d'un tournoi */
            Tournoi tournoi = new Tournoi("Champions", manager.GetAllStades(), manager.GetAllPokemons(), 16);
            Assert.AreEqual(tournoi.Nom, "Champions", "Error nom");
            Assert.IsTrue(tournoi.Matchs == null, "error !! la list doit etre vide");
            tournoi.Matchs = manager.GetAllMatchs();
            Assert.IsNotNull(tournoi.Matchs);
      
        }  
       
    }
} 