# ApiWeb - Sistema de Clientes com Autenticação JWT (.NET 8)

Este projeto é uma **API REST** desenvolvida em **.NET 8**, com **Entity Framework Core**, **autenticação JWT** e **arquitetura em camadas (DDD)**.

---

## Funcionalidades
- Registro e login de usuários com senha criptografada (BCrypt)
- Geração de token JWT com expiração configurável
- CRUD completo de Clientes (Create, Read, Update, Delete)
- Proteção de rotas com `[Authorize]`
- Banco de dados SQL Server (LocalDB)
- Migrations automáticas com Entity Framework

---

## Estrutura do Projeto
ApiWeb/
├── ApiWeb/ → Camada Web (Controllers, Program.cs)
├── Application/ → DTOs, Interfaces e Services
├── Domain/ → Entidades (Cliente, User)
├── Infrastructure/ → DbContext, Repositórios, TokenService
├── ApiWeb.sln → Solution principal
├── appsettings.json → Configurações gerais
├── .gitignore
└── README.md

---

## Tecnologias Utilizadas
- ASP.NET Core 8.0
- Entity Framework Core
- JWT (System.IdentityModel.Tokens.Jwt)
- BCrypt.Net
- SQL Server (LocalDB)
- Dependency Injection (nativa do .NET)

---

## Endpoints Principais

### Autenticação
| Método | Endpoint | Descrição |
|---------|-----------|-----------|
| POST | `/api/auth/register` | Cria novo usuário |
| POST | `/api/auth/login` | Faz login e retorna token JWT |

### Clientes (protegidos com `[Authorize]`)
| Método | Endpoint | Descrição |
|---------|-----------|-----------|
| GET | `/api/clientes` | Lista todos os clientes |
| GET | `/api/clientes/{id}` | Busca cliente por ID |
| POST | `/api/clientes` | Cria novo cliente |
| PUT | `/api/clientes/{id}` | Atualiza cliente existente |
| DELETE | `/api/clientes/{id}` | Remove cliente |

---

## Como Executar Localmente

### 1️ Clonar o repositório
git clone https://github.com/seuusuario/ApiWeb.git](https://github.com/psoaresatlas/ApiWeb-.NET-8-DDD-EF-Core-JWT)
cd ApiWeb

## 2️ Restaurar dependências
dotnet restore

## 3️ Aplicar migrations (gera o banco local)
dotnet ef database update

## 4 Rodar o projeto

dotnet run --project ApiWeb

## A API estará disponível em:

http://localhost:5050

-- Testando no Postman
Faça Register → cria usuário

Faça Login → copia token JWT

Use o token nas requisições protegidas (Bearer Token)

Teste o CRUD completo de clientes

-- Próximos Passos
Validações com DataAnnotations

Tratamento de erros customizado (Middleware)

Logs estruturados

Roles/Claims no JWT

Testes unitários (xUnit)

## Desenvolvido por: Pedro Suarex
## Projeto finalizado: Outubro/2025
