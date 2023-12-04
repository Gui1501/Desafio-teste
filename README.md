# Teste .NET C# Junior

## Mttechne Soluções

## Lista de Produtos

A solução proposta é um sistema de produtos de informática. Foi implementado um método que gera uma lista de produtos disponíveis, dispensando a necessidade de conexão com banco de dados num primeiro momento. Sua tarefa é implementar métodos complementares a esse, conforme as regras a seguir.

### Busca a listagem de produtos a partir de um nome

Aproveite o método já implementado de busca e faça as validações necessárias para que o sistema se mantenha íntegro, caso o usuário tente forçar uma busca sem informar um nome, ou qualquer outro cenário que você julgar necessário. Implemente também uma validação para que sejam retornados registros dos quais os nomes contenham o valor informado, independente de acentuação e letras maiúculas e minúsculas, ou o texto não seja informado por completo.

### Busca ordenada por valor

Crie um método que retorne a listagem dos produtos por ordem de valor crescente e descrescente.

### Busca por faixa de preço

Crie um método que retorne a listagem dos produtos dos quais o valor esteja entre dois valores informados pelo usuário.

### Busca por valores máximos e mínimos

Crie um método que retorne apenas os valores máximos de cada produto, desconsiderando os que tenham o mesmo nome e valor menor, e um método que faça o contrário, trazendo apenas os produtos de menor valor.

### Crie testes unitários para todos os casos mencionados acima

# Teste .NET C# Pleno

### Integração com banco de dados

Deverão ser implementadas todas as exigencias acima, porém integrando um banco de dados de escolha do candidato. As implementações deverão ser feitas com o Entity Framework. Todas as entidades deverão ter suas migrations salvas em uma pasta junto dos repositórios.

## Considerações finais

Todas as interações do usuário serão feitas via Swagger, portanto as entradas e saídas de informações serão através da API, sem uso de console.
Clone esse repositório e crie uma branch com seu nome, no fim do teste crie um pull request para a branch 'develop'.
