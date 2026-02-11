//This program will see if a number inpputted by the user can be multipliable by another number that the user will input
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetInt("Ingrese el primer número... ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo número... ");

    //we use module again, if aInt divided by bInt, it´s residue is 0, then aInt is a multiple of bInt
    if (a % b == 0)
    {
        Console.WriteLine($"{a} es un múltiplo de {b}");
    } 
    else
    {
        Console.WriteLine($"{a} NO es múltiplo de {b}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar? [S]i, [N]o: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");
