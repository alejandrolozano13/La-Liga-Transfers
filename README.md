# ⚽ LaLiga Transfers API

API REST desenvolvida em **.NET 8**, com foco na **gestão de transferências de jogadores da La Liga**, utilizando autenticação via **JWT**, autorização baseada em **roles e policies**, **MongoDB** como banco de dados, e arquitetura **modular e escalável**.

---

## 🧰 Tecnologias & Ferramentas

- ✅ ASP.NET Core 8
- ✅ MongoDB
- ✅ JWT (JSON Web Token)
- ✅ FluentValidation
- ✅ Swagger com suporte a autenticação
- ✅ Autenticação e Autorização via Claims & Roles
- ✅ Clean Architecture (camadas bem separadas)
- ✅ Variáveis de ambiente para configuração segura

---

## 🔐 Autenticação e Autorização

### ✔ Autenticação com JWT

- Token gerado ao realizar login com email e senha
- Contém **Claims**: `sub`, `email`, `role`
- Tempo de expiração: 2 horas
- Assinado com chave segura (`HS256`)

### ✔ Autorização baseada em **Policies**

Policies configuradas para controlar acesso por perfil (role):

| Policy                | Acesso permitido a:       |
|-----------------------|---------------------------|
| `OnlyAdmins`          | `Admin`                   |
| `CanManageTransfers`  | `Admin`, `ClubeStaff`     |
| `CanSuggestTransfer`  | `Agent`                   |

Aplicadas em endpoints via `[Authorize(Policy = "PolicyName")]`.

---

## 🧠 Funcionalidades já implementadas

- [x] Cadastro e login de usuários
- [x] Hash de senhas com `BCrypt`
- [x] Geração de token JWT
- [x] Validação e autorização com middleware do ASP.NET
- [x] Controle de acesso com policies baseadas em roles
- [x] Estrutura limpa e modular (camadas separadas)
- [x] MongoDB com injeção de dependência configurada
- [x] Swagger com suporte a autenticação

---

## 🏗 Estrutura do Projeto

