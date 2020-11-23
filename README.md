# Trabalho DAD

Trabalho de conclusão da disciplina Desenvolvimento de Aplicações Distribuidas, do curso Sistemas de informação da PUCMinas unidade Barreiro.
Nesta atividade foi utilizado:
>

* ASP .NET MVC (https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/getting-started)  
* Estratégia Dao (Data Access Object) - (https://pt.wikipedia.org/wiki/Objeto_de_acesso_a_dados)  
* Mysql 8.0.2 (https://dev.mysql.com/downloads/installer/)  
* MySql.Data.8.0.20 - Pacote no Nuget (ele quem permitirá manipular o mysql).

## Instruções

### Clonar o repositório:
```
git clone https://github.com/Firepeix/dad-crud-todo.git
```

### Acessar o diretório

```
cd dad-crud-todo
```

### Abrir o arquivo o projeto (**DAD HelloCrudProjeto.sln**)  

Após abertura do projeto, siga os demais passos:  
**É necessário pois o .gitignore evita que esses arquivos sobem para o repositório.**  

1. Vá até o Package Manager Console:  
**Caminho: Tools -> Nuget Package Manager -> Package Manager Console**  
![PackageManagerConsole](/screenshots/PackageManagerConsole.jpg "PackageManagerConsole")  

2. Restaure os pacotes (**opção restore**)  
(pode levar alguns minutos dependendo do PC, normalmente segundos.).  
![PackageManagerRestore](/screenshots/PackageManagerRestore.jpg "PackageManagerRestore")  

3. Vá até o Manage NuGet Packages for Solution...  
**Caminho: Tools -> Nuget Package Manager -> Manage NuGet Packages for Solution...**  
![PackageManagerSolution](/screenshots/PackageManagerSolution.jpg "PackageManagerSolution")  

5. Selecione o projeto e marque-o como **Set as Startup Project**.  
![Inicializacao](/screenshots/projeto_inicializacao.jpg "Inicializacao")  

6. Selecione o projeto e reconstrua-o **Rebuild**.  
![Rebuild](/screenshots/rebuild.jpg "Rebuild")  

**Está pronto para executar, mas falta ajustar o banco de dados**  

### Instalar o mysql e configurar o banco de dados.  
Se não tiver mysql instalado, **recomendo usar a versão 8.0.20**  

1. No Solution Explorer, encontre a **classe Conexao.cs na pasta Dao** do projeto.  
![ConexaoClasseLocal](/screenshots/conexao.jpg "ConexaoClasseLocal")  

2. Edite a linha 11 de acordo com seu banco de dados.  
![ClasseConexao](/screenshots/classe_conexao_linha11.jpg "ClasseConexao")  


### Código SQL utilizado.  

create database dbcrud;  
use dbcrud;  

```CREATE TABLE tarefas(
id int unsigned PRIMARY KEY AUTO_INCREMENT,
nome varchar(500),
dificuldade int (3),
feita int(1) default 0);  
```
## Projeto funcional - Home.  
![ProjetoFinalizado](/screenshots/ProjetoFinalizado.jpg "ProjetoFinalizado")  
