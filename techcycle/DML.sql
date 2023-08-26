use TechCycle;

-- inserindo dados na tabela de Usuario:
insert into Usuario(loginUsuario, senha, nomeCompleto, email, fotoUsuario, departamento, tipoDeUsuario, statusAprovacao)
values('Administrador', 'admin', 'Administrador do sistema', 'TechCycle.FCode@gmail.com', 'chrisEvans.jpg', 'Diretoria', 'Administrador', 'Aprovado'),
	  ('Usuario', 'user', 'Usuario do sistema', 'usuario@gmail.com', 'robertJr.jpg', 'Desenvolvimento', 'Funcionario', 'Aguardo');

select * from Usuario;

-- inserindo dados na tabela de Marcas:
insert into Marca(nomeMarca)
values('Dell'), ('Apple');

select * from Marca;

-- inserindo dados na tabela de Categorias:
insert into Categoria(nomeCategoria)
values('Notebook'), ('Computador'), ('Outros');

select * from Categoria;

-- inserindo dados na tabela de Produtos:
insert into Produto(nomeProduto, modeloProduto, memoriaProduto, processador, descricao, codIdentificacao, dataLancamento, idMarca, idCategoria)
values('TestProduto', 'testador', 16, 'Intel i7', 'Produto padrao para testar a aplicacao', 'test01', '2019-12-21', 1, 1);

select * from Produto;

-- inserindo dados na tabela de Avaliacao:
insert into Avaliacao(descricaoAvaliacao, tipoAvaliacao)
values('Produto com sinais de uso, mas com um bom desempenho', 'Bom'), ('Produto com leves sinais de uso, mas com bom desempenho', 'Muito Bom'),
	  ('Produto sem marcas aparentes de uso, com um ótimo desempenho', 'Excelente');

select * from Avaliacao;

-- inserindo dados na tabela de Anuncio:
insert into Anuncio(precoAnuncio, dataExpiracao, idAvaliacao, idProduto)
values(1500, '2019-12-20', 3, 1);

select * from Anuncio;

-- inserindo dados na tabela de Fotos de Anuncios:
insert into FotosAnuncio(fotoDoAnuncio, idAnuncio)
values('macbook01.png', 2);

select * from FotosAnuncio;

-- inserindo dados na tabela de Comentarios:
insert into Comentario(comentarioTexto, idAnuncio, idUsuario)
values('Anuncio excelente para teste', 2, 2);

select * from Comentario;

-- inserindo dados na tabela de Interesse:
insert into Interesse(idUsuarioInteressado, idUsuarioAprovacao, idAnuncio, statusAprovacao)
values(2, 1, 2, 'Aguardo'), (2, 1, 2, 'Aprovado');

select * from Interesse;