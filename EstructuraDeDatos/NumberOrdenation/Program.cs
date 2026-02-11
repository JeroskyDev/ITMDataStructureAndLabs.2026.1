//This program will sort three numbers the user will input, from greatest to lowest.
using Shared;

//DO NOT USE ANYMORE, WE HAVE THE SHARED CLASS----------------------------------
//var aString = string.Empty;
//var bString = string.Empty;
//var cString = string.Empty;
//DO NOT USE ANYMORE, WE HAVE THE SHARED CLASS----------------------------------

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("Ingrese 3 números DIFERENTES...");
    var a = ConsoleExtension.GetInt("Ingrese el primer número... ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo número... ");

    //verify if numbers are equal so it wont make the loop
    if (a == b)
    {
        Console.WriteLine("Deben ser números diferentes, por favor vuelva a empezar...");
        continue;
    }

    var c = ConsoleExtension.GetInt("Ingrese el tercer número... ");

    //verify if numbers are equal so it wont make the loop
    if (b == c || c == a)
    {
        Console.WriteLine("Deben ser números diferentes, por favor vuelva a empezar...");
        continue;
    }

    //use if conditionals but nested, so we can sort the numbers from greatest to lowest
    //if aInt is the greatest
    if (a > b && a > c)
    {
        //then b is the mid number
        if (b > c)
        {
            Console.WriteLine($"El mayor número es: {a}");
            Console.WriteLine($"El número del medio es: {b}");
            Console.WriteLine($"El menor número es: {c}");
        }
        else  //c is the mid number
        {
            Console.WriteLine($"El mayor número es: {a}");
            Console.WriteLine($"El número del medio es: {c}");
            Console.WriteLine($"El menor número es: {b}");
        }
    } 
    else if (b > a && b > c) //b is the greatest number
    {
        if (a > c) //a is the mid number
        {
            Console.WriteLine($"El mayor número es: {b}");
            Console.WriteLine($"El número del medio es: {a}");
            Console.WriteLine($"El menor número es: {c}");
        }
        else //c is the mid number
        {
            Console.WriteLine($"El mayor número es: {b}");
            Console.WriteLine($"El número del medio es: {c}");
            Console.WriteLine($"El menor número es: {a}");
        }
    }
    else //c is the greatest number
    {
        if (a > b) //a is the mid number
        {
            Console.WriteLine($"El mayor número es: {c}");
            Console.WriteLine($"El número del medio es: {a}");
            Console.WriteLine($"El menor número es: {b}");
        }
        else //b is the mid number
        {
            Console.WriteLine($"El mayor número es: {c}");
            Console.WriteLine($"El número del medio es: {b}");
            Console.WriteLine($"El menor número es: {a}");
        }
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar? [S]i, [N]o: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");