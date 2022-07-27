using System.Text.RegularExpressions;

Console.Clear();
Console.WriteLine("Palíndromo");
Console.WriteLine();

(string frase, bool removeAcentos) parametros = LerDadosUsuario();
string afirmacao = verificaSePalindromo(parametros.frase, parametros.removeAcentos) ? "" : " não";
Console.WriteLine($"A frase '{parametros.frase}'{afirmacao} é um palíndromo.");

static (string frase, bool removeAcentos) LerDadosUsuario()
{
    string? frase = "";

    do {
        Console.Write("Informe uma frase para verificar se ela é palíndromo:");
        frase = Console.ReadLine();
    } while(string.IsNullOrEmpty(frase?.Trim()));
    
    Console.Write("Desconsidera os acentos? (S/n):");
    string? consideraAcentos = Console.ReadLine();
    bool removeAcentos = string.IsNullOrEmpty(consideraAcentos?.Trim()) || consideraAcentos.ToLower().Trim() == "s";
    return (frase, removeAcentos);
}

static bool verificaSePalindromo(string frase, bool removeAcentos)
{
    string fraseLimpa = LimpaFrase(frase, removeAcentos);
    bool resultado = true;

    for (int i = 0, j = fraseLimpa.Length - 1; i < j; i++, j--)
    {
        if (!char.ToLower(fraseLimpa[i]).Equals(char.ToLower(fraseLimpa[j])))
        {
            resultado = false;
            break;
        }
    }

    return resultado;
}

static string LimpaFrase(string frase, bool removeAcentos)
{
    string minusculo = frase.ToLower();
    var rgx = new Regex(@"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç]");
    string resultado = rgx.Replace(minusculo, "");
    if (removeAcentos)
    {
        return RemoverAcentos(resultado);
    }

    return resultado;
}

static string RemoverAcentos(string frase)
{
    var temporario = new System.Text.StringBuilder(frase);
    new char[] { 'à', 'á', 'â', 'ã' }.Aggregate(temporario, (str, item) => str.Replace(item, 'a'));
    new char[] { 'è', 'é', 'ê' }.Aggregate(temporario, (str, item) => str.Replace(item, 'e'));
    new char[] { 'ì', 'í', 'î' }.Aggregate(temporario, (str, item) => str.Replace(item, 'i'));
    new char[] { 'ò', 'ó', 'ô', 'õ' }.Aggregate(temporario, (str, item) => str.Replace(item, 'o'));
    new char[] { 'ù', 'ú', 'û' }.Aggregate(temporario, (str, item) => str.Replace(item, 'u'));
    temporario.Replace('ç', 'c');
    return temporario.ToString();
}
