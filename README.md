# Challenge Locaweb

[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

## 📚 Descrição

O **Challenge Locaweb** foi desenvolvido como parte de um projeto acadêmico da **FIAP**, com foco em construir uma aplicação escalável, eficiente e segura. O aplicativo foi projetado para oferecer funcionalidades robustas, desde o gerenciamento de preferências e configurações de usuários até a integração com serviços de e-mail e controle de spam.

Este projeto adota uma arquitetura escalável e segura, utilizando tecnologias modernas para back-end e front-end, garantindo uma solução eficiente e com capacidade de expansão para demandas futuras.

## 🚀 Funcionalidades

- **API de Preferências e Configurações de Usuário**: Resiliência e segurança dos dados no banco de dados com criptografia.
- **Mock de Serviços de E-mail**: Simulação de operações de e-mail (listar, enviar) com integração ao Google Calendar para criação automática de eventos.
- **Controle de Spam**: Implementação de limites de envio por usuário e listas dinâmicas de bloqueio de domínios ou palavras.
- **Aplicativo com Integração ao Back-end**: Suporte a temas personalizados, validação de e-mails e conectividade rápida.
- **Arquitetura Escalável**: Facilmente expansível para adicionar novas funcionalidades conforme a demanda cresce.
- **Testes Automatizados**: Garantia da robustez e confiabilidade das APIs através de testes automatizados.
- **Documentação Interativa**: Uso do Swagger para fornecer documentação clara e acessível das APIs.

## 🛠️ Tecnologias Utilizadas

O projeto foi desenvolvido com uma seleção estratégica de tecnologias que garantem eficiência, segurança e escalabilidade:

### Linguagens e Frameworks

- **C#**: Base para a construção das APIs, aproveitando sua robustez e versatilidade.
- **Kotlin**: Utilizado para desenvolver as telas do aplicativo.
- **ASP.NET Core**: Framework utilizado para a construção de APIs RESTful robustas.
- **Entity Framework Core**: Gerenciamento de banco de dados e migrações.
- **AutoMapper**: Simplificação da conversão de objetos entre modelos de dados e DTOs.
- **Swagger**: Documentação interativa para facilitar a exploração e teste das APIs.

### Banco de Dados

- **Oracle Database**: Utilizado para o gerenciamento dos dados, escolhendo devido à sua confiabilidade e capacidade de lidar com grandes volumes de informação.

## 📦 Como Instalar e Executar

### Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Kotlin](https://kotlinlang.org/)
- [Oracle Database](https://www.oracle.com/database/)
- [Git](https://git-scm.com/)

### Passos para Instalação

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/challenge-locaweb.git
    ```
2. Acesse o diretório do projeto:
    ```bash
    cd challenge-locaweb
    ```
3. Instale as dependências do projeto back-end:
    ```bash
    dotnet restore
    ```
4. Configure as variáveis de ambiente, como a conexão com o banco de dados Oracle.
5. Compile e execute a API:
    ```bash
    dotnet run
    ```
6. Para o aplicativo Kotlin, siga as instruções no subdiretório do projeto correspondente.

### Executando o Projeto

Para iniciar a aplicação, execute os seguintes comandos:

- **Back-end (ASP.NET Core)**:
    ```bash
    dotnet run
    ```

- **Front-end (Kotlin)**:
    Execute o aplicativo usando o ambiente de desenvolvimento adequado para Kotlin.

## 🔍 Testes

Os testes automatizados garantem a robustez das APIs. Para executar os testes:

```bash
dotnet test
