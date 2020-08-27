/*
INICIO
*/

--Todos os atendimentos detalhados
SELECT * 
FROM Atendimento
INNER JOIN Veterinario
	ON Atendimento.IdVet = Veterinario.IdVet 
INNER JOIN Pet
	ON Atendimento.IdPet = Pet.IdPet 
INNER JOIN Dono
	ON Pet.IdDono = Dono.IdDono
INNER JOIN Tipo
	ON Pet.IdTipo = Tipo.IdTipo
;

--Todos os atendimentos simplificado
SELECT * 
FROM Atendimento
JOIN Veterinario
	ON Atendimento.IdVet = Veterinario.IdVet
;

 


--Todos os atendimentos de todos os Veterinarios
SELECT * 
FROM Atendimento
RIGHT JOIN Veterinario 
	ON Atendimento.IdVet = Veterinario.IdVet;



