using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Manipulation des VUES dans la base
/// </summary>
namespace Collection_de_films.Database
{
    partial class BaseDonnees : IDisposable
    {
        private const string INDEX_NUMBER = "Rank";

        static void DeleteView(string viewName)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "DROP VIEW "+ viewName;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        // Une exception peut survenir si la vue n'existe pas encore
                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                connection.Close();
            }
        }

        static void CreateView(string viewName, Filtre filtre)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "CREATE VIEW " + viewName + " AS ( select *, ROW_NUMBER() OVER(ORDER BY id ASC) AS "+ INDEX_NUMBER + " FROM " +  filtre.table + " " + filtre.condition + " )" ;
                        command.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                connection.Close();
            }
        }
    }
}
