CREATE SCHEMA RpsGame;

CREATE DATABASE RpsGameTestDb;


CREATE TABLE Players
(
	PlayerId int PRIMARY KEY NOT NULL IDENTITY(1, 1),
	PlayerFname NVARCHAR(20) NOT NULL, -- string max length 20 characters
	PlayerLname NVARCHAR(20) NOT NULL,
	PlayerAge int NOT NULL,
	CONSTRAINT AgeConstraint CHECK(PlayerAge < 125 AND PlayerAge > 0),
);

INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge) 
VALUES('Mark', 'Moore', 42);

INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge) 
VALUES('Mason', 'Sanborn', 21);



SELECT * FROM Players;




CREATE TABLE Players
(
	PlayerId int PRIMARY KEY NOT NULL IDENTITY(1, 1),
	PlayerFname NVARCHAR(20) NOT NULL, -- string max length 20 characters
	PlayerLname NVARCHAR(20) NOT NULL,
	PlayerAge int,
	PlayerAddress NVARCHAR(30),
);

CREATE TABLE Game
(
	GameId int PRIMARY KEY NOT NULL IDENTITY(1, 1),
	PlayerId int FOREIGN KEY REFERENCES Players(PlayerId),
	Score int NOT NULL,
);

CREATE TABLE RpsRound
(
	RoundId int PRIMARY KEY NOT NULL IDENTITY(1, 1),
	GameId int FOREIGN KEY REFERENCES Game(GameId),
	WinnerId int NOT NULL,
	Player1Id int NOT NULL,
	Player2Id int NOT NULL
);

INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge) 
VALUES('Mark', 'Moore', 42);

INSERT INTO Players (PlayerFname, PlayerLname) 
VALUES('Computer', 'Player');



SELECT * FROM Players;
SELECT * FROM Game;
SELECT * FROM RpsRound;

SELECT Players.PlayerFname FROM Players, Game WHERE Game.Score > 1 AND Game.PlayerId = Players.PlayerId;

SELECT Players.PlayerFname, Players.PlayerLname FROM Players, RpsRound WHERE RpsRound.WinnerId = Players.PlayerId AND RpsRound.GameId = 3