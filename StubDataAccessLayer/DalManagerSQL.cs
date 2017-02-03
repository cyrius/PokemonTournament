using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubDataAccessLayer
{
    public class DalManagerSQL
    {
        private IDal bridge { get; set; }

        public DalManagerSQL()
        {
            bridge = new DalSqlServer();
        }

        public List<Pokemon> GetAllPokemons()
        {
            List<Pokemon> listPokemon = new List<Pokemon>();
            string request = "Select * from Pokemon;";

            DataTable dataTable = bridge.SelectByDataAdapter(request);
            foreach( DataRow item in dataTable.Rows)
            {
                string nom = item["nom"].ToString();
                Pokemon pokemon = new Pokemon(nom,ETypeElement.Aucun);
                listPokemon.Add(pokemon);
            }
            
            return listPokemon;
        }

    }
}
