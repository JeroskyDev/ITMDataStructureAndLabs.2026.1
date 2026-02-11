//lets do an app that calculates the basic payroll of a employee
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //get employees name
    var employeeName = ConsoleExtension.GetString("Ingrese su nombre..........................: ");
    var hoursWorked = ConsoleExtension.GetFloat("Ingrese cantidad de horas trabajadas.......: ");
    var hourWage = ConsoleExtension.GetDecimal("Ingrese valor del salario por hora.........: ");
    var minimumMonthly = ConsoleExtension.GetDecimal("Ingrese valor del salario mínimo mensual...: ");

    var monthlyWage = (decimal)hoursWorked * hourWage;
    
    //if monthly wage is more than the minimum wage monthly, then print the employees name and wage, else, just print his name.
    //NOTE: use decimal data type for money
    if (monthlyWage < minimumMonthly)
    {
        Console.WriteLine($"Nombre del empleado........................: {employeeName}");
        Console.WriteLine($"Salario Minimo Mensual.....................: {minimumMonthly:C2}"); //C2 = currency format
    } 
    else
    {
        Console.WriteLine($"Nombre del empleado........................: {employeeName}");
        Console.WriteLine($"Salario Mensual............................: {monthlyWage:C2}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar? [S]i, [N]o: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");