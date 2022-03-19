
/* Tabela de status */

insert into dbo.tb_status values ('ativo','ativo teste', getdate(), null, null, null)
insert into dbo.tb_status values ('Desativado', 'Desativado teste', null, null, null)


/* Tabela de usuarios */
		
insert into dbo.tb_usuarios values('Administrador', 1, 'administrador@gmail.com', 'senhateste', 0, 1, getdate(), null, null, null)
insert into dbo.tb_usuarios values('Funcionario', 2, 'funcionario@gmail.com', 'senhateste2', 0, 1, getdate(), 1, null, null)
insert into dbo.tb_usuarios values('Cliente', 3, 'cliente@gmail.com', 'senhateste3', 1, 1, getdate(), 1, null, null)


/* Tabela de Categorias dos produtos */

insert into dbo.tb_categorias values('Bermudas', 1, getdate(), null, null, null)
insert into dbo.tb_categorias values('Calças', 1, getdate(), null, null, null)
insert into dbo.tb_categorias values('Camisas', 1, getdate(), null, null, null)
insert into dbo.tb_categorias values('Camiseta', 1, getdate(), null, null, null)
insert into dbo.tb_categorias values('Jaquetas', 1, getdate(), null, null, null)
insert into dbo.tb_categorias values('Moletom', 1, getdate(), null, null, null)
insert into dbo.tb_categorias values('Calçados', 1, getdate(), null, null, null)


/* Tabela Variacoes (Tamanho, Cor etc...) */

insert into dbo.tb_variacoes values ('Tamanho', 'PP', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', 'P', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', 'M', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', 'G', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', 'GG', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', '34', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', '35', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', '36', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', '37', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Tamanho', '38', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Cor', 'Branco', 1, getdate(), 1, null, null)
insert into dbo.tb_variacoes values ('Cor', 'Preto', 1, getdate(), 1, null, null)


/* Tabela de Produtos */

insert into dbo.tb_produtos values(1, 1, 'Bermuda Oakley', 'Produto de alta qualidade para seu dia a dia!', 10, '129,90', 1, getdate(), 1, null, null)
insert into dbo.tb_produtos values(1, 4, 'Bermuda Hurley', 'Produto de alta qualidade para seu dia a dia!', 20, '97,90', 1, getdate(), 1, null, null)
insert into dbo.tb_produtos values(3, 3, 'Camisa Nike', 'Produto de alta qualidade para seu dia a dia!', 35, '49,90', 1, getdate(), 1, null, null)
insert into dbo.tb_produtos values(3, 1, 'Camisa Adidas', 'Produto de alta qualidade para seu dia a dia!', 10, '30,90', 1, getdate(), 1, null, null)
insert into dbo.tb_produtos values(3, 12, 'Camisa Adidas', 'Produto de alta qualidade para seu dia a dia!', 10, '30,90', 1, getdate(), 1, null, null)


/* Tabela de Caracteristicas */

insert into dbo.tb_caracteristicas values('Composição', '50% Algodão', 1, 1, 1, 1, 1, getdate(), 1, null, null)
insert into dbo.tb_caracteristicas values('Composição', '50% Poliester', 1, 1, 1, 2, 1, getdate(), 1, null, null)
insert into dbo.tb_caracteristicas values('Composição', '70% Algodão', 1, 1, 2, 3, 1, getdate(), 1, null, null)
insert into dbo.tb_caracteristicas values('Composição', '30% Poliester', 1, 1, 2, 4, 1, getdate(), 1, null, null)







