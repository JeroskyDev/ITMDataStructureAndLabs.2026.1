//console application for euler number calculation

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("¿Cuántos números de precisión desea?: ");
    var euler = EulerCalculation(n);

    Console.WriteLine($"e = {euler,20}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double EulerCalculation(int n)
{
    double euler = 0;
    for (int i = 0; i < n; i++)
    {
        euler += 1 / MyMath.Factorial(i);
    }
    return euler;
}

Console.WriteLine("Gracias por usar el programa! Game over :)");