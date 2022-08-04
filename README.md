<h1 align="center">

  [FIT](https://fit-tecnologia.org.br/home)

</h1>
<h2 align="center">
Teste de Lógica & Linguagem de programação (C#)
</h2>
<hr>

## Sobre o desafio

<p>
O teste consiste no desenvolvimento dos 5 projetos abaixo
</p>
<p>

1. [Número primo](./primo)
>Um número primo é aquele que é divisível apenas por um e por ele mesmo. 
>Obs: O número 1 não é primo.
>
>Escreva uma função otimizada que, dado um número inteiro positivo, retorne true se o número for primo ou false caso contrário, com o menor número de iterações possível.
>
>Imprima o resultado em tela da seguinte forma: 
>“O número num é primo. Número de iterações necessárias: count”
>ou
>“O número num não é primo. Número de iterações necessárias: count”

2. [Movimento do bot](./bot)
>Existe um bot localizado em um par de coordenadas inteiras, (x, y). Ele pode ser movido para um outro par de coordenadas. Embora o bot possa se mover quantas vezes quiser, ele só pode fazer os dois tipos de movimentos a seguir:
>1.	Da posição (x, y) para a posição (x + y, y).
>2.	Da posição (x, y) para a posição (x, x + y).
>
>Por exemplo, se o bot começa em (1, 1), ele pode fazer a seguinte sequência de movimentos: (1, 1) → (1, 2) → (3, 2) → (5, 2). Observe que o movimento sempre será para cima ou para a direita
>
>Escreva uma função que, dadas as coordenadas iniciais e finais, determine se o bot pode alcançar as coordenadas finais de acordo com as regras de movimento.
>
>Descrição da função:
>A função deve retornar true se o bot puder atingir seu objetivo, caso contrário, retorne false.
>
>A função tem o(s) seguinte(s) parâmetro(s):
>
>  x1: valor inteiro, coordenada x inicial
>
>  y1: valor inteiro, coordenada y inicial
>
>  x2: valor inteiro, coordenada x final
>
>  y2: valor inteiro, coordenada y final

3. [Palíndromo](./palindromo)
>Palíndromo, do grego palin (novo) e dromo (percurso), é toda palavra ou frase que quando lida ao contrário, desconsiderando espaços e pontuações, possui o mesmo sentido. Ex.: “asa”, “ovo”, “A base do teto desaba”. 
>
>Escreva uma função que receba uma string como parâmetro e retorne true caso o valor dessa string seja um palíndromo ou false, caso contrário. Importante: Não utilizar funções, bibliotecas e métodos pré definidos para resolução do problema.

4. [Supermercado](./supermercado)
>O supermercado Baixo Preço teve uma queda muito grande em suas vendas na pandemia e precisou aderir a outros métodos para se reerguer, e pensaram na criação de um e-Commerce com seus produtos. Você foi contratado por eles para desenvolver uma SPA (Single Page Application) em Angular 2+ para resolver esse problema

5. [GPS](./gps)

</p>

## Clonar repositório
```git clone https://github.com/leovictorcvo/fit.git```

## Execução
Após clonar o repositório, os projetos poderão ser inicializados da seguinte forma utilizando o terminal de comando:

### Primo, Bot, Palindromo e GPS

<p> Esses são projetos do tipo console desenvolvidos utilizando o .Net 6.0. Para executar basta entrar na pasta do projeto desejado e executar 

```dotnet run```

</p>

### Supermercado
Esse projeto está dividido em duas partes: Backend (desenvolvido utilizando .Net 3.1) e o Frontend (Angular 13).

#### Backend
1. Com base na pasta raiz do projeto, alterar para o diretório do Desafio.API<br>
 ```cd .\backend\Backend\```
2. Iniciar a api utilizando o comando dotnet<br>
```dotnet run --urls=https://localhost:44317```<br><br>

#### Frontend
1. Com base na pasta raiz do projeto, alterar para o diretório do projeto do frontend<br>
 ```cd .\frontend```
2. Antes de executar o projeto, deve ser feito o download das dependências utilizando o npm<br>
```npm i```
3. Iniciar utilizando o comando abaixo<br>
```ng serve -o```<br><br>
Após esse comando a janela do navegador deve abrir e apresentar a tela do projeto. Caso não abra, basta abrir um browser e navegar para a página **http://localhost:4200/**

<hr>