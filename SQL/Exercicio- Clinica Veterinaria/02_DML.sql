/*
INICIO
*/
USE Clinica;

INSERT INTO Veterinario (Nome)
VALUES('Matheus Barbosa');

INSERT INTO Veterinario (Nome)
VALUES('John Doe');

SELECT * FROM Veterinario;

INSERT INTO Dono (Nome) 
VALUES('Alessandra Gomes');

SELECT * FROM Dono;

INSERT INTO Raca (NomeRaca)
VALUES('Pinscher'),('Chihuahua'),('Poodle');

SELECT * FROM Raca;

INSERT INTO Tipo (NomeTipo)
VALUES('Cachorro'),('Ave'),('Roedor');

SELECT * 
FROM Tipo;

INSERT INTO Pet(Nome,Nascimento,IdDono,IdRaca,IdTipo)
VALUES('Chimbinha','2004-06-24T10:00:00',1,2,1);

SELECT * 
FROM Pet;

INSERT INTO Atendimento(DataAtendimento,Descricao,IdPet,IdVet)
VALUES('2020-11-20T18:30:00','Realizado procedimento de drenagem estomacal no pet',1,1);

INSERT INTO Atendimento(DataAtendimento,Descricao,IdPet,IdVet)
VALUES('2021-11-20T18:30:00','Aplicação de Vacina anual vermicida',1,1);

SELECT * 
FROM Atendimento;

/*
FIM
*/