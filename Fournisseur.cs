using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientSQLEntreprise
{
    class Fournisseur
    {
        private int numero;
        private string nom;
        private string statut;
        private string ville;

        public int Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Statut { get => statut; set => statut = value; }
        public string Ville { get => ville; set => ville = value; }

        public Fournisseur(int numero, string nom, string statut, string ville)
        {
            if (numero <= 0 || nom == "" || statut == "" || ville == "")
            {
                this.Numero = -1;
                this.Nom = "Erreur";
                this.Statut = "Erreur";
                this.Ville = "Erreur";
            }
            else
            {
                this.Numero = numero;
                this.Nom = nom;
                this.Statut = statut;
                this.Ville = ville;
            }
        }
    }
}
