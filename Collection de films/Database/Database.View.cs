using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Database
{
    partial class BaseDonnees
    {
        
        void DeleteView(string viewName)
        {
            executeNonQuery(new SQLiteCommand("DROP VIEW IF EXISTS " + viewName));
        }

        void CreateView(string viewName, Filtre filtre)
        {
           executeScalar("CREATE VIEW " + viewName
                + " AS select * FROM " + filtre.table + " " + filtre.condition);
        }
    }
}
