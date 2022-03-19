-- create database dbo
/*
	drop table dbo.tb_usuarios
	drop table dbo.tb_categorias
	drop table dbo.tb_caracteristicas
	drop table dbo.tb_produtos
	drop table dbo.tb_fotos
	drop table dbo.tb_carrinhos
	drop table dbo.tb_vendas
	drop table dbo.enderecos
	drop table dbo.tb_status
	drop table dbo.tb_tipos_pagamentos
	drop table dbo.tb_bancos
*/

create table dbo.tb_status(
		 id_status						int identity (1,1) primary key 
		,nm_nome     					varchar(200)
		,nm_descricao					varchar(500)
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)


create table dbo.tb_usuarios(
		 id_usuario						int identity (1,1) primary key
		,nm_usuario 					varchar(200)
		,tp_perfil	 					varchar(2) -- servirá para definir se é cliente ou funcionario
		,nm_email 						varchar(200)
		,nm_senha						varchar(200)
		,dv_recebeoferta				bit
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_usuarios ADD CONSTRAINT FK_tb_usuarios_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)


create table dbo.tb_categorias(
		 id_categoria					int identity (1,1) primary key 
		,nm_categoria 					varchar(200)
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_categorias ADD CONSTRAINT FK_tb_categorias_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_categorias ADD CONSTRAINT FK_tb_categorias_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_categorias ADD CONSTRAINT FK_tb_categorias_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)


create table dbo.tb_variacoes(
		 id_variacao					int identity (1,1) primary key 
		,nm_variacao					varchar(200)
		,nm_descricao					varchar(300)
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

create table dbo.tb_produtos(
		 id_produto						int identity (1,1) primary key 
		,id_categoria					int
		,id_variacao					int
		,nm_produto 					varchar(200)
		,nm_descricao					varchar(500)
		,nr_quantidade					int
		,nr_valor						numeric(9,2)
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_produtos ADD CONSTRAINT FK_tb_produtos_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_produtos ADD CONSTRAINT FK_tb_produtos_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_produtos ADD CONSTRAINT FK_tb_produtos_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

ALTER TABLE dbo.tb_produtos ADD CONSTRAINT FK_tb_produtos_x_tb_categorias_id_categoria FOREIGN KEY (id_categoria) REFERENCES dbo.tb_categorias (id_categoria)

ALTER TABLE dbo.tb_produtos ADD CONSTRAINT FK_tb_produtos_x_tb_variacoes_id_variacao FOREIGN KEY (id_variacao) REFERENCES dbo.tb_variacoes (id_variacao)


create table dbo.tb_caracteristicas(
		 id_caracteristica				int identity (1,1) primary key 
		,nm_caracteristica				varchar(200)
		,nm_descricao					varchar(300)
		,nr_ordem						int
		,id_categoria					int
		,id_produto						int
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_caracteristicas ADD CONSTRAINT FK_tb_caracteristicas_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_caracteristicas ADD CONSTRAINT FK_tb_caracteristicas_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_caracteristicas ADD CONSTRAINT FK_tb_caracteristicas_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

create table dbo.tb_fotos(
		 id_foto						int identity (1,1) primary key 
		,id_produto 					int
		,id_categoria 					int
		,nm_nome	 					varchar(200)
		,nm_base64 						varchar(max)
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_fotos ADD CONSTRAINT FK_tb_fotos_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_fotos ADD CONSTRAINT FK_tb_fotos_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_fotos ADD CONSTRAINT FK_tb_fotos_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

ALTER TABLE dbo.tb_fotos ADD CONSTRAINT FK_tb_fotos_x_tb_categorias_id_categoria FOREIGN KEY (id_categoria) REFERENCES dbo.tb_categorias (id_categoria)

ALTER TABLE dbo.tb_fotos ADD CONSTRAINT FK_tb_fotos_x_tb_produtos_id_produto FOREIGN KEY (id_produto) REFERENCES dbo.tb_produtos (id_produto)


create table dbo.tb_carrinhos(
		 id_carrinho					int identity (1,1) primary key 
		,id_usuario						int
		,id_produto 					int
		,nr_quantidade					int
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_carrinhos ADD CONSTRAINT FK_tb_carrinhos_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_carrinhos ADD CONSTRAINT FK_tb_carrinhos_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_carrinhos ADD CONSTRAINT FK_tb_carrinhos_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

ALTER TABLE dbo.tb_carrinhos ADD CONSTRAINT FK_tb_carrinhos_x_tb_produtos_id_produto FOREIGN KEY (id_produto) REFERENCES dbo.tb_produtos (id_produto)

ALTER TABLE dbo.tb_carrinhos ADD CONSTRAINT FK_tb_carrinhos_x_tb_usuarios_id_usuario FOREIGN KEY (id_usuario) REFERENCES dbo.tb_usuarios (id_usuario)


create table dbo.tb_vendas(
		 id_venda						int identity (1,1) primary key 
		,id_usuario						int
		,id_produto 					int
		,tp_pagamento  					varchar(2)
		,id_status						int
		,id_endereco					int
		,nr_valor						numeric(9,2)
		,nr_quantidade					int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_vendas ADD CONSTRAINT FK_tb_vendas_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_vendas ADD CONSTRAINT FK_tb_vendas_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_vendas ADD CONSTRAINT FK_tb_vendas_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

ALTER TABLE dbo.tb_vendas ADD CONSTRAINT FK_tb_vendas_x_tb_produtos_id_produto FOREIGN KEY (id_produto) REFERENCES dbo.tb_produtos (id_produto)

ALTER TABLE dbo.tb_vendas ADD CONSTRAINT FK_tb_vendas_x_tb_usuarios_id_usuario FOREIGN KEY (id_usuario) REFERENCES dbo.tb_usuarios (id_usuario)


create table dbo.tb_enderecos(
		 id_endereco					int identity (1,1) primary key 
		,id_usuario						int
		,nm_endereco					varchar(200)
		,nr_numero						varchar(20)
		,nr_complemento					varchar(50)
		,nm_cep							varchar(9)
		,nm_cidade						varchar(200)
		,nm_estado						varchar(200)
		,nm_bairro						varchar(200)
		,nm_referencia					varchar(300)
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_enderecos ADD CONSTRAINT FK_tb_enderecos_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_enderecos ADD CONSTRAINT FK_tb_enderecos_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_enderecos ADD CONSTRAINT FK_tb_enderecos_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

ALTER TABLE dbo.tb_enderecos ADD CONSTRAINT FK_tb_enderecos_x_tb_usuarios_id_usuario FOREIGN KEY (id_usuario) REFERENCES dbo.tb_usuarios (id_usuario)


create table dbo.tb_bancos(
		 id_banco						int identity (1,1) primary key 
		,nm_banco			 			varchar(50)
		,id_status						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_bancos ADD CONSTRAINT FK_tb_bancos_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_bancos ADD CONSTRAINT FK_tb_bancos_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_bancos ADD CONSTRAINT FK_tb_bancos_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)


create table dbo.tb_tipos_pagamentos(
		 id_tipo_pagamento				int identity (1,1) primary key 
		,nm_tipo_pagamento  			varchar(50)
		,id_status						int
		,id_banco						int
		,dt_criacao						datetime
		,id_usuario_criacao				int
		,dt_alteracao					datetime
		,id_usuario_alteracao			int
)

ALTER TABLE dbo.tb_tipos_pagamentos ADD CONSTRAINT FK_tb_tipos_pagamentos_x_tb_usuarios_id_usuario_criacao FOREIGN KEY (id_usuario_criacao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_tipos_pagamentos ADD CONSTRAINT FK_tb_tipos_pagamentos_x_tb_usuarios_id_usuario_alteracao FOREIGN KEY (id_usuario_alteracao) REFERENCES dbo.tb_usuarios (id_usuario)

ALTER TABLE dbo.tb_tipos_pagamentos ADD CONSTRAINT FK_tb_tipos_pagamentos_x_tb_status_id_status FOREIGN KEY (id_status) REFERENCES dbo.tb_status (id_status)

ALTER TABLE dbo.tb_tipos_pagamentos ADD CONSTRAINT FK_tb_tipos_pagamentos_x_tb_bancos_id_banco FOREIGN KEY (id_banco) REFERENCES dbo.tb_bancos (id_banco)

Create table dbo.tb_comentarios (
		id_comentario					int identity (1,1) primary key,
		nm_titulo						varchar(200),
		nm_comentario					varchar(1000),
		id_produto						int,
		nr_nota							int,
		dt_criacao						datetime,
		id_usuario_criacao				int
)

ALTER TABLE dbo.tb_comentarios ADD CONSTRAINT FK_tb_comentarios_x_tb_produtos_id_produto FOREIGN KEY (id_produto) REFERENCES dbo.tb_produtos (id_produto)


