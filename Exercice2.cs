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

                Console.WriteLine();
                Console.Write("Voulez vous appliquer la promotion ? <O> pour OUI, <N> pour NON: ");
                st_read_input = Console.ReadLine();

                // gestion des erreurs de frappe
                while (!st_read_input.ToLower().Equals("o") & !st_read_input.ToLower().Equals("n"))
                {
                    Console.WriteLine();
                    Console.Write("SVP, appuyer sur <O> ou sur <N> puis <Entrer>: ");
                    st_read_input = Console.ReadLine();
                }

                // Déterminer le coût total des fruits, ceci dépend de si la promotation est appliquée ou pas
                double c_total = st_read_input.Equals("o") ? ShoppingCart(panier, true) : ShoppingCart(panier, false);
                Console.WriteLine();
                Console.Write("Le coût total de vos achats = " + c_total + "$" + "\n\n");
                Console.Write("Appuyer sur <Entrer> pour recommencer ...\n\n");

            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        /// <summary>
        /// ShoppingCart: permet de calculer le coût total des fruits (dans notre cas, ce sont les pommes et les oranges)
        /// Cette méthode fait appelle à la méthode "Promo"
        /// </summary>
        /// <param name="panier">  liste donnée de fruits</param>
        /// <param name="si_promo">permet de savoir si l'on applique la promotion sur les fruits ou pas</param>
        /// <returns></returns>
        static double ShoppingCart(List<string> panier, Boolean si_promo)
        {
            double prix_pommes = Promo(panier.Where(s => s == "pomme").Count(), si_promo ? 1 : 0, prix_unite_pomme);
            double prix_oranges = Promo(panier.Where(s => s == "orange").Count(), si_promo ? 2 : 0, prix_unite_orange);

            return prix_pommes + prix_oranges;
        }

        /// <summary>
        /// Promo: permet de calculer le coût total des fruits d'une même catégorie (pommes ou oranges)
        /// </summary>
        /// <param name="nb_fruits">liste de fruits d'une catégorie donnée</param>
        /// <param name="k">indique le nombre de fruits à acheter pour pouvoir en avoir un gratuitement</param>
        /// <param name="prix_unite_fruit">le prix unitaire d'un fruit d'une catégorie donnée</param>
        /// <returns></returns>
        static double Promo(int nb_fruits, int k, double prix_unite_fruit)
        {
            double total = 0; // le coût total des fruits d'une catégorie donnée

            switch (k)
            {
                case 0: // Dans le cas où aucune promotion n'est appliquée
                    total = nb_fruits * prix_unite_fruit;
                    break;

                default: // Dans le cas où une promotion est appliquée sur le fruit d'une catégorie donnée
                    int nb_gratuit = nb_fruits / (k + 1);
                    total = (nb_fruits - nb_gratuit) * prix_unite_fruit;
                    break;
            }

            return total;
        }
    }
}