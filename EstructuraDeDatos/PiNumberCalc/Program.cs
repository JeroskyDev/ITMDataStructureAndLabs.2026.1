//Program for pi number calculation using precision numbers

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("¿Cuántos términos de precisión desea para el número pi?: ");
    var pi = PiCalc(n);

    Console.WriteLine($"pi = {pi,25}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double PiCalc(int n)
{
    double sum = 0;
    double denominator = 1; //to increment 2 by 2
    int sign = 1;
    for (int i = 0; i < n; i++)
    {
        double term = 1 / denominator * sign; //multiply by the sign, so the sign of the term changes
        sum += term;
        denominator += 2; //as seen in the formula, increment 2 by 2
        sign *= -1; //make sign negative so it can be negative in the next term calculation
    }
    return sum * 4;
}

Console.WriteLine("Gracias por usar el programa! Game Over :)");