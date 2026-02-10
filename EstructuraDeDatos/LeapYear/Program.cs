using Shared;

//This app will calculate if a year is a leap year

//A leap year is a year that it´s a number that is a multiple of 4, 100 and 400
//if it is just a multiple of 4, then it could be a leap year too
//if it isn´t a multiple of 4, then it isn´t a leap year
//is it is a multiple of 4 and 100 only, then it isn´t a leap year

do
{
    //let´s get the current year to make the program even better and if we ask for a year in the past then it says "fue/no fue bisiesto" but in the present it says "fue bisiesto"
    var currentYear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese año... ");

    //if the user inputs the current year, then say "es" (because is in the present) and we put it on the message empty string so we can use it properly in the leap year calculation conditionals
    if (year == currentYear)
    {
        message = "es";
    }
    else if (year > currentYear)
    {
        message = "va a ser";
    }
    else
    {
        message = "fue";
    }

    //if it´s a multiple of 4 then look if it´s multiple of a 100 and if it is, then it isnt a leap year
    if (year % 4 == 0)
    {
        //with just multiple of 4 it could probably be a leap year
        //if it´s a multiple of 4 and of 100 then it isnt a leap year
        if (year % 100 == 0)
        {
            //if it is a multiple of 400, then it checks all the conditions and the year is definetely a leap year.
            if (year % 400 == 0)
            {
                Console.WriteLine($"El año {year} SI {message} un año bisiesto.");
            }
            else //is not a leap year because it doesn´t check all of the conditions.
            {
                Console.WriteLine($"El año {year} NO {message} un año bisiesto.");
            }
        }
        else // it is a leap year if it´s just a multiple of 4 then
        {
            Console.WriteLine($"El año {year} SI {message} un año bisiesto.");
        }
    }
    else //it is NOT a leap year
    {
        Console.WriteLine($"El año {year} NO {message} un año bisiesto.");
    }
} while (true);
