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
    var vectorArray = new int[positions]; //we use the reserved word new for array creation, then, define it as a just integers array, and inside of the squared brackets, we put the number the user inputed for the array´s length

    //create a subprogram for array filling
    FillArray(vectorArray);
    var sum = GetSumEven(vectorArray); //do the summation in a separate method
    var prod = GetProdOdd(vectorArray); // do the productory in a separate method

    //run results
    //we create a method for array showing
    ShowArray(vectorArray);
    Console.WriteLine($"La sumatoria es: {sum:N0}");
    Console.WriteLine($"La sumatoria es: {prod:N0}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");

double GetProdOdd(int[] vectorArray) //define it as double because sometimes long numbers might bug and give negative values when every other number was positive
{
    double prod = 1;
    foreach (var num in vectorArray)
    {
        if (num % 2 != 0)
        {
            prod *= num;
        }
    }
    return prod;
}

int GetSumEven(int[] vectorArray)
{
    var sum = 0;
    foreach (var num in vectorArray)
    {
        if (num % 2 == 0)
        {
            sum += num;
        }
    }
    return sum;
}

void ShowArray(int[] vectorArray)
{
    foreach (var number in vectorArray)
    {
        Console.Write($"\tvecIndexUndefined = {number:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] vectorArray)
{
    var random = new Random(); //this variable creates random numbers, with the pre-built C# Random() method
    for (int i = 0; i < vectorArray.Length; i++) //vectorArray.Length returns the array size based in the number of elements it has
    {
        //iterate through every index of the array and define the value with the random number
        vectorArray[i] = random.Next(0, 100); //is like luau´s math.random(n, m) but in C# :D
    }
}