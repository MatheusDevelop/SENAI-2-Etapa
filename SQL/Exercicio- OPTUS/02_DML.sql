--INICIO
USE Optus;

INSERT INTO Album (Nome)
VALUES('Starway to Heaven');

INSERT INTO Estilo (IdAlbum,NomeEstilo)
VALUES(1,'Rock');

INSERT INTO Artista (IdAlbum,NomeArtista)
VALUES(1,'Led Zeppelin');

INSERT INTO Usuario(Nome,Senha,AdminBool)
VALUES
('Matheus Barbosa','fic132',0),
('John Doe','jd132',0),
('OptusCEO','admin121',1);

INSERT INTO Acessos (IdUsuario,IdAlbum)
VALUES
(1,1),
(2,1),
(2,1),
(3,1);

--FIM
