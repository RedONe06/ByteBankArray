![image](https://user-images.githubusercontent.com/98191980/194566349-1fda1152-4e33-449b-81e4-a036c1d2758b.png)

<img src="https://img.shields.io/static/v1?label=by&message=Alura&color=blue&style=for-the-badge"> <img src="https://img.shields.io/static/v1?label=Tech&message=.NET 6.0&color=7B68EE&style=for-the-badge&logo=.NET"> <img src="https://img.shields.io/static/v1?label=Tech&message=C%23&color=7B68EE&style=for-the-badge&logo=csharp">

## O sistema
O projeto se trata de um CRUD em C# utilizando diversas coleções disponibilizadas pelo sistema .NET. O tema do projeto é um atendimento ao cliente em um banco, BiteBank, onde pode-se fazer a criação e manipulação de contas correntes com as informações pessoais dos clientes.

![Menu de atendimento](https://user-images.githubusercontent.com/98191980/198300688-1349de07-3075-4dd4-a81c-30561a2384ec.png)

### Funcionalidades e características
- O programa inicia com 3 contas correntes por default;
- Possui um menu interativo para decidir as opções de atendimento;
- É possível fazer 3 tipos diferentes de pesquisas por contas: por número da conta, por cpf do titular e pelo o número da agência. No projeto constam 3 formas diferentes de mótodos de consulta: 2 métodos por LINQ (Language Integrated Query), sendo eles por métodos de consulta (semelhante a SQL) e pelos próprios métodos LINQ (por expressão lambda), e por fim o método de iteração de lista (for, foreach);
- Apresenta a opção de listar as contas existentes, feita através do método ToString() das contas correntes;
- Ordena as contas criadas através do método Sort() na lista de contas - que para ser implementado foi necessário transformar os objetos da lista (contas correntes) em uma interface comparável, IComparable<>;
- Remove contas por métodos de List<>;
- Lista contas por ToString() de conta corrente;
- Tratamento de excessão personalizado para casos de inputs inválidas (não numéricas ou fora do escopo);
- Por fim, cadastra contas com números únicos a partir da coleção GUID;



## Resumo das aulas

### Array
- O que são arrays e como esta estrutura de dados é útil para agruparmos em uma única referência vários valores de determinado tipo;
- As sintaxes básicas de definição e inicialização de um array usando C#, entendendo as formas mais utilizadas e simples, que podem conferir dinamismo ao se trabalhar com arrays;
- A percorrer um array a fim de manipulá-lo para inserção de valores em seus índices e também para recuperar uma informação armazenada em determinada posição do array;
- Sobre a classe Array, que é a superclasse da qual todos os arrays de C# herdam seus atributos e propriedades.

### Array de contas correntes
- A utilizar a encapsular a manipulação de um array de objetos em um classe a fim de facilitar a manutenção de uma estrutura de objetos;
- Como utilizar um indexador, que permite que uma classe desenvolvida por você possa ser indexada como um array;
- A utilizar a collection ArrayList, uma classe que permite trabalhar com coleções de objetos e já implementa uma série de métodos para manipulação de um array de objetos.

### ListT

- A utilizar uma lista genérica de objetos utilizando a classe List, que permite a tipagem de uma lista de objetos e que permite a redução da probabilidade de erros de conversão para a manipulação da lista;
- Sobre métodos disponíveis pela classe List que dinamiza a manipulação de lista de objetos;
- A criar uma classe para tratar as excessões da aplicação e que se faz necessária uma vez que a aplicação em desenvolivmento tem uma interface de interação com o usuário;

### Manipulando a lista

- Sobre a interface IComparable, que deve ser implementada pelo tipo de classe que irá tipificar uma lista genérica para usarmos o método Sort;
- Como utilizar o método Remove da classe lista para remoção de um elemento do array de objetos;
- Como implementar a interface da forma tipada IComparable e o método CompareTo para fazer a ordenação da lista de contas correntes;
- A criar um algoritmo de busca simples para encontrar um objeto no array de contas correntes;

### LINQ

- A utilizar o método de extensão Where aplicado diretamente a lista de objetos, que permite a simplificação da busca de um elemento na lista;
- Sobre a configuração no arquivo .Csproj que configura o projeto ´para alertar sobre operações que podem retornar um valor nulo para um objeto;
- A usar a sintaxe de consulta do LINQ que torna o código bem legível e de fácil entendimento;
- Como utilizar a estrutura Guid do C# para gerar uma sequência alfanumérica de forma aleatória no sistema;
