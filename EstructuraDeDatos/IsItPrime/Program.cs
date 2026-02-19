//Program for Fibonacci sequence summation

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Ingrese un número: ");

    var isItPrime = MyMath.IsPrime(n); //do a function for prime number validation
    
    if(isItPrime == true)
    {
        Console.WriteLine($"{n}, SI es un número primo.");
    }
    else
    {
        Console.WriteLine($"{n}, NO es un número primo.");
    }
        
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game over :)");

//we will put this method in the MyMath class because we will need it for the next exercise.
/*
bool IsPrime(int n)
{
    for (int i = 2; i < Math.Sqrt(n); i++) //use the square root so we can divide n by every number that is less than n
    {
        if (n % i == 0) //and if there is no residue, then it isn´t a prime number.
        {
            return false;
        }
    }
    return true; //if it passes all divisions, then it is a prime number.
}
*/