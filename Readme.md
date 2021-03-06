# Locadora MovieMaker

Uma Web Api simples de uma locadora de Filmes


## Acesso

[Locadora MovieMaker Demo Swagger](http://34.74.196.197/swagger/index.html)

## Tecnologias utilizadas

 1. C#
 2. ASP .Net 5
 4. Microsoft Sql Server 2017
 5. Docker
 6. Google Cloud Platform

## Padrões de projeto utilizados

 1. Domain Driven Design
 2. Mediator
 3. Repository Pattern
 4. CQRS
 5. SOLID

## Como executar o projeto localmente

Esse tutorial descreve a execução em um ambiente Windows.

 1. Instale o Docker Desktop ([Download](https://www.docker.com/products/docker-desktop)) 
 2. Clone o repositório do projeto ([Link do repositório](https://github.com/caueSantos/Locadora-MovieMaker))
 3. Dentro da raiz do projeto:
     1. Execute o seguinte comando ``docker-compose up --build -d``  ou
     2. Execute o arquivo ``run.ps1`` que se encontra na raiz
 4. No seu navegador navegue até a url ``http://localhost/swagger/index.html``
