using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace clientSQLEntreprise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Définition de la connection
                Entreprise2020 entreprise = new Entreprise2020("Antoine_1snir\\sqlserver", "Entreprise2020", "SNIR2Entreprise", "@Password1234!");

                // Test des méthodes NomColonneProduit() et ListeProduit()
                Console.WriteLine("*** TEST DES METHODES NomColonneProduit() et ListeProduit() ***");
                List<String> Noms = entreprise.NomColonneProduit(); // liste des noms de colonnes
                List<Produit> Liste = entreprise.ListeProduit(); // liste des produits
                foreach (String nom in Noms) // affichage noms colonne
                {
                    Console.Write(nom + "\t\t\t");
                }
                Console.WriteLine();
                foreach (Produit produit in Liste) // affichage produits
                {
                    Console.WriteLine(produit.Numero + "\t\t\t" + produit.Nom + "\t" + produit.Poids + "\t\t\t" + produit.Couleur);
                }
                Console.WriteLine();

                // Test de la méthode NPMax()
                Console.WriteLine("*** TEST DE LA METHODE NPMax() ***");
                Console.WriteLine("La table P contient actuellement " + entreprise.NPMax().ToString() + " entrées" + "\n");

                /*// Test de la méthode AjouterProduit(Produit p)
                Console.WriteLine("*** TEST DE LA METHODE AjouterProduit(Produit P) ***");
                int retour = entreprise.AjouterProduit(new Produit(entreprise.NPMax() + 1, "PC Gamer", 15.0, "rgb"));
                if (retour == 1)
                {
                    Console.WriteLine("Le produit à été ajouté avec succès, la table est maintenant la suivante : \n");
                    List<String> Noms2 = entreprise.NomColonneProduit(); // liste des noms de colonnes
                    List<Produit> Liste2 = entreprise.ListeProduit(); // liste des produits
                    foreach (String nom in Noms2) // affichage noms colonne
                    {
                        Console.Write(nom + "\t\t\t");
                    }
                    Console.WriteLine();
                    foreach (Produit produit in Liste2) // affichage produits
                    {
                        Console.WriteLine(produit.Numero + "\t\t\t" + produit.Nom + "\t" + produit.Poids + "\t\t\t" + produit.Couleur);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Le produit n'a pas été ajouté\n");
                }*/

                // Test de la méthode QuantiteLivreeParReference(int reference)
                Console.WriteLine("*** TEST DE LA METHODE QuantiteLivreeParReference(int reference) ***");
                if (args.Length == 0)
                {
                    Console.WriteLine("Aucun paramètre n'a été passé");
                }
                else
                {
                    int argument = Convert.ToInt32(args[0]);
                    quantiteLivreParRefResultat quantite = entreprise.QuantiteLivreeParReference(argument);
                    if (quantite.retour == -3)
                    {
                        Console.WriteLine("Le numéro de produit " + args[0] + " ne peut pas être négatif ou nul");
                    }
                    else if (quantite.retour == -2)
                    {
                        Console.WriteLine("Le numéro de produit " + args[0] + " n'est pas référencé dans la table P");
                    }
                    else if (quantite.retour == -1)
                    {
                        Console.WriteLine("Le numéro de produit " + args[0] + " n'a effectué aucune livraison");
                    }
                    else
                    {
                        Console.WriteLine("Le produit numéro " + args[0] + " a une quantitée livrée de " + quantite.Quantite.ToString() + "\n");
                    }
                }

                /*// Test de la méthode AjouterPUF(Produit p, Fournisseur f, Usine u, int quantite)
                Console.WriteLine("*** TEST DE LA METHODE AjouterPUF(Produit p, Fournisseur f, Usine u, int quantite) ***");
                Produit produitPUF = new Produit(8, "PC GAMER", 15.0, "rgb");
                Fournisseur fournisseurPUF = new Fournisseur(8, "ZALO", "SARL", "Vannes");
                Usine usinePUF = new Usine(8, "usine1", "Evreux");
                if (entreprise.AjouterPUF(produitPUF, fournisseurPUF, usinePUF, 4000) == 0)
                {
                    Console.WriteLine("Traction réussie");
                }
                else
                {
                    Console.WriteLine("Tranction echouée");
                }*/

                // Test de la méthode AjouterPUFProc(Produit p, Fournisseur f, Usine u, int quantite)
                Console.WriteLine("*** TEST DE LA METHODE AjouterPUFProc(Produit p, Fournisseur f, Usine u, int quantite) ***");
                Produit produitPUFProc = new Produit(8, "PC GAMER", 15.0, "rgb");
                Fournisseur fournisseurPUFProc = new Fournisseur(8, "ZALO", "SARL", "Vannes");
                Usine usinePUFProc = new Usine(8, "usine1", "Evreux");
                if (entreprise.AjouterPUF(produitPUFProc, fournisseurPUFProc, usinePUFProc, 4000) == 0)
                {
                    Console.WriteLine("Traction réussie");
                }
                else
                {
                    Console.WriteLine("Tranction echouée");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
