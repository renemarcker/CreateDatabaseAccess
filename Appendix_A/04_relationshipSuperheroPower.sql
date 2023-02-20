CREATE TABLE SuperheroPower (
	FK_SuperheroID INT NOT NULL,
	FK_PowerID INT NOT NULL,
	PRIMARY KEY (FK_SuperheroID,FK_PowerID)
);
GO

ALTER TABLE SuperheroPower
	ADD FOREIGN KEY (FK_SuperheroID) REFERENCES Superhero(SuperheroID)
	
ALTER TABLE SuperheroPower	
	ADD FOREIGN KEY (FK_PowerID) REFERENCES Power(PowerID)