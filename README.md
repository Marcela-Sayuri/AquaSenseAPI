Projeto - Cidades ESG Inteligentes
O AquaSenseAPI é uma aplicação desenvolvida em C# com .NET 8, relacionada ao contexto de Cidades ESG Inteligentes.
Neste desafio, o projeto foi adaptado para aplicação de práticas de DevOps, utilizando integração contínua, entrega contínua, containerização e orquestração da infraestrutura.
A solução utiliza GitHub Actions para o pipeline CI/CD, Docker para containerização, Docker Compose para orquestração local, Azure Container Registry para armazenamento da imagem Docker e Azure App Service para os ambientes de Staging e Produção.
Como executar localmente com Docker
Pré-requisitos
Para executar o projeto localmente, é necessário ter instalado:
- Docker Desktop
- Git
1. Clonar o projeto
git clone https://github.com/Marcela-Sayuri/AquaSenseAPI.git

Acesse a pasta do projeto:
cd AquaSenseAPI

2. Configurar as variáveis de ambiente
O projeto possui o arquivo .env.example, que apresenta a variável necessária para execução do SQL Server.
Crie um arquivo .env na raiz do projeto e configure:
MSSQL_SA_PASSWORD=ChangeMe_2026#Sql

O arquivo .env não é versionado no GitHub. O arquivo .env.example é disponibilizado para demonstrar a configuração necessária sem expor credenciais.
3. Subir a aplicação
Execute:
docker compose up --build -d

O Docker Compose irá criar e executar os serviços da aplicação e do banco de dados SQL Server.
4. Verificar os containers
docker compose ps

5. Acessar a API
Com os containers em execução, o Swagger da API pode ser acessado em:
http://localhost:8080/swagger/index.html
6. Encerrar a aplicação
Para parar os containers:
docker compose down

O SQL Server utiliza um volume Docker para persistência dos dados.
Pipeline CI/CD
O pipeline de integração contínua e entrega contínua foi desenvolvido utilizando GitHub Actions.
O arquivo responsável pelo pipeline está localizado em:
.github/workflows/ci-cd.yml

O pipeline é executado automaticamente a partir de alterações na branch main.
Ferramentas utilizadas
- GitHub
- GitHub Actions
- .NET 8
- Docker
- Azure Container Registry
- Azure App Service
Etapas do pipeline
O pipeline realiza as seguintes etapas:
1. Baixa o código do repositório;
2. Configura o ambiente .NET 8;
3. Restaura as dependências;
4. Configura o banco SQL Server para os testes;
5. Compila a aplicação;
6. Executa os testes automatizados;
7. Realiza o login no Azure Container Registry;
8. Constrói a imagem Docker;
9. Publica a imagem no Azure Container Registry;
10. Realiza o deploy no ambiente de Staging;
11. Após o Staging, realiza o deploy no ambiente de Produção.
Funcionamento
O fluxo do pipeline pode ser representado da seguinte forma:
Push na branch main
        ↓
    Build
        ↓
Testes automatizados
        ↓
Construção da imagem Docker
        ↓
Azure Container Registry
        ↓
     Staging
        ↓
    Produção

O deploy de Produção depende da conclusão do deploy de Staging. Dessa forma, a aplicação passa primeiro pelo ambiente de Staging antes de ser disponibilizada em Produção.
Containerização
A aplicação foi containerizada utilizando Docker.
Foi utilizado um Dockerfile com multi-stage build, separando as etapas de compilação e execução da aplicação.
Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["AquaSenseAPI.csproj", "./"]
RUN dotnet restore "AquaSenseAPI.csproj"

COPY . .
RUN dotnet build "AquaSenseAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AquaSenseAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AquaSenseAPI.dll"]

Estratégia utilizada
O Dockerfile utiliza quatro etapas:
Base: utiliza a imagem ASP.NET 8.0 para execução da aplicação e expõe a porta 8080.
Build: utiliza o SDK do .NET 8 para restaurar as dependências e compilar o projeto.
Publish: executa o dotnet publish em configuração Release, preparando os arquivos necessários para execução.
Final: utiliza somente a imagem runtime do ASP.NET e copia os arquivos publicados para a imagem final.
Essa estratégia de multi-stage build separa o ambiente de compilação do ambiente de execução e evita levar o SDK completo para a imagem final.
Docker Compose
O projeto também possui um arquivo docker-compose.yml responsável pela orquestração local da aplicação.
O Compose configura:
- Container da aplicação AquaSenseAPI;
- Container do SQL Server;
- Rede Docker compartilhada;
- Volume para persistência do SQL Server;
- Variáveis de ambiente;
- Comunicação entre a aplicação e o banco de dados.
Prints do funcionamento
As evidências visuais do projeto estão apresentadas na documentação técnica em PDF/PPT entregue juntamente com este README.
A documentação apresenta evidências de:
- Execução local com Docker Compose;
- Build da aplicação;
- Execução dos testes automatizados;
- Pipeline CI/CD no GitHub Actions;
- Construção e publicação da imagem Docker;
- Deploy em Staging;
- Funcionamento da aplicação em Staging;
- Deploy em Produção;
- Funcionamento da aplicação em Produção.
Links dos ambientes
Staging — Swagger
https://aquasense-staging-marcela-etczf5hdb2fpcreu.northcentralus-01.azurewebsites.net/swagger/index.html
Produção — Swagger
https://aquasense-production-marcela-b7fvgdevhyfccrgm.northcentralus-01.azurewebsites.net/swagger/index.html
Os links permitem verificar diretamente o funcionamento da API nos ambientes publicados.
Tecnologias utilizadas
Linguagem e framework
- C#
- .NET 8
- ASP.NET Core
- Entity Framework Core
Banco de dados
- Microsoft SQL Server
API
- Swagger / OpenAPI
DevOps e infraestrutura
- Git
- GitHub
- GitHub Actions
- Docker
- Docker Compose
- Azure Container Registry
- Azure App Service
Ambientes
- Ambiente local
- Staging
- Produção