using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StubDataAccessLayer
{
    public class DalManagerSQL : IDalManager
    {
        protected string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cyrius\Desktop\Projet\C#\PokemonTournament\StubDataAccessLayer\DatabasePokemonTournament.mdf;Integrated Security=True";
        
        public DalManagerSQL()
        {
        }

        public DataTable SelectByDataAdapter(string request)
        {
            DataTable results = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            return results;
        }

        public void Delete(string request, int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteReader();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public List<Pokemon> GetAllPokemons()
        {
            List<Pokemon> listPokemon = new List<Pokemon>();
            string request = "Select * from Pokemon;";

            DataTable dataTable = SelectByDataAdapter(request);

            foreach( DataRow item in dataTable.Rows)
            {
                string nom = item["Nom"].ToString();
                ETypeElement type = (ETypeElement)Convert.ToInt32(item["Type"]);
                Caracteristiques carac = GetCaracteristiqueById(Convert.ToInt32(item["Caracteristiques"]));
                Pokemon pokemon = new Pokemon(nom,carac,type);
                pokemon.ID = Convert.ToInt32(item["Id"]);
                listPokemon.Add(pokemon);
            }
            
            return listPokemon;
        }

        public Pokemon GetPokemonById(int id)
        {
            Pokemon pokemon = null;

            string request = "select * from Pokemon where id=" + id.ToString();
            DataTable dataTable = SelectByDataAdapter(request);
            if (dataTable.Rows.Count > 0)
            {
                DataRow data = dataTable.Rows[0];
                string nom = data["Nom"].ToString();
                Caracteristiques carac = GetCaracteristiqueById(Convert.ToInt32(data["Caracteristiques"]));
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

            DataTable dataTable = SelectByDataAdapter(request);

            foreach (DataRow item in dataTable.Rows)
            {
                string nom = item["Nom"].ToString();
                int nbPlaces = Convert.ToInt32(item["NbPlaces"]);
                ETypeElement type = (ETypeElement)Convert.ToInt32(item["Element"]);
                Stade stade = new Stade(nbPlaces, nom, type);
                stade.ID = Convert.ToInt32(item["Id"]);
                listStade.Add(stade);
            }

            return listStade;
        }

        public Stade GetStadeById(int Id)
        {
            Stade stade = null;

            string request = "select * from Stade where id=" + Id.ToString();
            DataTable dataTable = SelectByDataAdapter(request);
            if (dataTable.Rows.Count > 0)
            {
                DataRow data = dataTable.Rows[0];

                int nbPlace = Convert.ToInt32(data["nbPlaces"]);
                string nom = data["Nom"].ToString();
                ETypeElement type = (ETypeElement)Convert.ToInt32(data["Element"]);
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

            DataTable dataTable = SelectByDataAdapter(request);

            foreach (DataRow item in dataTable.Rows)
            {
                EPhaseTournoi phase = (EPhaseTournoi)Convert.ToInt32(item["PhaseTournoi"]);
                Pokemon pokemon1 = GetPokemonById(Convert.ToInt32(item["Pokemon1"]));
                Pokemon pokemon2 = GetPokemonById(Convert.ToInt32(item["Pokemon2"]));
                Stade stade = GetStadeById(Convert.ToInt32(item["Stade"]));
                int idVainqueur = Convert.ToInt32(item["idPokemonVainqueur"]);

                Match match = new Match(pokemon1,pokemon2,stade,phase);
                match.ID = Convert.ToInt32(item["Id"]);
                match.Vainqueur = GetPokemonById(idVainqueur);
                listMatch.Add(match);
            }

            return listMatch;
        }

        public List<Caracteristiques> GetAllCaracteristiques()
        {
            throw new NotImplementedException();
        }

        public Caracteristiques GetCaracteristiqueById(int id)
        {
            Caracteristiques carac = null;
            string request = "select * from Caracteristique where id=" + id.ToString();
            DataTable dataTable = SelectByDataAdapter(request);
            if (dataTable.Rows.Count > 0)
            {
                int pv = Convert.ToInt32(dataTable.Rows[0]["Pv"]);
                int atk = Convert.ToInt32(dataTable.Rows[0]["Atk"]);
                int def = Convert.ToInt32(dataTable.Rows[0]["Def"]);
                int vitesse = Convert.ToInt32(dataTable.Rows[0]["Vitesse"]);
                carac = new Caracteristiques(pv,atk,def,vitesse);
                carac.ID = Convert.ToInt32(dataTable.Rows[0]["Id"]);
            }
            return carac;
        }

        public bool InsertPokemon(Pokemon pokemon)
        {
            bool result = false;
            if (InsertCaracteristique(pokemon.Caracteristiques))
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        string sql = "INSERT INTO Pokemon (Nom, Type, Caracteristiques) VALUES(@Nom, @Type, @Carac);  SELECT @@IDENTITY";
                        SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                        sqlCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50).Value = pokemon.Nom;
                        sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = (int)pokemon.Type;
                        sqlCommand.Parameters.Add("@Carac", SqlDbType.Int).Value = pokemon.Caracteristiques.ID;
                        sqlCommand.CommandType = CommandType.Text;
                        pokemon.ID = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                        sqlConnection.Close();
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            return result;
        }

        public bool InsertStade(Stade stade)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string sql = "INSERT INTO Stade VALUES(@Nom, @NbPlaces, @Element);  SELECT @@IDENTITY";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50).Value = stade.Nom;
                    sqlCommand.Parameters.Add("@Element", SqlDbType.Int).Value = (int)stade.Element;
                    sqlCommand.Parameters.Add("@NbPlaces", SqlDbType.Int).Value = stade.NbPlaces;
                    sqlCommand.CommandType = CommandType.Text;
                    stade.ID = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                    sqlConnection.Close();
                    result = true;
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool InsertCaracteristique(Caracteristiques carac)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string sql = "INSERT INTO Caracteristique VALUES(@PV, @Atk, @Def, @Vitesse); SELECT @@IDENTITY";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.Add("@PV", SqlDbType.Int).Value = carac.PV;
                    sqlCommand.Parameters.Add("@Atk", SqlDbType.Int).Value = carac.Atk;
                    sqlCommand.Parameters.Add("@Def", SqlDbType.Int).Value = carac.Def;
                    sqlCommand.Parameters.Add("@Vitesse", SqlDbType.Int).Value = carac.Vitesse;
                    sqlCommand.CommandType = CommandType.Text;
                    carac.ID = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                    sqlConnection.Close();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool InsertMatch(Match match)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string sql = "INSERT INTO Match VALUES(@Nom, @PhaseTournoi, @IdPokemon1, @IdPokemon2, @IdStade, @idPokemonVainqueur); SELECT @@IDENTITY";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50).Value = match.Nom;
                    sqlCommand.Parameters.Add("@PhaseTournoi", SqlDbType.Int).Value = (int)match.PhaseTournoi;
                    sqlCommand.Parameters.Add("@IdPokemon1", SqlDbType.Int).Value = match.Pokemon1.ID;
                    sqlCommand.Parameters.Add("@IdPokemon2", SqlDbType.Int).Value = match.Pokemon2.ID;
                    sqlCommand.Parameters.Add("@IdStade", SqlDbType.Int).Value = match.Stade.ID;
                    sqlCommand.Parameters.Add("@idPokemonVainqueur", SqlDbType.Int).Value = match.Vainqueur.ID;
                    sqlCommand.CommandType = CommandType.Text;
                    match.ID = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                    sqlConnection.Close();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string sql = "UPDATE Pokemon SET Nom=@Nom, Type=@Type WHERE ID=@Id;";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = pokemon.ID;
                    sqlCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50).Value = pokemon.Nom;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = (int)pokemon.Type;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteReader();
                    sqlConnection.Close();
                    result = UpdateCaracteristique(pokemon.Caracteristiques);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }
        public bool UpdateStade(Stade stade)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string sql = "UPDATE Stade SET Nom=@Nom, Element=@Element, NbPlaces=@NbPlaces WHERE ID=@Id;";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = stade.ID;
                    sqlCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50).Value = stade.Nom;
                    sqlCommand.Parameters.Add("@Element", SqlDbType.Int).Value = (int)stade.Element;
                    sqlCommand.Parameters.Add("@NbPlaces", SqlDbType.Int).Value = stade.NbPlaces;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteReader();
                    sqlConnection.Close();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool UpdateCaracteristique(Caracteristiques carac)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string sql = "UPDATE Caracteristique SET PV=@PV, Atk=@Attaque, Def=@Defense, Vitesse=@Vitesse WHERE ID=@Id;";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = carac.ID;
                    sqlCommand.Parameters.Add("@PV", SqlDbType.Int).Value = carac.PV;
                    sqlCommand.Parameters.Add("@Attaque", SqlDbType.Int).Value = carac.Atk;
                    sqlCommand.Parameters.Add("@Defense", SqlDbType.Int).Value = carac.Def;
                    sqlCommand.Parameters.Add("@Vitesse", SqlDbType.Int).Value = carac.Vitesse;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteReader();
                    sqlConnection.Close();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            Delete("DELETE FROM Pokemon WHERE ID=@Id;", pokemon.ID);
            DeleteCaracteristique(pokemon.Caracteristiques);
        }

        public void DeleteStade(Stade stade)
        {
            Delete("DELETE FROM Stade WHERE ID=@Id;", stade.ID);
        }

        public void DeleteMatch(Match match)
        {
            Delete("DELETE FROM Match WHERE ID=@Id;", match.ID);
        }

        public void DeleteCaracteristique(Caracteristiques carac)
        {
            Delete("DELETE FROM Caracteristique WHERE ID=@Id;", carac.ID);
        }

    }
}
