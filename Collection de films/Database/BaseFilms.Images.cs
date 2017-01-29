using Collection_de_films.Films;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;

namespace Collection_de_films.Database
{
    partial class BaseFilms : IDisposable
    {
        const string TABLE_IMAGES = "IMAGES";
        const string IMAGES_ID = "ID";
        const string IMAGE_IMAGE = "IMAGE";

        /// <summary>
        /// Creation de la table des images
        /// </summary>
        internal void creerTableImages()
        {
            // Table films
            executeNonQuery($"CREATE TABLE {TABLE_IMAGES} ( {IMAGES_ID} INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, {IMAGE_IMAGE} BLOB NOT NULL);");
        }

        /// <summary>
        /// Lit une image depuis la table IMAGES
        /// </summary>
        /// <param name="imageId">id de l'image</param>
        /// <returns></returns>
        internal Image getImage(int imageId)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT {IMAGE_IMAGE} FROM {TABLE_IMAGES} WHERE {IMAGES_ID} = @id"))
            {
                cmd.Parameters.AddWithValue("@id", imageId);
                SQLiteDataReader reader = executeReader(cmd);
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    reader.Read();
                    return Film.getImage(reader, reader.GetOrdinal(IMAGE_IMAGE));
                }
            }
            return null;
        }



        /// <summary>
        /// Retourne l'id d'une image, en l'ayant ajoute dans la base au besoin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int getImageId( int id, Image img)
        {
            if (imageExiste(id))
                return id;

            // Ajouter l'image
            return ajouteImage(img);
        }

        /// <summary>
        /// Retourne vrai si l'id existe dans la table des images
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal bool imageExiste(int id)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT Count(*) FROM {TABLE_IMAGES} WHERE {IMAGES_ID} = @id"))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    object o = executeScalar(cmd);
                    return (Convert.ToInt32(o) > 0);
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }                                        
            return false;
        }

        /// <summary>
        /// Ajoute une image dans la table, retourne son id
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        internal int ajouteImage(Image img)
        {
            if (img == null)
                return -1;

            using (SQLiteCommand command = new SQLiteCommand($"INSERT into {TABLE_IMAGES} ({IMAGE_IMAGE}) VALUES (@image)"))
            {
                command.Parameters.AddWithValue("@image", SqlBinnaryPeutEtreNull(Images.imageToByteArray(img)));
                executeNonQuery(command);

                // Obtenir l'id du dernier film ajoute
                command.CommandText = $"select last_insert_rowid() as {IMAGES_ID} from {TABLE_IMAGES};";
                object o = executeScalar(command);
                return Convert.ToInt32(o);
            }
        }

        /// <summary>
        /// Supprime l'image dont on donne l'id
        /// </summary>
        /// <param name="id"></param>
        internal void supprimeImage(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_IMAGES} WHERE {IMAGES_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                executeNonQuery(command);
            }
        }
    }
}

