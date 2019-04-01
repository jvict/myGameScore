create database myGameScore
go
use myGameScore
go
create table Jogador(
	idJogador int primary key identity(1,1),
	nomeJogador varchar(50) not null,
	timeJogador varchar(50) not null,
	emailJogador varchar(50) not null,
	senhaJogador varchar(100) not null

);
go
create table pontuacao(
	idPontuacao int primary key identity(1,1),
	dataPontuacao date,
	pontos int not null
	
);