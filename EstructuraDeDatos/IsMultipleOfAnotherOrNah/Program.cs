//This program will see if a number inpputted by the user can be multipliable by another number that the user will input
var aString = string.Empty;
var bString = string.Empty;

do
{

    Console.WriteLine("Ingrese el primer número");
    aString = Console.ReadLine();
    var aInt = 0;
    if (int.TryParse(aString, out aInt))
    {
        aInt = int.Parse(aString!);
    }
    else
    {
        Console.WriteLine($"{aString} NO es un número, intente de nuevo");
        return;
    }

    Console.WriteLine("Ingrese el segundo número");
    bString = Console.ReadLine();
    var bInt = 0;
    if (int.TryParse(bString, out bInt))
    {
        bInt = int.Parse(bString!);
    }
    else
    {
        Console.WriteLine($"{bString} NO es un número, intente de nuevo");
        return;
    }

    //we use module again, if aInt divided by bInt, it´s residue is 0, then aInt is a multiple of bInt
    if (bInt % aInt == 0)
    {
        Console.WriteLine($"{aInt} es un múltiplo de {bInt}");
    } 
    else
    {
        Console.WriteLine($"{aInt} NO es múltiplo de {bInt}");
    }
} while (true);