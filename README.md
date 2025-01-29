README do Projeto - [Desafio técnico]
Este projeto foi desenvolvido Com .net e c#. Ultilizando o padrão repository.
Para executar o projeto basta restaurar os pacotes nuget em seguida aplicar um update no migration para criar o banco de dados e inserir os dados de testes.



Visão Geral
O sistema  tem como objetivo Permitir operações de CRUD entre as classes wallet e payment.


Padrão Repository
O padrão Repository é um padrão de projeto que abstrai o acesso à camada de persistência de dados. Ele define uma interface para as operações de banco de dados (CRUD) e as classes que implementam essa interface (repositórios) encapsulam a lógica de acesso aos dados.

Vantagens do uso do padrão Repository:

Isolamento da camada de acesso a dados: A lógica de acesso ao banco de dados fica isolada nos repositórios, o que facilita a manutenção e evolução do sistema.
Testabilidade: Os repositórios podem ser facilmente mockados em testes unitários, permitindo testar a lógica de negócios sem depender do banco de dados.
Flexibilidade: A implementação do repositório pode ser facilmente trocada (ex: mudar de Entity Framework para Dapper) sem afetar o restante do sistema.
O que falta para finalizar o desafio
Para finalizar o desafio, as seguintes tarefas precisam ser realizadas:


TO-DO:
-Foi iniciado a implementação da autenticação por jwt mas por falta de tempo ainda não consegui finalizar.
-Métodos de transação entre carteiras.
-Filtro por data.
