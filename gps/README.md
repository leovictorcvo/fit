# GPS

Você é um desenvolvedor responsável pela manutenção de um software GPS famoso no mercado. Você recebeu a tarefa de calcular a melhor rota possível entre duas cidades distintas.

Para simplificar o desenvolvimento de software, considere o seguinte:

- cada cidade será nomeada com apenas 1 letra minúscula (de a a z); 

- cada estrada liga duas cidades, e o tráfego pode ir em ambas as direções; 
    - exemplo: em uma estrada que liga as cidades aez, o tráfego pode ir de a a z e vice-versa;
>
- para cada estrada, será fornecido um número inteiro t representando o tempo necessário para o veículo atual viajar toda a estrada, em horas; 

- cidades nomeadas com uma vogal (a, e, i, o ou u), estão atualmente com tráfego intenso de saída - isso causará um atraso de 5 horas na saída da cidade

Dada uma lista de cidades, todas as estradas que as conectam, uma cidade de partida e, finalmente, a cidade de destino, seu programa precisa produzir o tempo mínimo necessário para a viagem.
>
## Entrada

A entrada começa com uma linha contendo um inteiro T indicando o número de casos de teste. Para cada caso de teste, a entrada acontecerá da seguinte forma: 

- uma linha contendo um inteiro C, indicando o número de cidades; 

- uma linha contendo os nomes de todas as cidades, que são nomeadas com uma letra minúscula, separadas por um espaço; 

- uma linha contendo um inteiro R, indicando o número de estradas; 

- R linhas, cada uma contendo os seguintes dados, separados por um espaço: 
    - uma letra minúscula representando uma cidade, em uma das pontas da estrada; uma letra minúscula representando a cidade do outro lado da estrada; 

    - um número inteiro t representando o tempo, em horas, necessário para percorrer toda a estrada (independentemente de a direção do tráfego); 

- Finalmente, a última linha de um caso de teste conterá duas letras minúsculas, separadas por um espaço, indicando uma cidade de partida e uma cidade de destino.

## Resultado 

Um inteiro M indicando o tempo mínimo necessário para viajar da cidade de partida à cidade de destino.

## Exemplo

### Entrada

3 

4 

z a b c 

4

z a 1

z b 2

a c 2

b c 1

z c

4 

z a b c

4 

z a 1

z b 2

a c 2

b c 1

z a

4

z a b c

4 

z a 1 

z b 2

a c 2

b c 1

z b

### Saída

3

1

2
