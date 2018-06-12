# Sobre
---
Biblioteca para consulta de CEP para projetos em C# de maneira simples, rápida e eficiente.

Desenvolvida utilizando o Webservice da [Via Cep](https://viacep.com.br/).

# Dependências
---
[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

# Como usar
---
A biblioteca faz a busca por um número inteiro de 8 digitos e retorna o resultado da busca em cinco diferentes formatos:
1. Json
2. XML
3. Piped
4. Querty
5. Object ([ViaCEPModel](https://github.com/dfdcastro/ViaCEP_CSharp/blob/master/source/ViaCEPLibrary/ViaCEPLibrary/Model/ViaCEPModel.cs))

Chamada com retorno de Json:
```csharp
var result = CEPLibrary.Search.ByZipCode(01001000, CEPLibrary.Types.ViaCEPTypes.Json);
```

Resultado:
```json
{
  "cep": "01001-000",
  "logradouro": "Praça da Sé",
  "complemento": "lado ímpar",
  "bairro": "Sé",
  "localidade": "São Paulo",
  "uf": "SP",
  "unidade": "",
  "ibge": "3550308",
  "gia": "1004"
}
```
