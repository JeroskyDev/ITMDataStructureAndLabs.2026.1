/*
Let´s create a program that requests the user for three numbers and then say which is the bigger
one out of all of them, its similar to the is it odd program
*/

Console.WriteLine("=======================================");
Console.WriteLine("PROGRAMA: Número mayor entre 3 números");
Console.WriteLine("=======================================");

do
{
    Console.WriteLine("ingrese la palabra 'numeros' si desea digitar números, o si desea salirse del programa, digite 'salir'...");
    
    numberString = Console.ReadLine();

    //if user wants to get out of the program, then, get out of the loop
    if (numberString!.ToLower() == "salir")
    {
        continue;
    }

    //if the user wants to put numbers, then, make them input the numbers
    if(numberString!.ToLower() == "numeros")
    {
        Console.WriteLine("Ingrese el primer número...");
        aString = Console.ReadLine();
        var aInt = 0;
        if (int.TryParse(aString, out aInt))
        {
            aInt = int.Parse(aString!);
        }
        else
        {
            Console.WriteLine($"{aString} NO es un número, intentalo de nuevo...");
            continue;
        }


        Console.WriteLine("Ingrese el tercer número...");
        cString = Console.ReadLine();
        var cInt = 0;
        if (int.TryParse(cString, out cInt))
        {
            cInt = int.Parse(cString!);
        }
        else
        {
            Console.WriteLine($"{cString} NO es un número, intentalo de nuevo...");
            continue;
        }

        //if aInt is the biggest number
        if (aInt > bInt && aInt > cInt)
        {
            Console.WriteLine($"El número {aInt}, es el mas grande de todos");
        }
        else if (bInt > aInt && bInt > cInt)
        {
            Console.WriteLine($"El número {bInt}, es el mas grande de todos");
        }
        else
        {
            Console.WriteLine($"El número {cInt}, es el mas grande de todos");
        }
    }
} while (numberString!.ToLower() != "salir"); 
Console.WriteLine("Gracias por usar el programa! Game Over :)");