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
        private const string CONFIGURATION_VUE = "Vue";
        public const string CONF_PARAM_DETAILS = "details";
        public const string CONF_PARAM_LARGEICON = "largeicon";

        private const string CONFIGURATION_ARRET_RECHERCHE_PREMIER = "Arreter recherche au premier";
        private const string CONFIGURATION_RELANCE_RECHERCHE = "Relancer recherche auto";
        private const string CONFIGURATION_MENAGE_FIN = "Faire le menage a la fin";
        private const string CONFIGURATION_IMAGES_LARGEUR_MAX = "Largeur max images";
        private const string CONFIGURATION_SUPPRIMER_AUTRES_ALTERNATIVES = "Supprimer autres alternatives";
        private const string CONFIGURATION_BASE_FILMS = "Base films";

        static private Configuration _instance = new Configuration();
        private Configuration()
        {

        }

        private static object syncRoot = new object();
        static public Configuration instance
        {
            get
            {
                if ( _instance == null )
                    lock ( syncRoot )
                        if ( _instance == null )
                            _instance = new Configuration();

                return _instance;
            }
        }

        public string vue
        {
            get { return getStringValue( CONFIGURATION_VUE, "details" ); }
            set { setValue( CONFIGURATION_VUE, value ); }
        }
        public string baseFilms
        {
            get { return getStringValue( CONFIGURATION_BASE_FILMS, "collection films" ); }
            set { setValue( CONFIGURATION_BASE_FILMS, value ); }
        }

        static public bool arretRecherchePremier
        {
            get { return _instance.getBoolValue( CONFIGURATION_ARRET_RECHERCHE_PREMIER, true ); }
            set { _instance.setValue( CONFIGURATION_ARRET_RECHERCHE_PREMIER, value ); }
        }

        static public bool relancerRechercheAuto
        {
            get { return _instance.getBoolValue( CONFIGURATION_RELANCE_RECHERCHE, true ); }
            set { _instance.setValue( CONFIGURATION_RELANCE_RECHERCHE, value ); }
        }
        static public bool menageALaFin
        {
            get { return _instance.getBoolValue( CONFIGURATION_MENAGE_FIN, false ); }
            set { _instance.setValue( CONFIGURATION_MENAGE_FIN, value ); }
        }

        static public bool supprimerAutresAlternatives
        {
            get { return _instance.getBoolValue( CONFIGURATION_SUPPRIMER_AUTRES_ALTERNATIVES, false ); }
            set { _instance.setValue( CONFIGURATION_SUPPRIMER_AUTRES_ALTERNATIVES, value ); }
        }

        static public int largeurMaxImages
        {
            get { return _instance.getIntValue( CONFIGURATION_IMAGES_LARGEUR_MAX, 0 ); }
            set { _instance.setValue( CONFIGURATION_IMAGES_LARGEUR_MAX, value ); }
        }

        

        public string getStringValue( string key, string defaut = "" )
        {
            string valeur = BaseConfiguration.instance.getValeurConfiguration(key);
            if ( valeur == null )
                valeur = defaut;
            return valeur;
        }

        public int getIntValue( string key, int defaut = 0 )
        {
            try
            {
                int result = defaut;
                int.TryParse( getStringValue( key, defaut.ToString() ), out result );
                return result;
            }
            catch ( Exception )
            {

                return defaut;
            }
        }

        public bool getBoolValue( string key, bool defaut = false )
        {
            try
            {
                return getIntValue( key, defaut ? 1 : 0 ) == 0 ? false : true;
            }
            catch ( Exception )
            {

                return defaut;
            }
        }
        public void setValue( string nom, string valeur )
        {
            BaseConfiguration.instance.setValeurConfiguration( nom, valeur );
        }

        public void setValue( string nom, int valeur )
        {
            setValue( nom, valeur.ToString() );
        }

        public void setValue( string nom, bool valeur )
        {
            setValue( nom, valeur ? 1 : 0 );
        }
    }
}
