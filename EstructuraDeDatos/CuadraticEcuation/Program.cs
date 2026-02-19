//Program for cuadratic ecuation calculator

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetDouble("Ingrese valor para a: ");
    var b = ConsoleExtension.GetDouble("Ingrese valor para b: ");
    var c = ConsoleExtension.GetDouble("Ingrese valor para c: ");

    var solution = CuadraticEcuation(a, b, c);
    
    Console.WriteLine($"x1 = {solution.x1:N5}");
    Console.WriteLine($"x2 = {solution.x2:N5}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game Over :)");

//instead of creating a singular class, we will create a solution that will return x1 and x2 values.
CuadraticEquationSolution CuadraticEcuation(double a, double b, double c)
{
    return new CuadraticEquationSolution
    {
        x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
        x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
    };
}

public class CuadraticEquationSolution
{
    public double x1 { get; set; }
    public double x2 { get; set; }
}




