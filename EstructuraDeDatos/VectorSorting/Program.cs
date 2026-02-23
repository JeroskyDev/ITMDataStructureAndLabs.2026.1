using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //blueprint (data input)
    Console.Clear();
    Console.WriteLine("*** ORDENACIÓN ESPECIAL DEL VECTOR ***");

    //processes
    var positions = ConsoleExtension.GetInt("¿Cuántas posiciones desea?: ");
    var vectorArray = new int[positions];
    FillArray(vectorArray);

    //show result
    Console.WriteLine("SIN ORDENAR");
    ShowArray(vectorArray);
    OrderArray(vectorArray);

    Console.WriteLine($"\nORDENADO");
    ShowArray(vectorArray);

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");

void OrderArray(int[] vectorArray) //bubble sort algorithm
{
    for (int i = 0; i < vectorArray.Length - 1; i++)
    {
        for (int j = i + 1; j < vectorArray.Length; j++)
        {
            if (vectorArray[i] > vectorArray[j]) // if (<) it orders descendantly, and if (>) it orders ascendently
            {
                //change the numbers with an auxiliar variable
                //this can be done in a separated method too.
                int aux = vectorArray[i];
                vectorArray[i] = vectorArray[j];
                vectorArray[j] = aux;
            }
            else
            {

            }
        }
    }
}

void ShowArray(int[] vectorArray)
{
    foreach (var number in vectorArray)
    {
        Console.Write($"vec = {number:N0}\n");
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
