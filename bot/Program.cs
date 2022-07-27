Console.Clear();
Console.WriteLine("Palíndromo");
Console.WriteLine();

int x1 = LerCoordenada("Informe a coordenada X inicial: ");
int y1 = LerCoordenada("Informe a coordenada Y inicial: ");
int x2 = LerCoordenada("Informe a coordenada X final: ");
int y2 = LerCoordenada("Informe a coordenada Y final: ");

string afirmacao = PodeSerAlcancado(x1, y1, x2, y2) ? "" : " não";

Console.WriteLine($"({x2}, {y2}){afirmacao} pode ser alcançado partindo de ({x1}, {y1})");

static int LerCoordenada(string titulo)
{
    bool coordenadaValida = false;
    int coordenada = -1;

    while (!coordenadaValida)
    {
        Console.Write(titulo);
        coordenadaValida = int.TryParse(Console.ReadLine(), out coordenada);
        coordenadaValida = coordenadaValida && coordenada >= 0;
        if (!coordenadaValida)
        {
            Console.WriteLine($"Valor inválido");
        }
    }

    return coordenada;
}

static bool PodeSerAlcancadoRecursivo(int x1, int y1, int x2, int y2)
{
    //Apesar de ser mais elegante, pode gerar erro de stackOverflow para uma coordenada com maior valor
    if (x1 == x2 && y1 == y2) return true;

    if (x1 > x2 || y1 > y2) return false;

    if (PodeSerAlcancado(x1 + y1, y1, x2, y2)) return true;

    if (PodeSerAlcancado(x1, x1 + y1, x2, y2)) return true;

    return false;
}

static bool PodeSerAlcancado(int x1, int y1, int x2, int y2)
{
    while ((x2 > x1 || y2 > y1) && x2 > 0 && y2 > 0) { //posição atual está a direita e acima do ponto inicial
        if (x2 >= y2 && x2 > x1) { //Movimento anterior foi (a+b, b)
            x2 -= y2;
        } else { //Movimento anterior foi (a, a+b)
            y2 -= x2;
        }
    }
    return (x1 == x2 && y1 == y2);
}