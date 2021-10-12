# Introdução 
PhonePlan.Crud.Api - Projeto de CRUD de APIs para inclusão, alteração, remoção e listagem de planos de telefonia.

Frameworks:
Mediatr, AutoMapper, FluentValidation.

ORM:
EntityFrameworkCore utilizando Sqlite in memory.

Testes:
xunit.

# Execução do Projeto
Execução via docker:
1. Acessar a pasta raiz do projeto PhonePlan.Crud
2. Abrir o prompt de comando na pasta raiz.
3. Executar o comando "docker-compose up -d".
4. Acessar o projeto pela url "http://localhost:5000/swagger".

Execução via Visual Studio/IIS Express
1. Abri a Solution do projeto na pasta raiz (PhonePlan.Crud.sln).
2. Realizar depuração do projeto com IIS Express.

# Funcionalidades:

GET: /api/plans
> Método para buscar planos a partir de um DDD obrigatório e filtros opcionais.
> Parametros:
- PlanCode int
- PlanType int (1 = Controle, 2 = Pos, 3 = Pre)
- Operator string
- DDD string *obrigatório*

DELETE: /api/plans
> Método para excluir um plano de um DDD, ou o plano todo.
> Request:
{
  "planCode": 0, // *obrigatório*
  "ddd": "string"
}
> Para excluir o plano do DDD, deve ser passado os parametros.
> Para excluir o plano como um todo, informar apenas o PlanCode.

POST: /api/plans
> Método para adicionar um novo plano ou vincular um plano existente com um DDD.
> Request:
{
  "ddd": "string", // *obrigatório*
  "planCode": 0,
  "phonePlanData": {
    "minutes": 0,
    "internetFranchise": "string",
    "value": 0,
    "planType": 1, // (1 = Controle, 2 = Pos, 3 = Pre)
    "operator": "string"
  }
}
> Para incluir um novo plano, enviar os campos de phonePlanData.
- As propriedades PlanType e Operator são obrigatórias.
> Para vincluar um plano existente a um DDD, enviar o planCode.

PUT: /api/plans
> Método para atualizar um plano existente.
> Request:
{
  "planCode": 0, // *obrigatório*
  "minutes": 0,
  "internetFranchise": "string",
  "value": 0,
  "planType": 1 // (1 = Controle, 2 = Pos, 3 = Pre)
}
