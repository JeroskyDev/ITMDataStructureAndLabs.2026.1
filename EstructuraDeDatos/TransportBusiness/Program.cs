//Software for driver´s settlement calculation for a transport business by honorary concept.
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");

    var routeOptions = new List<string> { "1", "2", "3", "4" };
    var route = string.Empty;
    do
    {
        route = ConsoleExtension.GetValidOptions("Ingrese Ruta [1], [2], [3], [4]: ", routeOptions);
    } while (!routeOptions.Any(x => x.Equals(route, StringComparison.CurrentCultureIgnoreCase)));

    var trips = ConsoleExtension.GetInt("Ingrese número de viajes: ");
    var passengers = ConsoleExtension.GetInt("Ingrese número de pasajeros total: ");
    var grantsLessThan10Kg = ConsoleExtension.GetDecimal("Ingrese número de encomiendas de menos de 10Kg: ");
    var grantsBetween10KgAndLessThan20Kg = ConsoleExtension.GetDecimal("Ingrese número de encomiendas entre 10Kg y menos de 20Kg: ");
    var grantsMoreThan20Kg = ConsoleExtension.GetDecimal("Ingrese número de encomiendas de más de 20Kg: ");
    Console.WriteLine("*** CALCULOS ***");

    var passengersIncome = CalculatePassengersIncome(route, trips, passengers);
    var grantsIncome = CalculateGrantsIncome(route, grantsLessThan10Kg, grantsBetween10KgAndLessThan20Kg, grantsMoreThan20Kg);

    var totalIncome = passengersIncome + grantsIncome;

    var helperPayment = CalculateHelperPayment(totalIncome);
    var insurancePayment = CalculateInsurancePayment(totalIncome);
    //for fuel calculation we just need the route, and the bus weight that can be calculated with just the passengers (multiplied by 60) and the grants weight
    var fuelPayment = CalculateFuelPayment(route, trips, passengers, grantsLessThan10Kg, grantsBetween10KgAndLessThan20Kg, grantsMoreThan20Kg);

    var totalDeductions = helperPayment + insurancePayment + fuelPayment;

    var totalLiquidation = totalIncome - totalDeductions;

    Console.WriteLine($"Ingresos por Pasajeros: {passengersIncome,20:C2}");
    Console.WriteLine($"Ingresos por Encomiendas: {grantsIncome,20:C2}");
    Console.WriteLine("**************************************************");
    Console.WriteLine($"TOTAL INGRESOS: {totalIncome,20:C2}");
    Console.WriteLine($"Pago al Ayudante: {helperPayment,20:C2}");
    Console.WriteLine($"Pago del Seguro: {insurancePayment,20:C2}");
    Console.WriteLine($"Pago del Combustible: {fuelPayment,20:C2}");
    Console.WriteLine("**************************************************");
    Console.WriteLine($"TOTAL DEDUCCIONES: {totalDeductions,20:C2}");
    Console.WriteLine("**************************************************");
    Console.WriteLine($"TOTAL A LIQUIDAR: {totalLiquidation,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game Over :)");

decimal CalculatePassengersIncome(string? route, decimal trips, decimal passengers)
{
    decimal value = 0;
    decimal tripValue = 0;
    float commision = 0;

    if(route == "1")
    {
        value = 500000m;
        tripValue = value * trips;

        if(passengers < 0)
        {
            throw new ArgumentOutOfRangeException("Tiene que ser mayor el número de pasajeros, intentelo de nuevo.");
        }

        if(passengers <= 50)
        {
            commision = 1.0f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 51 && passengers <= 100)
        {
            commision = 1.05f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 101 && passengers <= 150)
        {
            commision = 1.06f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 151 && passengers <= 200)
        {
            commision = 1.07f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 200)
        {
            commision = 1.07f;
            return (tripValue * (decimal)commision) + (50 * (passengers - 200));
        }

    }

    if (route == "2")
    {
        value = 600000m;
        tripValue = value * trips;

        if (passengers < 0)
        {
            throw new ArgumentOutOfRangeException("Tiene que ser mayor el número de pasajeros, intentelo de nuevo.");
        }

        if (passengers <= 50)
        {
            commision = 1.0f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 51 && passengers <= 100)
        {
            commision = 1.07f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 101 && passengers <= 150)
        {
            commision = 1.08f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 151 && passengers <= 200)
        {
            commision = 1.09f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 200)
        {
            commision = 1.09f;
            return (tripValue * (decimal)commision) + (60 * (passengers - 200));
        }
    }

    if (route == "3")
    {
        value = 800000m;
        tripValue = value * trips;

        if (passengers < 0)
        {
            throw new ArgumentOutOfRangeException("Tiene que ser mayor el número de pasajeros, intentelo de nuevo.");
        }

        if (passengers <= 50)
        {
            commision = 1.0f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 51 && passengers <= 100)
        {
            commision = 1.1f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 101 && passengers <= 150)
        {
            commision = 1.13f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 151 && passengers <= 200)
        {
            commision = 1.15f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 200)
        {
            commision = 1.15f;
            return (tripValue * (decimal)commision) + (100 * (passengers - 200));
        }
    }

    if (route == "4")
    {
        value = 1000000m;
        tripValue = value * trips;

        if (passengers < 0)
        {
            throw new ArgumentOutOfRangeException("Tiene que ser mayor el número de pasajeros, intentelo de nuevo.");
        }

        if (passengers <= 50)
        {
            commision = 1.0f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 51 && passengers <= 100)
        {
            commision = 1.125f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 101 && passengers <= 150)
        {
            commision = 1.15f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 151 && passengers <= 200)
        {
            commision = 1.17f;
            return tripValue * (decimal)commision;
        }

        if (passengers > 200)
        {
            commision = 1.17f;
            return (tripValue * (decimal)commision) + (150 * (passengers - 200));
        }
    }

    return 0;
}

decimal CalculateGrantsIncome(string? route, decimal grantsLessThan10Kg, decimal grantsBetween10KgAndLessThan20Kg, decimal grantsMoreThan20Kg)
{
    //lets use switch cases now, if statements are redundant
    decimal value = 0;

    switch (route)
    {
        case "1": 
        case "2": //making this makes the case verify for 1 and then inmeaditly verify for 2
            //for grants that weight less than 10
            if (grantsLessThan10Kg <= 50 ) value += grantsLessThan10Kg * 100;//value = value + value
            else if (grantsLessThan10Kg <= 100) value += grantsLessThan10Kg * 120; //here, we want to use else if because we aren´t returning the value directly in the if statements
            else if (grantsLessThan10Kg <= 130) value += grantsLessThan10Kg * 150;
            else value += grantsLessThan10Kg * 160;

            //for grants that weight between 10 and 20
            //variable for getting recharges in package shipping for route 1 and 2
            var grantsGreater10 = grantsBetween10KgAndLessThan20Kg + grantsMoreThan20Kg;
            if (grantsGreater10 <= 50) value += grantsGreater10 * 120;
            else if (grantsGreater10 <= 100) value += grantsGreater10 * 140; 
            else if (grantsGreater10 <= 130) value += grantsGreater10 * 160;
            else value += grantsGreater10 * 180;

            return value;

        default: //for routes 3 and 4
            if (grantsLessThan10Kg <= 50) value += grantsLessThan10Kg * 130;
            else if (grantsLessThan10Kg <= 100) value += grantsLessThan10Kg * 160;
            else if (grantsLessThan10Kg <= 130) value += grantsLessThan10Kg * 175;
            else value += grantsLessThan10Kg * 200;

            if (grantsBetween10KgAndLessThan20Kg <= 50) value += grantsBetween10KgAndLessThan20Kg * 140;
            else if (grantsBetween10KgAndLessThan20Kg <= 100) value += grantsBetween10KgAndLessThan20Kg * 180;
            else if (grantsBetween10KgAndLessThan20Kg <= 130) value += grantsBetween10KgAndLessThan20Kg * 200;
            else value += grantsBetween10KgAndLessThan20Kg * 250;

            if (grantsMoreThan20Kg <= 50) value += grantsMoreThan20Kg * 170;
            else if (grantsMoreThan20Kg <= 100) value += grantsMoreThan20Kg * 210;
            else if (grantsMoreThan20Kg <= 130) value += grantsMoreThan20Kg * 250;
            else value += grantsMoreThan20Kg * 300;

            return value;
    }
}

decimal CalculateHelperPayment(decimal totalIncome)
{
    if (totalIncome < 0) throw new ArgumentOutOfRangeException("El ingreso total debe ser mayor que 0. Intentelo de nuevo.");
    if (totalIncome < 1000000) return totalIncome * (decimal)0.05f;
    if (totalIncome < 2000000) return totalIncome * (decimal)0.08f;
    if (totalIncome < 4000000) return totalIncome * (decimal)0.1f;
    return totalIncome * (decimal)0.13f;

}

decimal CalculateInsurancePayment(decimal totalIncome)
{
    if (totalIncome < 0) throw new ArgumentOutOfRangeException("El ingreso total debe ser mayor que 0. Intentelo de nuevo.");
    if (totalIncome < 1000000) return totalIncome * (decimal)0.03f;
    if (totalIncome < 2000000) return totalIncome * (decimal)0.04f;
    if (totalIncome < 4000000) return totalIncome * (decimal)0.06f;
    return totalIncome * (decimal)0.09f;
}

decimal CalculateFuelPayment(string? route, int trips, int passengers, decimal grantsLessThan10Kg, decimal grantsBetween10KgAndLessThan20Kg, decimal grantsMoreThan20Kg)
{
    float kilometers;
    switch(route) //calculate the value depending on the route with a switch
    {
        case "1":
            kilometers = 150 * trips;
            break;
        case "2":
            kilometers = 167 * trips;
            break;
        case "3":
            kilometers = 184 * trips;
            break;
        default:
            kilometers = 204 * trips;
            break;
    }
    var gallons = kilometers / 39;
    var value = (decimal)gallons * 8860m;
    var busWeight = (passengers * 60) + (grantsLessThan10Kg * 10) + (grantsBetween10KgAndLessThan20Kg * 15) + (grantsMoreThan20Kg * 20);
    if (busWeight < 5000) return value;
    if (busWeight <= 10000) return value * 1.1m;
    return value * 1.25m;
}

