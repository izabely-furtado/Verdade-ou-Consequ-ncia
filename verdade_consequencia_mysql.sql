/*
delete from opcao;
delete from verdade_consequencia_tipo;
delete from verdade; 
delete from consequencia;
delete from tipo;
delete from pessoa;
delete from sequencia;
delete from alerta;
*/

use vdd_desafio;
-- --------------------------------------------------------
--
-- Estrutura para tabela "alerta"
--
create table alerta (
	id INT UNSIGNED AUTO_INCREMENT,
	descricao VARCHAR(255) not null, 
	tipo int not null, /*tipo 1-pulo | 2-21+ | 3-parabenizacao*/
	primary key (id)
);

INSERT INTO alerta (descricao, tipo) VALUES
('descricao 1', '1'), ('descricao 2', '1'), ('descricao 3', '2'), 
('descricao 4', '2'), ('descricao 5', '3'), ('descricao 6', '3');

-- --------------------------------------------------------
--
-- Estrutura para tabela "pessoa"
--

create table pessoa (
	id INT UNSIGNED AUTO_INCREMENT,
	nome VARCHAR(255) not null,
	sexo int not null, -- 1-masculino | 2-feminino | 3-ambos
	gosto_feminino boolean default false, 
	gosto_masculino boolean default false,
    primary key (id)
);

INSERT INTO pessoa (nome, sexo) VALUES
('nome 1', '1'), ('nome 2', '1'), ('nome 3', '2'), 
('nome 4', '2'), ('nome 5', '3'), ('nome 6', '3');

-- --------------------------------------------------------
--
-- Estrutura para tabela "consequencia"
--
create table consequencia (
	id INT UNSIGNED AUTO_INCREMENT,
	descricao VARCHAR(255) not null, 
	idade INT not null, 
	id_pessoa INT UNSIGNED, 
	foreign key (id_pessoa) references pessoa(id),
	primary key (id)
);

INSERT INTO consequencia (descricao, idade) VALUES
('pergunta 1', '0'), ('pergunta 2', '15'), ('pergunta 3', '18'), 
('pergunta 4', '21'), ('pergunta 5', '0'), ('pergunta 6', '12');
-- --------------------------------------------------------
--
-- Estrutura para tabela "sequencia"
--
create table sequencia (
	id INT UNSIGNED AUTO_INCREMENT,
	descricao VARCHAR(255) not null, 
	resultado_a int UNSIGNED not null, 
	resultado_b int UNSIGNED not null, 
	resultado_c int UNSIGNED not null, 
	resultado_d int UNSIGNED not null, 
	resultado_e int UNSIGNED not null,
	foreign key (resultado_a) references consequencia(id),
	foreign key (resultado_b) references consequencia(id),
	foreign key (resultado_c) references consequencia(id),
	foreign key (resultado_d) references consequencia(id),
	foreign key (resultado_e) references consequencia(id),
	primary key (id)
);

INSERT INTO sequencia (descricao, resultado_a, resultado_b, resultado_c, resultado_d, resultado_e) VALUES
('sequencia 1', 1, 1, 2, 2, 3), ('sequencia 2', 1, 1, 2, 2, 3), 
('sequencia 3', 1, 1, 2, 2, 3), ('sequencia 4', 1, 1, 2, 2, 3), 
('sequencia 5', 1, 1, 2, 2, 3);

-- --------------------------------------------------------
--
-- Estrutura para tabela "verdade"
--
create table verdade (
	id INT UNSIGNED AUTO_INCREMENT,
	descricao VARCHAR(255) not null, 
	idade int not null, 
	id_pessoa int UNSIGNED,
	id_sequencia int UNSIGNED,
	foreign key (id_pessoa) references pessoa(id),
	foreign key (id_sequencia) references sequencia(id),
	primary key (id)
);

INSERT INTO verdade (descricao, idade) VALUES
('pergunta 1', '0'), ('pergunta 2', '15'), ('pergunta 3', '18'), 
('pergunta 4', '21'), ('pergunta 5', '0'), ('pergunta 6', '12');


-- --------------------------------------------------------
--
-- Estrutura para tabela "opcao"
--
create table opcao (
	id INT UNSIGNED AUTO_INCREMENT,
	descricao VARCHAR(255) not null, 
	letra VARCHAR(1) not null, 
	id_verdade int UNSIGNED not null,
	foreign key (id_verdade) references verdade(id),
	primary key (id)
);

INSERT INTO opcao (descricao, letra, id_verdade) VALUES
('opção 1', 'A', 1), ('opção 2', 'B', 1), ('opção 3', 'C', 1),
('opção 4', 'D', 1), ('opção 5', 'E', 1), ('opção 6', 'A', 2);

-- --------------------------------------------------------
--
-- Estrutura para tabela "tipo"
--
create table tipo (
	id INT UNSIGNED AUTO_INCREMENT,
	descricao VARCHAR(255) not null, 
	primary key (id)
);

INSERT INTO tipo (descricao) VALUES
('tipo 1'), ('tipo 2'), ('tipo 3'),
('tipo 4'), ('tipo 5'), ('tipo 6');

-- --------------------------------------------------------
--
-- Estrutura para tabela "verdade_consequencia_tipo"
--
create table verdade_consequencia_tipo (
	id INT UNSIGNED AUTO_INCREMENT,
	id_tipo int UNSIGNED not null, 
	tipo_vdd_ou_consequencia int not null, -- 1-vdd 2-consequencia
	id_verdade int UNSIGNED, 
	id_consequencia int UNSIGNED, 
	foreign key (id_tipo) references tipo(id),
	foreign key (id_verdade) references verdade(id),
	foreign key (id_consequencia) references consequencia(id),
	primary key (id)
);

INSERT INTO verdade_consequencia_tipo (id_tipo, tipo_vdd_ou_consequencia, id_verdade) VALUES
(1, 1, 1), (2, 1, 2), (3, 1, 3);

INSERT INTO verdade_consequencia_tipo (id_tipo, tipo_vdd_ou_consequencia, id_consequencia) VALUES
(1, 2, 1), (2, 2, 2), (3, 2, 3);

----------------------------------------------------------
INSERT INTO alerta (descricao, tipo) VALUES ('descricao 1', '1'), ('descricao 2', '1'), ('descricao 3', '2'),  ('descricao 4', '2'), ('descricao 5', '3'), ('descricao 6', '3')
