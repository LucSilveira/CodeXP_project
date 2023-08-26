create database TECHCYCLE;

use TECHCYCLE;

create table Usuario(
	idUsuario int identity primary key not null,
	loginUsuario varchar(255) not null,
	senha varchar(255) not null,
	nomeCompleto varchar(255) not null,
	email varchar(255) not null,
	fotoUsuario varchar(255),
	departamento varchar(50),
	tipoDeUsuario varchar(15) not null,
	statusAprovacao varchar(10) not null
);

create table Marca(
	idMarca int identity primary key not null,
	nomeMarca varchar(50) not  null
);

create table Categoria(
	idCategoria int identity primary key not null,
	nomeCategoria varchar(30) not null
);

create table Produto(
	idProduto int identity primary key not null,
	nomeProduto varchar(255) not null,
	modeloProduto varchar(255) not null,
	memoriaProduto int not null,
	processador varchar(50) not null,
	descricao text,
	codIdentificacao varchar(255),
	dataLancamento date,
	idMarca int foreign key references Marca(idMarca),
	idCategoria int foreign key references Categoria(idCategoria)
);

create table Avaliacao(
	idAvaliacao int identity primary key not null,
	descricaoAvaliacao text not null,
	tipoAvaliacao varchar(15)
);

create table Anuncio(
	idAnuncio int identity primary key not null,
	precoAnuncio decimal(10,2) not null,
	dataExpiracao date,
	idAvaliacao int foreign key references Avaliacao(idAvaliacao),
	idProduto int foreign key references Produto(idProduto)
);

create table FotosAnuncio(
	idFotosAnuncio int identity primary key not null,
	fotoDoAnuncio varchar(255),
	idAnuncio int foreign key references Anuncio(idAnuncio)
);

create table Comentario(
	idComentario int identity primary key not null,
	comentarioTexto text,
	idAnuncio int foreign key references Anuncio(idAnuncio),
	idUsuario int foreign key references Usuario(idUsuario)
);

create table Interesse(
	idInteresse int identity primary key not null,
	idUsuarioInteressado int foreign key references Usuario(idUsuario),
	idUsuarioAprovacao int foreign key references Usuario(idUsuario),
	idAnuncio int foreign key references Anuncio(idAnuncio),
	statusAprovacao varchar(10)
);

