# Calculadora de CDB

> Sistema para calculo de CDB (Certificado de Depósito Bancário). 
> Desenvolvido usando Docker, Angular e .Net 8.
> Arquitetura backend baseada em [Clean Architecture](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164)
> Tests unitários
> Tests funcionais (Specflow ainda não suporta .net 8)

# Patterns utilizados

> Fail fast validation
> Dependency Injection
> Mediator
> Command
> Retry Policy
> Circuit Breaker (A utilizar)
> Repository (A utilizar)

# Como rodar o projeto

Você pode rodar o projeto direto da sua máquina.

Pré-requisitos

1 - Node.js superior a 12 instalada.
2 - [Docker](https://www.docker.com/products/docker-desktop/)
3 - [.Net 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

> Rodar

1 - Faça o clone deste projeto no github
2 - Acesse a pasta do projeto
3 - docker compose up -d --build
4 - Acesse a aplicação através do endereço http://localhost:8090