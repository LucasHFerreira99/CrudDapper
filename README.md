# Descrição do Projeto

Este repositório contém um exemplo de aplicação que implementa operações **CRUD** usando **Dapper** em uma **Web API** desenvolvida com **.NET 8** e **SQL Server**. O projeto adota o padrão de repositório (Repository Pattern) para gerenciar o acesso aos dados de maneira eficiente e organizada.

## Recursos

- **CRUD Completo**: Criação, leitura, atualização e exclusão de registros.
- **Dapper**: Micro ORM para acesso rápido e eficiente ao banco de dados SQL Server.
- **.NET 8**: Utilização da mais recente versão do .NET para construção da API.
- **SQL Server**: Banco de dados relacional utilizado para armazenamento dos dados.
- **Repository Pattern**: Implementação do padrão de repositório para promover uma separação clara entre a lógica de negócios e o acesso aos dados.
- - **DTOs**: Utilização de Data Transfer Objects para desacoplar a camada de apresentação da camada de dados e garantir uma estrutura de dados mais limpa e segura.
- **AutoMapper**: Biblioteca para mapeamento automático entre objetos, facilitando a conversão entre entidades e DTOs.

## Tecnologias Utilizadas

- **.NET 8**: Framework para construção da Web API.
- **Dapper**: Micro ORM para mapeamento objeto-relacional.
- **SQL Server**: Sistema de gerenciamento de banco de dados relacional.
- **C#**: Linguagem de programação utilizada.
- **AutoMapper**: Biblioteca para simplificar o mapeamento entre objetos, como entre entidades e DTOs.

## Estrutura do Projeto

- **Controllers**: Endpoints da API para interagir com os dados.
- **Repositories**: Implementação do padrão de repositório para abstração do acesso aos dados.
- **Models**: Definições das entidades do banco de dados.
- **DTOs**: Objetos utilizados para transferir dados entre as camadas da aplicação, ajudando a manter a separação de preocupações e a garantir que apenas os dados necessários sejam expostos.
- **AutoMapper**: Configuração para mapeamento automático entre DTOs e entidades, facilitando a conversão e a manipulação de dados.

## Como Rodar

1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/LucasHFerreira99/CrudDapper.git
   
2. **Configure a String de Conexão**: Atualize a string de conexão no arquivo **appsettings.json** para apontar para seu servidor SQL Server.

3. **Restaure os Pacotes:**
   ```bash
   dotnet restore
4. **Execute o Projeto:**
   Execute o arquivo **CrudDapper.sln** pelo seu Visual Studio ou acesse a pasta **CrudDapper** e dê o comando
   ```bash
   dotnet run

6. **Acesse a API**: A API estará disponível em **http://localhost:5092/swagger/index.html** por padrão.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, enviar pull requests ou fornecer feedback.


