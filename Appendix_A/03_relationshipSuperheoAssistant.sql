ALTER TABLE Superhero
ADD Assistant_ID INT NOT NULL

ALTER TABLE Superhero
ADD FOREIGN KEY (Assistant_ID) REFERENCES Assistant(AssistantID)