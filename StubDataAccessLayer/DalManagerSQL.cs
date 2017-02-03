using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubDataAccessLayer
{
    public class DalManagerSQL : IDalManager
    {
        private IDal dal { get; set; }

        public DalManagerSQL()
        {
            dal = new DalSqlServer();
        }

        public List<Pokemon> GetAllPokemons()
        {
            List<Pokemon> listPokemon = new List<Pokemon>();
            string request = "Select * from Pokemon;";

            DataTable dataTable = dal.SelectByDataAdapter(request);

            foreach( DataRow item in dataTable.Rows)
            {
                string nom = item["Nom"].ToString();
                ETypeElement type = (ETypeElement)Convert.ToInt32(item["Type"]);
                Caracteristiques carac = GetCaracteristiqueById(Convert.ToInt32(item["carac"]));
                Pokemon pokemon = new Pokemon(nom,carac,type);
                pokemon.ID = Convert.ToInt32(item["Id"]);
                listPokemon.Add(pokemon);
            }
            
            return listPokemon;
        }

        private Pokemon GetPokemonById(int id)
        {
            Pokemon pokemon = null;

            string request = "select * from Pokemon where id=" + id.ToString();
            DataTable dataTable = dal.SelectByDataAdapter(request);
            if (dataTable.Rows.Count > 0)
            {
                DataRow data = dataTable.Rows[0];
                string nom = data["Nom"].ToString();
                Caracteristiques carac = GetCaracteristiqueById(Convert.ToInt32(data["Carac"]));
                ETypeElement type = (ETypeElement)Convert.ToInt32(data["Type"]);
                pokemon = new Pokemon(nom, carac, type);
                pokemon.ID = Convert.ToInt32(data["Id"]);
            }
            return pokemon;
        }


        public List<Stade> GetAllStades()
        {
            List<Stade> listStade = new List<Stade>();
            string request = "Select * from Stade;";

            DataTable dataTable = dal.SelectByDataAdapter(request);

            foreach (DataRow item in dataTable.Rows)
            {
                string nom = item["Nom"].ToString();
                int nbPlaces = Convert.ToInt32(item["NbPlaces"]);
                ETypeElement type = (ETypeElement)Convert.ToInt32(item["Type"]);
                Stade stade = new Stade(nbPlaces, nom, type);
                stade.ID = Convert.ToInt32(item["Id"]);
                listStade.Add(stade);
            }

            return listStade;
        }

        private Stade GetStadeById(int Id)
        {
            Stade stade = null;

            string request = "select * from Stade where id=" + Id.ToString();
            DataTable dataTable = dal.SelectByDataAdapter(request);
            if (dataTable.Rows.Count > 0)
            {
                DataRow data = dataTable.Rows[0];

                int nbPlace = Convert.ToInt32(data["NbPlaces"]);
                string nom = data["Nom"].ToString();
                ETypeElement type = (ETypeElement)Convert.ToInt32(data["Type"]);
                stade = new Stade(nbPlace,nom,type);
                stade.ID = Convert.ToInt32(data["Id"]);
            }
            return stade;
        }

        public List<Tournoi> GetAllTournois()
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatchs()
        {
            List<Match> listMatch = new List<Match>();
            string request = "Select * from Match;";

            DataTable dataTable = dal.SelectByDataAdapter(request);

            foreach (DataRow item in dataTable.Rows)
            {
                EPhaseTournoi phase = (EPhaseTournoi)Convert.ToInt32(item["Phase"]);
                Pokemon pokemon1 = GetPokemonById(Convert.ToInt32(item["Pokemon1"]));
                Pokemon pokemon2 = GetPokemonById(Convert.ToInt32(item["Pokemon2"]));
                Stade stade = GetStadeById(Convert.ToInt32(item["Stade"]));

                Match match = new Match(pokemon1,pokemon2,stade,phase);
                match.ID = Convert.ToInt32(item["Id"]);
                listMatch.Add(match);
            }

            return listMatch;
        }

        public List<Caracteristiques> GetAllCaracteristiques()
        {
            throw new NotImplementedException();
        }

        private Caracteristiques GetCaracteristiqueById(int id)
        {
            Caracteristiques carac = null;
            string request = "select * from Caracteristique where id=" + id.ToString();
            DataTable dataTable = dal.SelectByDataAdapter(request);
            if (dataTable.Rows.Count > 0)
            {
                int pv = Convert.ToInt32(dataTable.Rows[0]["Pv"]);
                int atk = Convert.ToInt32(dataTable.Rows[0]["Atk"]);
                int def = Convert.ToInt32(dataTable.Rows[0]["Def"]);
                int vitesse = Convert.ToInt32(dataTable.Rows[0]["Vitesse"]);
                carac = new Caracteristiques(pv,atk,def,vitesse);
            }
            return carac;
        }


        public void ModifierStade(Stade stade, string nom, int nbPlaces, ETypeElement element)
        {
            throw new NotImplementedException();
        }

        public void SupprimerEntity(int id)
        {
            int i = 0;
            List<string> request = new List<string>();
            request.Add("Delete FROM Stade WHERE ID=@Id;");
            request.Add("Delete FROM Pokemon WHERE ID=@Id;");
            request.Add("Delete FROM Match WHERE ID=@Id;");

            while(i < request.Count)
            {
                dal.Delete(request.ElementAt(i++),id);
            }
        }
    }
}
