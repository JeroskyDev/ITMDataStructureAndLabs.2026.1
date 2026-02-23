//console app that creates a vector of N positions, fills every cell with random numbers, then shows the summation of the cells with even values, and then the average of the cells with odd values.
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //blueprint
    Console.Clear();
    Console.WriteLine("*** PARES E IMPARES EN UN ARREGLO ***");

    var positions = ConsoleExtension.GetInt("¿Cuántas posiciones desea?: ");
    var vectorArray = new int[positions]; 
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");
