INSERT INTO Power (Name, Description)
VALUES('Machine Whisper','Power to talk to machines, but only vending machines.')

INSERT INTO Power (Name, Description)
VALUES('Burn','Ability to produce fire, but only from your feet.')

INSERT INTO Power (Name, Description)
VALUES('Teleportation','Ability to teleport, but only to places you can see.')

INSERT INTO Power (Name, Description)
VALUES('Weather Manipulation','Ability to control the weather, but only indoors.')

INSERT INTO Power (Name, Description)
VALUES('Breathing','Ability to breath oxygen from the atmosphere. ')


GO


INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(1,1)

INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(1,4)

INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(2,2)

INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(3,3)

INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(1,5)

INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(2,5)

INSERT INTO SuperheroPower (FK_SuperheroID, FK_PowerID)
VALUES(3,5)
