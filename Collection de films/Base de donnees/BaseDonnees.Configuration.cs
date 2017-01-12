using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Collection_de_films.Database
{
    partial class BaseDonnees
    {
        internal void creerTableConfiguration()
        {
            // Table de configuration
            SQLiteCommand commande = new SQLiteCommand(" TABLE " + TABLE_CONFIGURATION +
                " ( "
                + CONFIGURATION_NOM + "	TEXT NOT NULL UNIQUE,"
                + CONFIGURATION_VALEUR + " TEXT NOT NULL,"
                + "PRIMARY KEY(" + CONFIGURATION_NOM + ")"
                + " ) WITHOUT ROWID;", maConnexion);

            commande.ExecuteNonQuery();
        }

        internal string getValeurConfiguration(string nom)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT " + CONFIGURATION_VALEUR + " FROM " + TABLE_CONFIGURATION
                                             + " WHERE " + CONFIGURATION_NOM + " = @nom"))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                return Convert.ToString( executeScalar(cmd));
            }
        }

        internal void setValeurConfiguration(string nom, string valeur)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("INSERT OR REPLACE INTO "
                                                        + TABLE_CONFIGURATION
                                                        + " (" + CONFIGURATION_NOM + "," + CONFIGURATION_VALEUR+") "
                                                        + " VALUES(@nom, @valeur)"))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@valeur", valeur);
                executeNonQuery(cmd);
            }
        }
    }
}
