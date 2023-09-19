using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace clientSQLEntreprise
{   /// <summary>
/// Classe permettant la connexion et la gestion de la BdD du même nom
/// </summary>
    class Entreprise2020
    {   /// <summary>
    /// chaine contenant le chaîne de connexion à la base de donnée
    /// </summary>
        private string chaineConnexion;

        /// <summary>
        /// Méthode permettant d'ajouter un produit à la table P
        /// </summary>
        /// <param name="p">Produit à ajouter</param>
        /// <returns>Le nombre de ligne affectés</returns>
        public int AjouterProduit(Produit p)
        {
            // initialisation
            SqlConnection connection = null;
            SqlCommand command = null;
            try {
                // instanciation
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Modification de la command
                command.Connection = connection;
                command.CommandText = "INSERT INTO P VALUES (" + (this.NPMax() + 1) + ",'" + p.Nom + "'," + p.Poids + ",'" + p.Couleur + "')";

                // Exécution de la commande
                int retour = command.ExecuteNonQuery();
                return retour;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            };
        }

        /// <summary>
        /// Constructeur de la classe Entreprise2020
        /// </summary>
        /// <param name="hote">Machine hôte de la base</param>
        /// <param name="BdD">Base à utiliser</param>
        /// <param name="Utilisateur">Utilisateur de la BdD</param>
        /// <param name="MdP">MdP de l'utilisateur</param>
        public Entreprise2020(string hote, string BdD, string Utilisateur, string MdP)
        {
            SqlConnection connection = null;
            try
            {
                // création de la chaîne de connexion
                string chaine_de_connexion = "server=" + hote + ";user id=" + Utilisateur + ";password=" + MdP + ";initial catalog=" + BdD;
                SqlConnectionStringBuilder chaine_builder = new SqlConnectionStringBuilder(chaine_de_connexion);

                // instanciation d'un Objet SQLCONNECTION
                connection = new SqlConnection();
                connection.ConnectionString = chaine_builder.ToString();

                // Ouverture de la connexion
                connection.Open();

                // enregistre la chaîne de connexion
                chaineConnexion = chaine_builder.ToString();
            }
            catch (Exception e) {
                throw e;
            }
            finally
            {
                // fermeture de la connexion
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de lister les produits de la table P
        /// </summary>
        /// <returns>Une liste des produits</returns>
        public List<Produit> ListeProduit()
        {
            // déclaration de 3 objets nécessaires à la lecture ligne par ligne d'une table de la bdd
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                List<Produit> Liste_Produit = new List<Produit>();
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Exécution de la requête pour obtenir l'ensemble des enregistrements de la table P
                command.Connection = connection;
                command.CommandText = "SELECT * FROM P";
                reader = command.ExecuteReader();

                // Remplissage d'une liste préalablement instanciée
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Liste_Produit.Add(new Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3)));
                    }
                }
                else
                {
                    throw new Exception("La table est vide ou inéxistante");
                }

                // Return de la liste
                return Liste_Produit;
            }
            catch (Exception e) {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Méthode donnant le nom des colonnes de la table Produit
        /// </summary>
        /// <returns>Une liste string</returns>
        public List<String> NomColonneProduit()
        {
            // déclaration de 3 objets nécessaires
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                List<String> Nom_Colonnes = new List<String>();
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Exécution de la requête pour obtenir l'ensemble des enregistrements de la table P
                command.Connection = connection;
                command.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'P'";
                reader = command.ExecuteReader();

                // Remplissage d'une liste préalablement instanciée
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Nom_Colonnes.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new Exception("La table est vide ou inéxistante");
                }

                // Return de la liste
                return Nom_Colonnes;
            }
            catch (Exception e) {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Méthode permettant de connaître le NP max de la table P
        /// </summary>
        /// <returns>Le NP max</returns>
        public int NPMax()
        {
            // initialisation
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                // instanciation
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Modification de la commande
                command.Connection = connection;
                command.CommandText = "SELECT MAX(NP) FROM P";

                // Exécution de la commande
                reader = command.ExecuteReader();

                // Traitement des résultats
                int nbNP;
                if (reader.HasRows)
                {
                    reader.Read();
                    nbNP = reader.GetInt32(0);
                }
                else
                {
                    throw new Exception("La table est vide ou inéxistante");
                }
                return nbNP;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }            
            }
        }

        /// <summary>
        /// Méthode permettant de connaître le NF max de la table F
        /// </summary>
        /// <returns>Le NF max</returns>
        public int NFMax()
        {
            // initialisation
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                // instanciation
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Modification de la commande
                command.Connection = connection;
                command.CommandText = "SELECT MAX(NF) FROM F";

                // Exécution de la commande
                reader = command.ExecuteReader();

                // Traitement des résultats
                int nbNF;
                if (reader.HasRows)
                {
                    reader.Read();
                    nbNF = reader.GetInt32(0);
                }
                else
                {
                    throw new Exception("La table est vide ou inéxistante");
                }
                return nbNF;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Méthode permettant de connaître le NU max de la table U
        /// </summary>
        /// <returns>Le NU max</returns>
        public int NUMax()
        {
            // initialisation
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                // instanciation
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Modification de la commande
                command.Connection = connection;
                command.CommandText = "SELECT MAX(NU) FROM U";

                // Exécution de la commande
                reader = command.ExecuteReader();

                // Traitement des résultats
                int nbNU;
                if (reader.HasRows)
                {
                    reader.Read();
                    nbNU = reader.GetInt32(0);
                }
                else
                {
                    throw new Exception("La table est vide ou inéxistante");
                }
                return nbNU;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Méthode permettant de savoir le nombre de produit vendu d'une certaine référence
        /// </summary>
        /// <param name="reference">La référence du produit</param>
        /// <returns>Un objet quantiteLivreParRefResultat</returns>
        public quantiteLivreParRefResultat QuantiteLivreeParReference(int reference)
        {
            // initialisation
            SqlConnection connection = null;
            SqlCommand command = null;
            try {
                // instanciation
                connection = new SqlConnection();
                command = new SqlCommand();
                quantiteLivreParRefResultat qt = new quantiteLivreParRefResultat();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Modification de la commande
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "quantiteLivreeParRef";
                command.Parameters.AddWithValue("@numeroNP", reference);
                command.Parameters.Add("@quantite", System.Data.SqlDbType.Int);
                command.Parameters["@quantite"].Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                command.Parameters["@ReturnVal"].Direction = System.Data.ParameterDirection.ReturnValue;

                // Exécution de la commande
                int i = command.ExecuteNonQuery();


                // Traitement des résultats
                int retour = Convert.ToInt32(command.Parameters["@ReturnVal"].Value);
                if (retour < 0) {
                    qt.retour = retour;
                    return qt;
                }
                else {
                    qt.retour = retour;
                    int quantite = Convert.ToInt32(command.Parameters["@quantite"].Value);
                    qt.Quantite = quantite;
                    return qt;
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Méthode permettant d'ajouter une ligne à la table PUF, en ajoutant le produit, le fournisseur et l'usine dans leur table respective
        /// </summary>
        /// <param name="p">Produit à ajouter</param>
        /// <param name="f">Fournisseur à ajouter</param>
        /// <param name="u">Usine à ajouter</param>
        /// <param name="quantite">Quantité à ajouter</param>
        /// <returns>0 si tout se passe bien</returns>
        public int AjouterPUF(Produit p, Fournisseur f, Usine u, int quantite)
        {
            // déclaration de 3 objets nécessaires
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                List<String> Nom_Colonnes = new List<String>();
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                try
                {
                    // Exécution des requêtes
                    command.Connection = connection;
                    command.Transaction = transaction;
                    int NP = this.NPMax() + 1;
                    int NF = this.NFMax() + 1;
                    int NU = this.NUMax() + 1;
                    command.CommandText = "INSERT INTO P VALUES (" + NP + ",'" + p.Nom + "'," + p.Poids + ",'" + p.Couleur + "')";
                    if (command.ExecuteNonQuery() != 1)
                    {
                        throw new Exception("Erreur pendant l'insertion du produit");
                    }
                    command.CommandText = "INSERT INTO F VALUES (" + NF + ",'" + f.Nom + "','" + f.Statut + "','" + f.Ville + "')";
                    if (command.ExecuteNonQuery() != 1)
                    {
                        throw new Exception("Erreur pendant l'insertion du fournisseur");
                    }
                    command.CommandText = "INSERT INTO U VALUES (" + NU + ",'" + u.Nom + "','" + u.Ville + "')";
                    if (command.ExecuteNonQuery()!= 1)
                    {
                        throw new Exception("Erreur pendant l'insertion de l'usine");
                    }
                    command.CommandText = "INSERT INTO PUF VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + NP + "," + NU + "," + NF + "," + quantite + ")";
                    if (command.ExecuteNonQuery()!= 1)
                    {
                        throw new Exception("Erreur pendant l'insertion de la ligne PUF");
                    }

                    transaction.Commit();
                    return 0;
                }
                catch (Exception e) {
                    transaction.Rollback();
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Ajoute un produit, un fournisseur, une usine et une entrée dans la table PUF via une procédure
        /// </summary>
        /// <param name="p">Produit à ajouter</param>
        /// <param name="f">Fournisseur à ajouter</param>
        /// <param name="u">Usine à ajouter</param>
        /// <param name="quantite">Quantité vendu</param>
        /// <returns>La valeur de retour de la procédure</returns>
        public int AjouterPUFProc(Produit p, Fournisseur f, Usine u, int quantite)
        {
            // initialisation
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                // instanciation
                connection = new SqlConnection();
                command = new SqlCommand();

                // Connection à la base
                connection.ConnectionString = this.chaineConnexion;
                connection.Open();

                // Modification de la commande
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ajoutPufTotal";
                command.Parameters.AddWithValue("@NF", this.NFMax() + 1);
                command.Parameters.AddWithValue("@nomF", f.Nom);
                command.Parameters.AddWithValue("@statut", f.Statut);
                command.Parameters.AddWithValue("@ville", f.Ville);
                command.Parameters.AddWithValue("@NP", this.NPMax() + 1);
                command.Parameters.AddWithValue("@nomP", p.Nom);
                command.Parameters.AddWithValue("@poids", p.Poids);
                command.Parameters.AddWithValue("@couleur", p.Couleur);
                command.Parameters.AddWithValue("@NU", this.NUMax() + 1);
                command.Parameters.AddWithValue("@nomU", u.Nom);
                command.Parameters.AddWithValue("@villeU", u.Ville);
                command.Parameters.AddWithValue("@quantite", quantite);
                command.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                command.Parameters["@ReturnVal"].Direction = System.Data.ParameterDirection.ReturnValue;

                // Exécution de la commande
                int i = command.ExecuteNonQuery();


                // Traitement des résultats
                int retour = Convert.ToInt32(command.Parameters["@ReturnVal"].Value);
                return retour;
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
