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

            Stade stade1 = new Stade(500, "Stade or");
            Stade stade2 = new Stade(1000, "Stade platine");
            Console.WriteLine(stade1);
            Console.WriteLine(stade2);

            Match match1 = new Match(pika, carapuce, stade1, EPhaseTournoi.QuartFinale);
            Match match2 = new Match(salameche, carapuce, stade2, EPhaseTournoi.DemiFinale);
            Match match3 = new Match(new Pokemon("Bulbazar", ETypeElement.Feu), new Pokemon("Lipoutou", ETypeElement.Feu), stade1, EPhaseTournoi.Finale);
            match1.JouerMatch();
            match2.JouerMatch();
            match3.JouerMatch();
            Console.WriteLine(match1);
            Console.WriteLine(match2);
            Console.WriteLine(match3);

            Console.ReadKey();
        }
    }
}
