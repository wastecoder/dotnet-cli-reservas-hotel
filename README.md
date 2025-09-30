# 🏨 Sistema de Reservas de Hotel em C# – CLI

Este projeto foi desenvolvido para **praticar conceitos de Programação Orientada a Objetos (POO)** com C# e .NET,
simulando o gerenciamento de hóspedes, suítes e reservas em um hotel.

A ideia é ter uma aplicação simples em **linha de comando (CLI)**, organizada em camadas (Entities e Services),
permitindo cadastrar suítes, hóspedes e reservas, além de calcular valores de estadias com regras de negócio aplicadas.


---


## 📂 Estrutura do Projeto

```
dotnet-cli-reservas-hotel/DesafioHotel/
├── Domain/
│ ├── Entities/
│ └── Enums/
├── Services/
│ ├── SuiteService.cs
│ └── ReservaService.cs
├── Tests/
│ ├── SuiteServiceTest.cs
│ └── ReservaServiceTest.cs
└── Program.cs
```

> O ponto de entrada é o **Program.cs**, onde você pode escolher quais testes ou serviços executar.


---


## 🛠️ Funcionalidades

- [x] Cadastro de hóspedes
  - [x] Definição de dados básicos (`Nome`, `Sobrenome`, `Idade`)
  - [x] Encapsulamento e validações

- [x] Cadastro de suítes
  - [x] Definição de tipo da suíte, capacidade, valor da diária e se possui cama de casal
  - [x] Encapsulamento e validações

- [x] Gerenciamento de reservas
  - [x] Adicionar e remover reservas
  - [x] Regras de negócio:
    - A reserva deve ter pelo menos um hóspede
    - Quantidade de hóspedes não pode ultrapassar a capacidade da suíte
    - Data de check-out deve ser posterior à data de check-in
  - [x] Calcular valor total da reserva (com desconto de 10% para estadias de 10 dias ou mais)
  - [x] Obter reservas filtradas por suíte

- [x] Estrutura em camadas
  - [x] Entities para as regras de negócio
  - [x] Services para operações de orquestração
  - [x] Tests para validar cenários de sucesso e falha


---


## ⚙️ Tecnologias Utilizadas

- **.NET SDK 9.0:** plataforma utilizada para compilar e executar o projeto.  
- **C#:** linguagem de programação.  
- **Rider:** IDE principal usada no desenvolvimento.  


---


## 🧪 Como Executar

Clone o repositório e entre na pasta do projeto:

```bash
git clone git@github.com:wastecoder/dotnet-cli-reservas-hotel.git
cd dotnet-cli-reservas-hotel
dotnet build
dotnet run
```


---


## 📈 Próximos Passos

- Adicionar um **menu em CLI** para interação com o usuário
- Implementar **exceções personalizadas** para regras de negócio
- Adicionar **testes automatizados** com frameworks (xUnit ou NUnit)
- Implementar **persistência de dados** (JSON ou banco de dados)
- Criar **relatórios** de ocupação, faturamento e reservas
