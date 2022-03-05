
CREATE TABLE TB_USUARIOS(
		 Id_Usuario						INT IDENTITY (1,1) PRIMARY KEY
		,Nm_Usuario 					VARCHAR(200)
		,Tp_Perfil	 					VARCHAR(2)
		,Nm_Email 						VARCHAR(200)
		,Nm_Senha						VARCHAR(200)
		,Dv_RecebeOferta				BIT
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_CATEGORIAS(
		 Id_Categoria					INT IDENTITY (1,1) PRIMARY KEY 
		,Nm_Categoria 					VARCHAR(200)
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_CARACTERISTICAS(
		 Id_Caracteristica				INT IDENTITY (1,1) PRIMARY KEY 
		,Nm_Caracteristica				VARCHAR(200)
		,Nm_Descricao					VARCHAR(300)
		,Nr_Ordem						INT
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_PRODUTOS(
		 Id_Produto						INT IDENTITY (1,1) PRIMARY KEY 
		,Id_Categoria					INT
		,Id_Caracteristica				INT
		,Nm_Produto 					VARCHAR(200)
		,Nm_Descricao					VARCHAR(500)
		,Nr_Quantidade					INT
		,Nr_Valor						NUMERIC(9,2)
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_FOTOS(
		 Id_Foto						INT IDENTITY (1,1) PRIMARY KEY 
		,Id_Produto 					INT
		,Id_Categoria 					INT
		,Nm_Nome	 					VARCHAR(200)
		,Nm_Base64 						VARCHAR(max)
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_CARRINHOS(
		 Id_Carrinho					INT IDENTITY (1,1) PRIMARY KEY 
		,Id_Usuario						INT
		,Id_Produto 					INT
		,Nr_Quantidade					INT
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_VENDAS(
		 Id_Venda						INT IDENTITY (1,1) PRIMARY KEY 
		,Id_Usuario						INT
		,Id_Produto 					INT
		,Tp_Pagamento  					VARCHAR(2)
		,Id_StatusProcessamento			INT
		,Id_Endereco					INT
		,Nr_Valor						Numeric(9,2)
		,Nr_Quantidade					INT
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_ENDERECOS(
		 Id_Endereco					INT IDENTITY (1,1) PRIMARY KEY 
		,Id_Usuario						INT
		,Nm_Endereco					VARCHAR(200)
		,Nr_Numero						VARCHAR(20)
		,Nr_Complemento					VARCHAR(50)
		,Nm_CEP							VARCHAR(9)
		,Nm_Cidade						VARCHAR(200)
		,Nm_Estado						VARCHAR(200)
		,Nm_Bairro						VARCHAR(200)
		,Nm_Referencia					VARCHAR(300)
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);

CREATE TABLE TB_STATUSPROCESSAMENTO(
		 Id_StatusProcessamento			INT IDENTITY (1,1) PRIMARY KEY 
		,Nm_Nome     					VARCHAR(200)
		,Nm_Descricao					VARCHAR(500)
		,Dt_Criacao						DATETIME
		,Nm_Criacao						VARCHAR(200)
		,Dt_Alteracao					DATETIME
		,Nm_Alteracao					VARCHAR(200)
);