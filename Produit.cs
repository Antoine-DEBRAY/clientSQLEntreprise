using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientSQLEntreprise
{   
    class Produit
    {
        /// <summary>
        /// Classe représentant la table P de notre base de donnée
        /// </summary>
        private string couleur;
        private string nom;
        private int numero;
        private double poids;
        public string Couleur { get => couleur; set => couleur = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Numero { get => numero; set => numero = value; }
        public double Poids { get => poids; set => poids = value; }

        public Produit(int numero, string nom, double poids, string couleur)
        {
            if (numero <= 0 || nom == "" || poids <= 0 || couleur == "")
            {
                this.Numero = -1;
                this.Nom = "Erreur";
                this.Poids = -1;
                this.Couleur = "Erreur";
            }
            else
            {
                this.Numero = numero;
                this.Nom = nom;
                this.Poids = poids;
                this.Couleur = couleur;
            }
        }
    }
}
