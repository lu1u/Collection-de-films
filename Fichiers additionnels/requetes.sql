# affiche les images non referencees
select * from images where id not in (select image_id from films) AND id not in (select affiche_id from alternatives)
# supprime les images non referencees
delete from images where id not in (select image_id from films) AND id not in (select affiche_id from alternatives)

# pour relancer la recherche des films qui n ont pas d image ni d alternatives
update films set etat = 0 where image_id = -1 and resume=''


CREATE TABLE FILMS (
	`ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`CHEMIN`	TEXT NOT NULL,
	`TITRE`	TEXT NOT NULL,
	`REALISATEUR`	TEXT NOT NULL,
	`ACTEURS`	TEXT NOT NULL,
	`GENRES`	TEXT NOT NULL,
	`NATIONALITE`	TEXT NOT NULL,
	`RESUME`	TEXT NOT NULL,
	`DATESORTIE`	TEXT NOT NULL,
	`ETAT`	INTEGER NOT NULL,
	`TAG`	TEXT NOT NULL,
	`IMAGE_ID`	INTEGER,
	FOREIGN KEY(`IMAGE_ID`) REFERENCES `IMAGES`(`ID`)
);


CREATE TABLE FILMS ( ID INTEGER PRIMARY KEY AUTOINCREMENT,CHEMIN TEXT NOT NULL,TITRE TEXT NOT NULL,REALISATEUR TEXT NOT NULL,ACTEURS TEXT NOT NULL,GENRES TEXT NOT NULL,NATIONALITE TEXT NOT NULL,RESUME TEXT NOT NULL,DATESORTIE TEXT NOT NULL,ETAT INTEGER NOT NULL,TAG TEXT NOT NULL,IMAGE_ID INTEGER REFERENCES IMAGES(ID) , `Field13` INTEGER, `Field14` INTEGER)