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

2. [Movimento do bot](./bot)

3. [Palíndromo](./palindromo)

4. [Supermercado](./supermercado)

5. [GPS](./gps)

</p>

## Clonar repositório
```git clone https://github.com/leovictorcvo/fit.git```

## Execução
Após clonar o repositório, os projetos poderão ser inicializados da seguinte forma utilizando o terminal de comando:

> ### Primo, Bot, Palindromo e GPS

<p> Esses são projetos do tipo console desenvolvidos utilizando o .Net 6.0. Para executar basta entrar na pasta do projeto desejado e executar 

```dotnet run```

</p>

> ### Supermercado
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