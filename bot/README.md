# BOT

Existe um bot localizado em um par de coordenadas inteiras, (x, y). Ele pode ser movido para um outro par de coordenadas. Embora o bot possa se mover quantas vezes quiser, ele só pode fazer os dois tipos de movimentos a seguir:
1.	Da posição (x, y) para a posição (x + y, y).
2.	Da posição (x, y) para a posição (x, x + y).

Por exemplo, se o bot começa em (1, 1), ele pode fazer a seguinte sequência de movimentos: (1, 1) → (1, 2) → (3, 2) → (5, 2). Observe que o movimento sempre será para cima ou para a direita

Escreva uma função que, dadas as coordenadas iniciais e finais, determine se o bot pode alcançar as coordenadas finais de acordo com as regras de movimento.

### Descrição da função:

A função deve retornar true se o bot puder atingir seu objetivo, caso contrário, retorne false.

A função tem o(s) seguinte(s) parâmetro(s):

- x1: valor inteiro, coordenada x inicial
- y1: valor inteiro, coordenada y inicial
- x2: valor inteiro, coordenada x final
- y2: valor inteiro, coordenada y final
