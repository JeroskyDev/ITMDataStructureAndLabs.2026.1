//year calendar calculation
//for leap year calculation lets create a new class because it is reusable
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //blueprint
    Console.Clear();
    Console.WriteLine("*** CALENDARIO CUALQUIER AÑO ***");

    //get year
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    //lets do a method for all of the calendar calculation
    ShowCalendar(year);

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game Over :)");

void ShowCalendar(int year)
{
    Console.WriteLine($"*** Año: {year} ***");
    //for loop for months
    for (var month = 1; month <= 12; month++)
    {
        Console.WriteLine($"\n\nMes: {month}");

        //for day weeks
        Console.WriteLine($"Dom\tLun\tMar\tMie\tJue\tVie\tSáb\n");

        //for days in a month
        var daysPerMonth = GetDaysPerMonth(year, month);

        //zeller method calc
        var zeller = Zeller(year, month);

        var daysCounter = 0; //so we can make \n every 7 days and it looks good

        //for loop to calculate the amount of spaces with zeller calculations
        for (int i = 0; i < zeller; i++)
        {
            //just print tabulators for every space
            Console.Write("\t");
            daysCounter++; //increment days counter (because the space are like if we had incremented by one day, this so the counter doesn´t reset and, for example, if a month ended on wednesday, then it doesn´t go back to monday and it starts at thursday).
        }

        for (var day = 1; day <= daysPerMonth; day++)
        {
            Console.Write($"{day}\t");
            daysCounter++;
            if (daysCounter == 7)
            {
                daysCounter = 0; //initialize again so it counts back again to 7
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}

int GetDaysPerMonth(int year, int month)
{
    //if its february (the special month case) and its a leap year, then the years will be 29
    if (month == 2 && DateUtilities.IsLeapYear(year))
    {
        return 29;
    }

    //create a list for every month day quantity
    //the indexing always starts at 0 so we add a 0 first to bypass the 0 iteration, so we can start with 1 as January
    List<int> daysPerMonth = [0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    return daysPerMonth.ElementAt(month); //ElementAt serves for index localization with another for loop we might have.
}

//method for seeing in which day did the year start and when did every month started, called Zeller Congruence
//returns:  
// 0 = Sunday, 1 = Monday, 2 = Tuesday, 3 = Wednesday,  
// 4 = Thursday, 5 = Friday, 6 = Saturday
//these numbers are the amount of spaces we will put for each month 
int Zeller(int ano, int mes)
{
    int a = (14 - mes) / 12;
    int y = ano - a;
    int m = mes + 12 * a - 2;
    int dia = 1, d;

    d = (dia + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;

    return (d);
}