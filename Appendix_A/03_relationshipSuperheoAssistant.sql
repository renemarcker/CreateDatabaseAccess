ALTER TABLE Assistant
ADD FK_SuperheroID INT NOT NULL

ALTER TABLE Assistant
ADD FOREIGN KEY (FK_SuperheroID) REFERENCES Superhero(SuperheroID)