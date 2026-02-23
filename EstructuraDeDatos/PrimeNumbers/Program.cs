//Program for prime numbers show, summation and average calculation
using Shared;
using System.IO.Pipelines;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("¿Cuántos números primos desea?: ");
    var primes = GetPrimes(n); //use a function that will return a table of prime numbers
    //use a for each (for i, v, in primes, but in C# instead of roblox)
    foreach (var prime in primes)
    {
        Console.Write($"{prime,10:N0}");
    }
    Console.WriteLine("");

    //calculate summation and average with .Sum() and .Average()
    Console.WriteLine($"La sumatoria de los números primos es: {primes.Sum(),10:N0}");
    Console.WriteLine($"El promedio de los números primos es: {primes.Average(),10:N0}");

    Console.WriteLine("");
    //this logic is wack so we will use a function that returns a list of prime numbers
    /*
    var summation = 0;

    var isItPrime = MyMath.IsPrime(n); 

    for (int i = 0; i < n; i++)
    {
        if (isItPrime == true)
        {
            Console.WriteLine($"{n,10:N0}");
            summation += n;
        }
    }
    var average = summation / n;
    Console.WriteLine($"La suma de todos los números primos hasta {n} es: {summation}");
    Console.WriteLine($"El promedio de todos los números primos hasta {n} es: {average}");
    */

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

List<int> GetPrimes(int n)
{
    var primes = new List<int>();
    var num = 2;

    //lets use a while loop for this we don´t need a for loop, with a while we can access a list property called .Count to have all the objects.
    //lets add prime numbers while the primes object count is less than the amount of prime numbers we want.
    while (primes.Count < n)
    {
        if (MyMath.IsPrime(num))
        {
            primes.Add(num); // .Add() is a method for adding data to a table
        }
        num++;
    }
    return primes;
}

Console.WriteLine("Gracias por usar el programa! Game over :)");
