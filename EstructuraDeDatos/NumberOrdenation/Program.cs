//This program will sort three numbers the user will input, from greatest to lowest.
var aString = string.Empty;
var bString = string.Empty;
var cString = string.Empty;

do
{
    Console.WriteLine("Ingrese 3 números DIFERENTES...");
    Console.WriteLine("Ingrese primer número");
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

    //verify if numbers are equal so it wont make the loop
    if (aInt == bInt)
    {
        Console.WriteLine("Deben ser números diferentes, por favor vuelva a empezar...");
        continue;
    }

    Console.WriteLine("Ingrese tercer número");
    cString = Console.ReadLine();
    var cInt = 0;
    if (int.TryParse(cString, out cInt))
    {
        cInt = int.Parse(cString!);
    }
    else
    {
        Console.WriteLine($"{cString} NO es un número, intente de nuevo");
        return;
    }
    
    //verify if numbers are equal so it wont make the loop
    if (bInt == cInt || cInt == aInt)
    {
        Console.WriteLine("Deben ser números diferentes, por favor vuelva a empezar...");
        continue;
    }

    //use if conditionals but nested, so we can sort the numbers from greatest to lowest
    //if aInt is the greatest
    if (aInt > bInt && aInt > cInt)
    {
        //then b is the mid number
        if (bInt > cInt)
        {
            Console.WriteLine($"El mayor número es: {aInt}");
            Console.WriteLine($"El número del medio es: {bInt}");
            Console.WriteLine($"El menor número es: {cInt}");
        }
        else  //c is the mid number
        {
            Console.WriteLine($"El mayor número es: {aInt}");
            Console.WriteLine($"El número del medio es: {cInt}");
            Console.WriteLine($"El menor número es: {bInt}");
        }
    } 
    else if (bInt > aInt && bInt > cInt) //b is the greatest number
    {
        if (aInt > cInt) //a is the mid number
        {
            Console.WriteLine($"El mayor número es: {bInt}");
            Console.WriteLine($"El número del medio es: {aInt}");
            Console.WriteLine($"El menor número es: {cInt}");
        }
        else //c is the mid number
        {
            Console.WriteLine($"El mayor número es: {bInt}");
            Console.WriteLine($"El número del medio es: {cInt}");
            Console.WriteLine($"El menor número es: {aInt}");
        }
    }
    else //c is the greatest number
    {
        if (aInt > bInt) //a is the mid number
        {
            Console.WriteLine($"El mayor número es: {cInt}");
            Console.WriteLine($"El número del medio es: {aInt}");
            Console.WriteLine($"El menor número es: {bInt}");
        }
        else //b is the mid number
        {
            Console.WriteLine($"El mayor número es: {cInt}");
            Console.WriteLine($"El número del medio es: {bInt}");
            Console.WriteLine($"El menor número es: {aInt}");
        }
    }
} while (true);
