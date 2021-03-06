DROP DATABASE bd_system;
CREATE DATABASE bd_system;
USE bd_system;

CREATE TABLE sexo (
  cod_sex INT NOT NULL AUTO_INCREMENT,
  nome_sex VARCHAR(100) NOT NULL,
  PRIMARY KEY (cod_sex)
);

insert INTO sexo values (1, "Maculino");
insert INTO sexo values (2, "Feminino");


CREATE TABLE endereco (
  cod_end INT NOT NULL AUTO_INCREMENT,
  rua_end VARCHAR(300) NULL DEFAULT NULL,
  numero_end INT NULL DEFAULT NULL,
  bairro_end VARCHAR(100) NULL DEFAULT NULL,
  cidade_end VARCHAR(100) NULL DEFAULT NULL,
  estado_end VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (cod_end)
);

CREATE TABLE funcionario (
  cod_func INT NOT NULL AUTO_INCREMENT,
  nome_func VARCHAR(200) NOT NULL,
  cpf_func VARCHAR(20) NOT NULL,
  rg_func VARCHAR(20) NULL DEFAULT NULL,
  datanasc_func DATE NULL DEFAULT NULL,
  telefone_func VARCHAR(50) NULL DEFAULT NULL,
  email_func VARCHAR(200) NULL DEFAULT NULL,
  celular_func VARCHAR(50) NULL DEFAULT NULL,
  funcao_func VARCHAR(50) NULL DEFAULT NULL,
  salario_func DOUBLE NULL DEFAULT NULL,
  cod_sex_fk INT NULL DEFAULT NULL,
  cod_end_fk INT NULL DEFAULT NULL,
  PRIMARY KEY (cod_func),
  INDEX cod_sex_fk (cod_sex_fk ASC) VISIBLE,
  INDEX cod_end_fk (cod_end_fk ASC) VISIBLE,
  CONSTRAINT funcionario_ibfk_1
    FOREIGN KEY (cod_sex_fk)
    REFERENCES sexo (cod_sex),
  CONSTRAINT funcionario_ibfk_2
    FOREIGN KEY (cod_end_fk)
    REFERENCES endereco (cod_end)
);
insert INTO funcionario values (null, "Lucas Fael","040.030.343-34","35353612", "2000-01-02", "993130202", "faelucas@gamil.com", "923003213", "Vendedor", "2.400", "1", "1");
insert INTO funcionario values (null, "Jessica Jones","525.230.342-03","123499", "1989-09-12", "992356789", "jonoes02jj@gamil.com", "9276584312", "Gerente", "10.400", "2", "1");
insert INTO funcionario values (null, "João Fazzi","120.130.333-31","9595312", "1988-04-06", "993993212", "Fazzi01jo@gamil.com", "9347689333", "Vendedor", "2.400", "1", "1");
insert INTO funcionario values (null, "Fael Silva","121.133.458-91","9595289", "1998-08-11", "994536702", "faesilv@gamil.com", "923123987", "Vendedor", "2.400", "1", "1");
insert INTO funcionario values (null, "Macio Felai","023.030.271-24","75352616", "1999-05-07", "993139841", "donatoma@gamil.com", "993139841", "Vendedor", "2.400", "1", "1");
insert INTO funcionario values (null, "Luiza Sousa","043.121.161-13","89351615", "2001-07-07", "993456701", "sousalu@gamil.com", "993456701", "Vendedora", "2.400", "2", "1");

CREATE TABLE cliente (
  cod_cli INT NOT NULL AUTO_INCREMENT,
  nome_cli VARCHAR(200) NOT NULL,
  cpf_cli VARCHAR(20) NOT NULL,
  rg_cli VARCHAR(20) NULL DEFAULT NULL,
  datanasc_cli DATE NULL DEFAULT NULL,
  telefone_fixo_cli VARCHAR(50) NULL DEFAULT NULL,
  telefone_celular_cli VARCHAR(50) NULL DEFAULT NULL,
  email_cli VARCHAR(200) NULL DEFAULT NULL,
  cod_sex_fk INT NULL DEFAULT NULL,
  cod_end_fk INT NULL DEFAULT NULL,
  PRIMARY KEY (cod_cli),
  INDEX cod_sex_fk (cod_sex_fk ASC) VISIBLE,
  INDEX cod_end_fk (cod_end_fk ASC) VISIBLE,
  CONSTRAINT cliente_ibfk_1
    FOREIGN KEY (cod_sex_fk)
    REFERENCES sexo (cod_sex),
  CONSTRAINT cliente_ibfk_2
    FOREIGN KEY (cod_end_fk)
    REFERENCES endereco (cod_end)
);

CREATE TABLE produto (
  cod_prod INT NOT NULL AUTO_INCREMENT,
  nome_prod VARCHAR(100) NOT NULL,
  descricao_prod VARCHAR(200) NULL DEFAULT NULL,
  marca_prod VARCHAR(100) NULL DEFAULT NULL,
  valor_venda_prod DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (cod_prod)
);

CREATE TABLE venda (
  cod_vend INT NOT NULL AUTO_INCREMENT,
  cod_func_fk INT NULL DEFAULT NULL,
  cod_cli_fk INT NULL DEFAULT NULL,
  data_vend DATE NULL DEFAULT NULL,
  forma_pagamento_vend VARCHAR(100) NULL DEFAULT NULL,
  valor_total_vend DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (cod_vend),
  INDEX cod_func_fk (cod_func_fk ASC) VISIBLE,
  INDEX cod_cli_fk (cod_cli_fk ASC) VISIBLE,
  CONSTRAINT compra_ibfk_1
    FOREIGN KEY (cod_func_fk)
    REFERENCES funcionario (cod_func),
  CONSTRAINT compra_ibfk_2
    FOREIGN KEY (cod_cli_fk)
    REFERENCES cliente (cod_cli)
  );

CREATE TABLE venda_itens (
  cod_itenv INT NOT NULL AUTO_INCREMENT,
  quantidade_itenv INT NOT NULL,
  valor_itenv FLOAT NOT NULL,
  valor_total_itenv FLOAT NOT NULL,
  cod_prod_fk INT NOT NULL,
  cod_vend_fk INT NOT NULL,
  PRIMARY KEY (cod_itenv),
  INDEX cod_prod_fk (cod_prod_fk ASC) VISIBLE,
  INDEX cod_vend_fk (cod_vend_fk ASC) VISIBLE,
  CONSTRAINT itens_compra_ibfk_1
    FOREIGN KEY (cod_prod_fk)
    REFERENCES produto (cod_prod),
  CONSTRAINT itens_compra_ibfk_2
    FOREIGN KEY (cod_vend_fk)
    REFERENCES venda (cod_vend)
);

CREATE TABLE usuario (
  cod_usu INT NOT NULL AUTO_INCREMENT,
  usuario_usu VARCHAR(100) NOT NULL,
  senha_usu TEXT NOT NULL,
  cod_func_fk INT NOT NULL,
  PRIMARY KEY (cod_usu),
  INDEX cod_func_fk_idx (cod_func_fk ASC) VISIBLE,
  CONSTRAINT cod_func_fk
    FOREIGN KEY (cod_func_fk)
    REFERENCES funcionario (cod_func)
);

select * FROM cliente;