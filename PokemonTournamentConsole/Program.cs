using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLayer;
namespace PokemonTournamentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon pika = new Pokemon("Pikachu", ETypeElement.Tonnerre);
            Console.WriteLine(pika);
            Pokemon carapuce = new Pokemon("Carapute", ETypeElement.Eau);
            Console.WriteLine(carapuce);
            Pokemon salameche = new Pokemon("Samlaleche", ETypeElement.Feu);
            Console.WriteLine(salameche);

            Match match1 = new Match(ref pika, ref carapuce);
            Match match2 = new Match(ref salameche, ref carapuce, EPhaseTournoi.DemiFinale);
            Match match3 = new Match(new Pokemon("Bulbazar", ETypeElement.Feu), new Pokemon("Lipoutou", ETypeElement.Feu));
            Console.WriteLine(match1);
            Console.WriteLine(match2);
            Console.WriteLine(match3);

            Stade stade1 = new Stade(500, "Stade or");
            Stade stade2 = new Stade(1000, "Stade platine");
            Console.WriteLine(stade1);
            Console.WriteLine(stade2);

            Dresseur dresseur1 = new Dresseur("Sacha");
            Dresseur dresseur2 = new Dresseur("Ondi");
            Console.WriteLine(dresseur1);
            Console.WriteLine(dresseur2);

            Console.ReadKey();
        }
    }
}
