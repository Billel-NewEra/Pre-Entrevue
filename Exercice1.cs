using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Le but de ce premier exercice est, étant donné un nombre donné en entrée, trouver le 
/// nombre supérieur suivant avec les mêmes chiffres. Mathématiquement parlant, trouver la 
/// plus petite permutation de ce nombre qui est supérieure à ce dernier.  
/// 
/// Remarque: Comme il n'a pas été précisé dans l'exercice, on suppose que les nombres 
/// considérés ne sont pas signés.
/// 
/// Pour résoudre cet exercice on utilise l'observation suivante:
/// Tout nombre "nb=U(0), U(1), ..., U(n)" composé uniquement d'une seule suite 
/// croissante de chiffres (i.e. "U(i-1)>=U(i) pour tout n >= i >= 0") n'admets 
/// pas de nombre supérieur avec les mêmes chiffres.
/// 
/// La résolution de cet exercice se déroule en trois étapes:
/// 
/// 1 - Déterminer la position du premier chiffre "U(k)" supérieur au chiffre qui le précède
/// (se trouvant directement sur sa droite) dans le nombre donné (en parcourant les chiffres 
/// de ce dernier de la droite vers la gauche).
/// 
/// 2- Supposons que cette position est "k", permuter le chiffre "U(k)" de cette position avec
/// le chiffre ayant la valeur minimum parmi tous les chiffres qui précèdent "U(k)" dans le nombre 
/// donné (en parcourant les chiffres de ce dernier de la droite vers la gauche). Supposons que 
/// ce chiffre est "U(p)".
/// 
/// 3- Ordonner de manière décroissante (i.e. "U(i)>=U(i-1) pour tout n >= i >= 0") les chiffres qui 
/// précèdent "U(p)", en parcourant les chiffres du nombre donné de la droite vers la gauche.
/// 
/// </summary>
namespace Excercice1
{
    class Program
    {
        static void Main(string[] args)
        {
            string st; 
            
            do
            {
                Console.Write("Veuillez entrer un nombre puis appuyer sur <Entrer>: ");
                st = Console.ReadLine(); // lire le nombre en entrée
                int length = st.Length;

                int[] nombre = new int[length]; // Stocker le nombre dans un tableau de chiffres
                for (int i = 0; i < length; i++)
                    nombre[i] = st.ElementAt(i) - '0';
                
                if (get_first_inf(nombre) == -1) // le nombre considéré est par exemple "nombre=5, nombre=222 ou nombre=4321"
                    Console.Write("Le nombre supérieur suivant avec les mêmes chiffres n'existe pas");

                else
                {
                    int br = get_first_inf(nombre);
                    int min = get_petit_sup(nombre, br);
                    permut_pos(ref nombre, br, min);
                    inv_elements(ref nombre, br + 1, length - 1);

                    st = string.Join("", nombre); // Convertir le tableau de chiffres en un seul nombre

                    Console.WriteLine("\nLe nombre suivant est " + st);
                    //Console.Write("Appuyer sur une touche pour quitter");
                    //Console.ReadKey();
                }
                Console.Write("\nAppuyer sur <Entrer> pour recommencer ...\n\n");

            } while (Console.ReadKey().Key==ConsoleKey.Enter);
            
        }

        /// <summary>
        /// Déterminer la position du premier chiffre "U(k)" du nombre donné, qui est inférieur 
        /// au chiffre qui le précède (i.e. se trouvant directement sur sa droite), en parcourant 
        /// les chiffres du nombre donné de la droite vers la gauche. 
        /// </summary>
        /// <param name="t">tableau représentant les chiffres du nombre donné</param>
        /// <returns></returns>
        static int get_first_inf(int[] t)
        {
            int i = t.Length - 1; // récupérer la position du chiffre qui se trouve sur l'extrémité droite du tableau "t"

            while (i > 0)
            {
                if (t[i - 1] >= t[i])
                    i--;
                else
                    return (i - 1); // retourner la psition du chiffre recherché
            }

            /* Si cette position n'existe pas alors on retourne "-1" qui signifie que le nombre considéré est par 
               exemple "nombre=5, nombre=222 ou nombre=4321" */
            return -1;
        }

        /// <summary>
        /// Déterminer la position du plus petit chiffre t[k] parmi tous les chiffres qui précèdent 
        /// t[pos_limit] (se trouvant sur sa droite) tel que "t[k]>t[pos_limit]".
        /// </summary>
        /// <param name="t">tableau représentant les chiffres du nombre donné</param>
        /// <param name="pos_limit"></param>
        /// <returns></returns>
        static int get_petit_sup(int[] t, int pos_limit)
        {
            int i = t.Length - 1; // récupérer la position du chiffre qui se trouve sur l'extrémité droite du tableau "t"

            while (i > pos_limit)
            {
                if (t[i] <= t[pos_limit])
                    i--;
                else
                    break;
            }
            return i;
        }

        /// <summary>
        /// Permuter les chiffres des deux positions "p1" et "p2" du tableau "t"
        /// </summary>
        /// <param name="t"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        static void permut_pos(ref int[] t, int p1, int p2)
        {
            int var = t[p1];
            t[p1] = t[p2];
            t[p2] = var;
        }

        /// <summary>
        /// Inverser les chiffres "t[p1], ..., t[p2]" de "t" afin d'obtenir une suite décroissante "t[p2], ..., t[p1]"
        /// </summary>
        /// <param name="t">tableau représentant les chiffres du nombre donné</param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        static void inv_elements(ref int[] t, int p1, int p2)
        {
            int rang = (p2 - p1 + 1) / 2; 

            for (int i = 0; i < rang; i++) // On parcourt seulement la moitié de l'intervalle [p1, p2]
                permut_pos(ref t, p1 + i, p2 - i); // Permuter "t[p1+i]" et "t[p2-i]" 
        }
    }
}
