//Make app for looking if a number is odd or not odd
// Console.WriteLine("Escriba un número...");

//Use var for defining variables, and then put the name of whatever your variable will be.
//Instead of .WriteLine for printing things, we use ReadLine(); to wait for user´s input
// var numberString = Console.ReadLine();

/*
 * Note: WriteLine(); is for printing in just one line, so the cursor will be at the next line,
 * after printing. If we want to print and continue in the same line, we just use .Write() function.
 *
 * After executing, we will see that numberString variable is not really a number, is a string, 
 * basically, the the variable number will store it like this: numberString = "45".
 *
 * For stopping this, and making the variable go from string to number, we will create a new
 * variable called numberInt, and we parse it(convert it) using the method .Parse() while 
 * calling the int datatype, inside the parenthesis we put our numberString.
 */

// var numberInt = int.Parse(numberString!); //The exclamation mark works as a promise if the user doesn´t write anything so the code won´t error.

//Use an if statement to evaluate if the number is odd or not, to evaluate this:
/*
 * If a number is divided by 2 and there is residue of that number, then, it is NOT odd, else
 * it is odd.
 */

// if (numberInt % 2 == 0)
// {
//We can upgrade this
//Console.WriteLine("El número es Par!");

/*
 * Let´s use a $ operator and use {} for concatenation
 */
// Console.WriteLine($"El número: {numberInt}, es par!");
// }
// else
// {
// Console.WriteLine($"El número: {numberInt}, es Impar...");
// }

/*
 * To stop from running the app again and again, lets do a cycle with do, so the user can enter
 * whatever numbers he wants, and so he can exit the app whenever he wants, let´s do it too so 
 * if the user says something like "uno/one" the app says "invalid type, try again please." so
 * we can validate the number, and see if it´s written like a word, or the actual number.
*/

//initialize numberString variable here first before doing the cycle, so we can use it as a exit app shortcut
var numberString = string.Empty;

do
{
    Console.WriteLine("Ingrese un número... o ingrese la palabra 'Salir' para salir."); //CTRL + C is used for closing an app proccess. 
    numberString = Console.ReadLine();

    //if the string is "S" or "s", then continue and don´t do the odd validation (so we don´t get any unneccessary messages after we end the app/program
    /*
     * We use the .ToLower() method so in whichever way the user inputs "Salir" with uppercase
     * and lowercase combined, or either one of them, it will always be converted to just "salir"
     * and now the app is really intuitive and interactive
     */
    if (numberString!.ToLower() == "salir")
    {
        continue;
    }
    //var numberInt = int.Parse(numberString!); // this doesn´t work for number validation, we should use the .TryParse() function
    //initialize numberInt
    var numberInt = 0;

    //parse numberString to an integer, and whatever gets parsed, put it in a variable called "numberInt"
    //int.TryParse(numberString, out numberInt);
    /*
     * .TryParse() returns a boolean, true if the number was converted successfully, false if
     * it didn´t got converted, but it doesn´t break the app.
     * 
     * Let´s put the TryParse in an if statement, and if it´s true, then, make the odd number
     * validation.
     */

    if (int.TryParse(numberString, out numberInt))
    {
        if (numberInt % 2 == 0)
        {
            Console.WriteLine($"El número: {numberInt}, es Par!");
        }
        else
        {
            Console.WriteLine($"El número: {numberInt}, es Impar...");
        }
    }
    else
    {
        Console.WriteLine($"Lo que ingresaste: {numberString}, NO es un número entero, intenta de nuevo...");
    }

    
} while (numberString!.ToLower() != "salir"); //while numberString is different than "salir", execute the cycle, if the input is "salir" then exit the program.
Console.WriteLine("Gracias por usar el programa! Game Over :)");