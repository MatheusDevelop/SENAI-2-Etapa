CREATE DATABASE Clinica;

CREATE TABLE Veterinario(
	IdVet INT PRIMARY KEY NOT NULL IDENTITY,
	Nome VARCHAR(20) NOT NULL
);






CREATE TABLE Dono(
	IdDono INT PRIMARY KEY NOT NULL IDENTITY,
	Nome VARCHAR(20) NOT NULL,
	
);
CREATE TABLE Raca(
	IdRaca INT PRIMARY KEY NOT NULL IDENTITY,
	NomeRaca VARCHAR(20) NOT NULL,
	
);
CREATE TABLE Tipo(
	IdTipo INT PRIMARY KEY NOT NULL IDENTITY,
	NomeTipo VARCHAR(20) NOT NULL,
	
);


CREATE TABLE Pet(
	IdPet INT PRIMARY KEY NOT NULL IDENTITY,
	Nome VARCHAR(20) NOT NULL ,
	Nascimento DATETIME,
	IdDono INT FOREIGN KEY REFERENCES Dono(IdDono),
	IdRaca INT FOREIGN KEY REFERENCES Raca(IdRaca),
	IdTipo INT FOREIGN KEY REFERENCES Tipo(IdTipo)
);
--NAO ESQUECER DAS FK
CREATE TABLE Atendimento (
	IdAtendimento INT PRIMARY KEY NOT NULL IDENTITY,
	DataAtendimento DATETIME NOT NULL ,
	Descricao VARCHAR(200),
	IdVet INT FOREIGN KEY REFERENCES Veterinario(IdVet),
	IdPet INT FOREIGN KEY REFERENCES Pet(IdPet),
	
);