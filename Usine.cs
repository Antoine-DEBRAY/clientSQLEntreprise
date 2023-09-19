using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientSQLEntreprise
{
    class Usine
    {
        private int numero;
        private string nom;
        private string ville;

        public int Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Ville { get => ville; set => ville = value; }

        public Usine (int numero, string nom, string ville)
        {
            if (numero < 0 || nom == "" || ville == "")
            {
                this.Numero = -1;
                this.Nom = "Erreur";
                this.Ville = "Erreur";
            }
            else
            {
                this.Numero = numero;
                this.Nom = nom;
                this.Ville = ville;
            }
        }
    }
}
