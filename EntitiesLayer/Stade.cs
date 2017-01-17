using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {

        public Caracteristiques Caracteristiques { get; set; }
        public int NbPlaces { get; set; }
        public string Nom { get; set; }

        public Stade(int id) : base(id)
        {

        }
    }
}
