//Program for prime numbers show, summation and average calculation
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("¿Cuántos: ");

    var isItPrime = MyMath.IsPrime(n); //do a function for prime number validation

    for (int i = 0; i < n; i++)
    {


    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game over :)");
