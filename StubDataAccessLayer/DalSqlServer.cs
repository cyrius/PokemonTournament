using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubDataAccessLayer
{
    public class DalSqlServer : IDal
    {

        protected string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\theo\Documents\Développement\PokemonTournament\StubDataAccessLayer\DatabasePokemon.mdf;Integrated Security = True; Connect Timeout = 30";

        public DalSqlServer()
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
    }
}
