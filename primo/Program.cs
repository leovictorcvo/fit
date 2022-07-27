Console.Clear();
Console.WriteLine("Números primos");
Console.WriteLine();

int numero = -1;
do
{
    numero = ObtemNumero();
    if (numero != -1)
    {
        ExibeResultado(VerificaSeNumeroPrimo(numero));
    }
} while (numero != -1);


static int ObtemNumero()
{
    bool numeroOk = false;
    int numero;

    do
    {
        Console.Write("Informe o número positivo para verificar (para sair informe -1): ");
        numeroOk = int.TryParse(Console.ReadLine(), out numero);
        numeroOk = numeroOk && numero >= -1;
    } while (!numeroOk);

    return numero;
}

static (int numero, bool resultado, int interacoes) VerificaSeNumeroPrimo(int numero)
{
    if (numero <= 1) return (numero, false, 1);
    if (numero == 2) return (numero, true, 1);
    if (numero % 2 == 0) return (numero, false, 1);

    //Deve ser verifica os números impares entre 3 e a raiz quadrada do numero informado
    int limite = (int)Math.Floor(Math.Sqrt(numero));
    int interacoes = 1;

    for (int i = 3; i <= limite; i += 2, interacoes++)
        if (numero % i == 0)
            return (numero, false, interacoes);

    return (numero, true, interacoes);
}

static void ExibeResultado((int numero, bool ePrimo, int interacoes) resultado)
{
    string afirmacao = resultado.ePrimo ? "" : " não";
    Console.WriteLine($"O número {resultado.numero}{afirmacao} é primo. Número de iterações necessárias: {resultado.interacoes}");
    Console.WriteLine();
}