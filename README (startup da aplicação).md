# Sobre o projeto
O projeto consiste em uma aplicação web capaz de importar um arquivo .txt com vários dados de movimentações financeiras, normaliza-lo e registra-lo em um banco de dados, para futuramente apresenta-los em tela, mostrando o saldo em conta do usuário.

A aplicação foi construida separando o front do back (api).

O back foi construído para ser uma api, que poderá ser consumida por qualquer client que deseje, utilizando conceitos de DDD em sua construção.
Já o front, utiliza Angular, comumente utilizado em conjunto com .NET no mercado hoje em dia.

# Startup
Para rodar a aplicação, será necessário ter os seguintes pacotes e ferramentas instaladas:

## Pacotes
* *NPM* versão 6.14.14 ou superior. Mais detalhes em https://www.npmjs.com/;
* *Node.js* versão 14.17.4 ou superior. Mais detalhes em https://nodejs.org/en/;
* *Angular CLI* versão 12.2.0 ou superior. Mais detalhes em https://angular.io/cli;
* *SQL Server* para o servidor de banco. Mais detalhes em https://www.microsoft.com/pt-br/sql-server/sql-server-downloads. Caso utilize Linux, consulte https://docs.microsoft.com/pt-br/sql/linux/sql-server-linux-setup?view=sql-server-ver15;
* *IIS* para o servidor da api. Mais detalhes em https://www.microsoft.com/pt-BR/download/details.aspx?id=48264 (Caso você tenha instalado o Visual Studio Community ou outra versão, é possível que tenha o IIS Express instalado, não sendo necessário buscar outra versão). Para publicar o projeto em um servidor Linux, consulte https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-3.1;
* *.Net Core* na versão 3.1 para a api. Mais detalhes em https://dotnet.microsoft.com/download/dotnet/3.1;

## Ferramentas indicadas
No desenvolvimento do projeto, foram utilizadas as seguintes ferramentas:
* *Visual Studio 2019 Community* para o desenvolvimento da API. Mais detalhes em https://visualstudio.microsoft.com/pt-br/;
* *Visual Studio Code* para desenvolvimento do fron. Mais detalhes em https://visualstudio.microsoft.com/pt-br/;
* *SQL Server Management Studio 18.3.1* para controle do banco. Mais detalhes em https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15;

## Configurações do projeto
Para iniciar o projeto, seja em ambiente do produção ou desenvolvimento, será necessário preparar o banco de dados.

* Ao abrir o projeto, com Visual Studio Community (ou outra versão), abra a ferramenta de terminal *Package Manager Console*;
* Na aba *Default project*, selecione *ByCoders.ParseCNAB.Dados*;
* Rode o comando *add-migration "v1"*, para adicionar os scripts automáticos do Entity Core, para manipulação do banco;
* Rode o comando *update-database* para atualizar o banco com esses scripts;

Com esse procedimento, será criado um banco de dados, algumas tabelas e uma carga inicial.

Obs.: caso seja necessário alterar as informações de acesso ao banco, acesse o arquivo *appsettings.json* no projeto *ByCoders.ParseCNAB.API*, e altere o valor da propriedade *ByCodersConnection*.

## Como utilizar
Por default, quando você executa a api, a página principal é a documentação dela, gerida pela ferramenta *Swagger*.
Nessa página, você terá acesso a todas as rotas da api.

Estando no Visual Studio Community (ou outra versão), selecione o *ByCoders.ParseCNAB.API* como *Startup Project*, e clique em play.

Para a aplicação do front, dentro da pasta dela, abra qualquer terminal e execute *ng serve*.

A aplicação de front, consiste em três telas:
* Login;
* Uma para cadastro dos arquivos de CNAB;
* Uma para listar os dados das movimentações salvas;

Por defaulr, a primeira tela sempre será a de login.
Após se autenticar, você poderá navegar entre as telas, utilizando o menu superior.

### Usuário para login
email: administrador@email.com
senha: 12345

