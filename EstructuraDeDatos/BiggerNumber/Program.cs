/*
Let´s create a program that requests the user for three numbers and then say which is the bigger
one out of all of them, its similar to the is it odd program
*/
using Shared;

Console.WriteLine("=======================================");
Console.WriteLine("PROGRAMA: Número mayor entre 3 números");
Console.WriteLine("=======================================");

//DO NOT USE ANYMORE, WE HAVE THE SHARED CLASS----------------------------------
// var numberString = string.Empty;
// var aString = string.Empty;
// var bString = string.Empty;
// var cString = string.Empty;
//DO NOT USE ANYMORE, WE HAVE THE SHARED CLASS----------------------------------

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Console.WriteLine("ingrese la palabra 'numeros' si desea digitar números, o si desea salirse del programa, digite 'salir'...");

    //numberString = Console.ReadLine();

    //if user wants to get out of the program, then, get out of the loop
    //if (numberString!.ToLower() == "salir")
    //{
    //continue;
    //}

    ////DO NOT USE ANYMORE, WE HAVE THE SHARED CLASS----------------------------------
    //if the user wants to put numbers, then, make them input the numbers
    //if(numberString!.ToLower() == "numeros")
    //{
    //Console.WriteLine("Ingrese el primer número...");
    //aString = Console.ReadLine();
    //var aInt = 0;
    //if (int.TryParse(aString, out aInt))
    //{
    //aInt = int.Parse(aString!);
    //}
    //else
    //{
    //Console.WriteLine($"{aString} NO es un número, intentalo de nuevo...");
    //continue;
    //}

    //Console.WriteLine("Ingrese el segundo número...");
    //bString = Console.ReadLine();
    //var bInt = 0;
    //if (int.TryParse(bString, out bInt))
    //{
    //bInt = int.Parse(bString!);
    //}
    //else
    //{
    //Console.WriteLine($"{bString} NO es un número, intentalo de nuevo...");
    //continue;
    //}

    //Console.WriteLine("Ingrese el tercer número...");
    //cString = Console.ReadLine();
    //var cInt = 0;
    //if (int.TryParse(cString, out cInt))
    //{
    //cInt = int.Parse(cString!);
    //}
    //else
    //{
    //Console.WriteLine($"{cString} NO es un número, intentalo de nuevo...");
    //continue;
    //}
    //DO NOT USE ANYMORE, WE HAVE THE SHARED CLASS----------------------------------



    var a = ConsoleExtension.GetInt("Ingrese el primer número... ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo número... ");
    var c = ConsoleExtension.GetInt("Ingrese el tercer número... ");

    //if aInt is the biggest number
    if (a > b && a > c)
    {
        Console.WriteLine($"El número {a}, es el mas grande de todos");
    }
    else if (b > a && b > c)
    {
        Console.WriteLine($"El número {b}, es el mas grande de todos");
    }
    else
    {
        Console.WriteLine($"El número {c}, es el mas grande de todos");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar? [S]i, [N]o: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase)); 
Console.WriteLine("Gracias por usar el programa! Game Over :)");