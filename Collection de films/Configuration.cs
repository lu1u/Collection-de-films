using Collection_de_films.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films
{
    class Configuration
    {
        public const string CONFIGURATION_VUE = "Vue";
        public const string CONF_PARAM_DETAILS = "details";
        public const string CONF_PARAM_LARGEICON = "largeicon";

        public const string CONFIGURATION_ARRET_RECHERCHE_PREMIER = "Arreter recherche au premier";
        public const string CONFIGURATION_RELANCE_RECHERCHE = "Relancer recherche auto";
        public const string CONFIGURATION_MENAGE_FIN = "Faire le menage a la fin";
        public const string CONFIGURATION_IMAGES_LARGEUR_MAX = "Largeur max images";

        static private Configuration _instance = new Configuration();
        private Configuration()
        {

        }

        static public Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();

            return _instance;
        }
        /*
        public class Parametre
        {
            string nom;

            public Parametre(string n, string v)
            {
                nom = n;
                Valeur = v;
            }

            public Parametre(string n)
            {
                nom = n;
            }
            public string Nom
            {
                get
                {
                    return nom;
                }
            }

            public string Valeur
            {
                get
                {
                    // Chercher dans la base
                    return Database.BaseDeDonnees.getInstance().getValeurConfiguration(nom);
                }

                set
                {
                    Database.BaseDeDonnees.getInstance().setValeurConfiguration(nom, value);
                }
            }

            public void setValue(string v)
            {
                Valeur = v;
            }

            public void setValue(int i)
            {
                Valeur = Valeur.ToString();
            }

            public void setValue(bool b)
            {
                setValue(b ? 1 : 0);
            }
        }*/

        private Dictionary<string, string> _parametres = new Dictionary<string, string>();
        public string this[string key]
        {
            get
            {
                return _parametres[key] ;
            }

            set
            {
                _parametres[key] = value ;
            }
        }

        public string getStringValue(string key, string defaut = "")
        {
            try
            {
                return _parametres[key] ;

            }
            catch (Exception)
            {
            }

            string valeur = BaseDonnees.getInstance().getValeurConfiguration(key);
           if (valeur == null)
                valeur = defaut ;
            _parametres[key] = valeur;
            return valeur;
        }

        public int getIntValue(string key, int defaut = 0)
        {
            try
            {
                return int.Parse(getStringValue(key, defaut.ToString()));
            }
            catch (Exception)
            {

                return defaut;
            }
        }

        public bool getBoolValue(string key, bool defaut = false)
        {
            try
            {
                return getIntValue(key, defaut ? 1:0) == 0 ? false : true ;
            }
            catch (Exception)
            {

                return defaut;
            }
        }
        public void setValue(string nom, string valeur)
        {
            _parametres[nom] = valeur ;
            BaseDonnees.getInstance().setValeurConfiguration(nom, valeur);
        }

        public void setValue(string nom, int valeur)
        {
            setValue(nom, valeur.ToString());
        }

        public void setValue(string nom, bool valeur)
        {
            setValue(nom, valeur ? 1 : 0);
        }
    }
}
