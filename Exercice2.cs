using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2
{
    class Program
    {
        // déclaration des prix des pommes et des oranges
        static double prix_unite_pomme = 0.60;
        static double prix_unite_orange = 1.25;

        static void Main(string[] args)
        {
            String st_read_input; // permet de lire (scanner) un article (éventuellement une pomme ou une orange)

            do
            {
                List<string> panier = new List<string>();
                Console.Write("************* Bienvenu au Shopping Cart: *************\n\n");
                Console.Write("Pour scanner une pomme ou une orange, taper \"pomme\" ou \"orange\" puis <Entrer> \n\n");
                Console.Write("Scanner un article (appuyer sur <T> puis <Entrer> pour finir): ");
                st_read_input = Console.ReadLine(); // lire l'article

                while (!st_read_input.Equals("t"))
                {
                    // Si l'article est une pomme ou une orange;
                    if ((st_read_input.ToLower().Equals("pomme")) || (st_read_input.ToLower().Equals("orange")))
                        panier.Add(st_read_input.ToLower()); // ajouter l'article au panier
                    else
                        Console.WriteLine("Article inconnu");

                    Console.Write("Scanner un article (appuyer sur <T> puis <Entrer> pour finir): ");
                    st_read_input = Console.ReadLine(); // lire l'article
                }

                // Déterminer le coût total des fruits
                Console.WriteLine();
                Console.Write("Le coût total de vos achats = " + ShoppingCart(panier) + "$" + "\n\n");
                Console.Write("Appuyer sur <Entrer> pour recommencer ...\n\n");

            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        /// <summary>
        /// ShoppingCart: permet de calculer le coût total des fruits (dans notre cas, ce sont les pommes et les oranges)
        /// </summary>
        /// <param name="panier">  liste donnée de fruits</param>
        /// <returns></returns>
        static double ShoppingCart(List<string> panier)
        {
            double prix_pommes = panier.Where(s => s == "pomme").Count() * prix_unite_pomme;
            double prix_oranges = panier.Where(s => s == "orange").Count() * prix_unite_orange;

            return prix_pommes + prix_oranges;
        }
    }
}