--INICIO
USE Optus;

--Todos os acessos e dados desses usuarios
SELECT * 
FROM Acessos
JOIN Usuario
	ON Acessos.IdUsuario = Usuario.IdUsuario
JOIN Album
	ON Acessos.IdAlbum =Album.IdAlbum;
;


--Todos os usuarios
SELECT *
FROM Usuario;

--Todos os admins
SELECT * 
FROM Usuario
WHERE Usuario.AdminBool = 1;

--Todos os usuarios comuns
SELECT * 
FROM Usuario
WHERE Usuario.AdminBool = 0;

--FIM