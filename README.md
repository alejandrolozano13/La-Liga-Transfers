# ⚽ LaLiga Transfers API

Projeto desenvolvido em .NET para gerenciamento de transferências de jogadores na La Liga, com autenticação JWT, controle de acesso por roles, uso de MongoDB, e arquitetura organizada por responsabilidades.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- MongoDB
- JWT (JSON Web Token)
- FluentValidation
- Entity Framework (em partes opcionais)
- Swagger
- Claims-based Authorization
- Clean Architecture (dividido em `Domain`, `Application`, `Infrastructure`)

---

## 🧠 Funcionalidades Implementadas

### ✅ Autenticação com JWT

- Login via endpoint `/api/Login`
- Geração de token com:
  - `sub` (Id do usuário)
  - `email`
  - `role`
- Expiração de 2h
- Dados sensíveis como `JWT Key`, `Issuer`, `Audience` são lidos de variáveis de ambiente

### ✅ Controle de Acesso com Policies

- Permissões baseadas em **roles**, utilizando policies configuradas com `AddAuthorizationBuilder`.
  
#### Policies existentes:
| Política               | Roles permitidos         |
|------------------------|--------------------------|
| `OnlyAdmins`           | `Admin`                  |
| `CanManageTransfers`   | `Admin`, `ClubeStaff`    |
| `CanSuggestTransfer`   | `Agent`                  |

- Policies aplicadas via `[Authorize(Policy = "...")]` nos controllers.

### ✅ MongoDB como banco de dados

- Conectado por string de conexão vinda de variável de ambiente
- Utilização de repositórios com injeção de dependência
- Interface com `IMongoCollection<T>`

### ✅ Validações

- Uso de FluentValidation para validar entrada nos DTOs

### ✅ Arquitetura do Projeto

