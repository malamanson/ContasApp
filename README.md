
# Sistema de Controle de Contas Pessoais

Este projeto é um aplicativo de controle financeiro pessoal desenvolvido em **React Native** para plataformas iOS e Android. A aplicação permite que o usuário registre e visualize suas transações, categorizadas em entradas e saídas, e se conecta a uma API desenvolvida em **ASP.NET Core** para armazenamento e recuperação de dados.

---

## Funcionalidades

- **Cadastro e visualização de transações**: registre entradas e saídas com descrição, valor e data.
- **Conexão com API**: integração com backend para armazenamento seguro dos dados.
- **Interface responsiva**: layout otimizado para iOS e Android.

---

## Tecnologias Utilizadas

- **React Native** com **Expo** para o desenvolvimento mobile.
- **Axios** para as requisições HTTP.
- **ASP.NET Core API** para gerenciamento e persistência de dados.
- **SQL Server** para o banco de dados.

---

## Configuração do Ambiente

1. **Pré-requisitos**:
   - **Node.js** (v14.x ou superior)
   - **Yarn** (recomendado para gerenciamento de pacotes)
   - **Expo CLI** (para facilitar o desenvolvimento em React Native)
   - **.NET SDK** (para rodar a API)
   - **SQL Server** (para o banco de dados)

2. **Clone o Repositório**:

   ```bash
   git clone https://github.com/malamanson/ContasApp
   cd ContasApp
   ```

3. **Instale as Dependências**:

   No diretório raiz do projeto, execute:

   ```bash
   yarn install
   ```

4. **Configuração da API**:
   - Navegue até a pasta do backend e configure a conexão com o banco de dados no arquivo `appsettings.json`.
   - Execute as migrações para configurar o banco de dados:

     ```bash
     dotnet ef database update
     ```

5. **Configuração do Arquivo `.env`**:
   - Na raiz do projeto mobile, crie um arquivo `.env`.
   - Adicione a URL da API para as chamadas de rede:

     ```plaintext
     API_URL=https://seu-servidor/api
     ```

---

## Como Fazer o Build do App

1. **Build de Desenvolvimento (Expo CLI)**:
   - Para iniciar o app no ambiente de desenvolvimento, execute:

     ```bash
     expo start
     ```

2. **Build de Produção**:
   - Para fazer o build final do app, execute os comandos apropriados:

     ```bash
     expo build:android  # Para Android
     expo build:ios      # Para iOS
     ```

   - O Expo gerará os arquivos APK (Android) ou IPA (iOS) para instalação em dispositivos.

---

## Conectar o App à API

1. **Configurar URL da API**:
   - Certifique-se de que o arquivo `.env` contém a variável `API_URL` apontando para a URL correta da sua API.

2. **Requisições HTTP**:
   - O app utiliza `Axios` para enviar requisições à API.
   - Verifique o endpoint na estrutura do código para garantir que as rotas da API estão corretamente configuradas, como `/transacoes` para operações de transações.

3. **Permissões de Rede**:
   - No Android, edite o arquivo `AndroidManifest.xml` para garantir que a permissão de internet está habilitada:

     ```xml
     <uses-permission android:name="android.permission.INTERNET" />
     ```

---

## Estrutura do Projeto

- **src/components**: Componentes reutilizáveis, como listas e formulários de transações.
- **src/screens**: Telas principais do app, incluindo Home, Cadastro e Visualização de Transações.
- **src/services**: Configuração do Axios para comunicação com a API.
- **src/utils**: Utilitários e helpers para formatação e manipulação de dados.

---

## Comandos Importantes

- **Iniciar Expo**: `expo start`
- **Build Android**: `expo build:android`
- **Build iOS**: `expo build:ios`
- **API (ASP.NET)**:
  - Executar API: `dotnet run`
  - Atualizar Banco de Dados: `dotnet ef database update`

---

## Erros Comuns e Soluções

- **Erro: `Could not connect to API`**:
  - Verifique se a API está rodando e a URL está correta no `.env`.
  - Se estiver em desenvolvimento, use o IP local.

- **Chaves Duplicadas no FlatList**:
  - Certifique-se de que cada item da lista tem uma `key` única. Verifique o `id` de cada transação para evitar duplicação.

---
