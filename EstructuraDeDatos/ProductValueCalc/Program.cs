//VR_V product value calculation by the next info:
/*
 Purchase Cost
 Product Type (perishable or non-perishable)
 Conservation Type (cold or room temperature)
 Conservation Period (In Days)
 Storage Period (In Days)
 Volume (in litres)
 Storage Means (fridge, freezer, shelf, crate)
 */

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");

    var purchaseCost = ConsoleExtension.GetDecimal("Ingrese costo de la compra: ");
    
    var productTypeOptions = new List<string> { "p", "n" };
    string productType;

    do
    {
        productType = ConsoleExtension.GetValidOptions("Tipo de producto: [P]erecedero, [N]o Perecedero: ", productTypeOptions)!;
    } while (!productTypeOptions.Any(x => x.Equals(productType, StringComparison.CurrentCultureIgnoreCase)));

    var conservationTypeOptions = new List<string> { "f", "a" };
    string conservationType;

    do
    {
        conservationType = ConsoleExtension.GetValidOptions("Tipo de conservación [F]rio, [A]mbiente: ", conservationTypeOptions)!;
    } while (!conservationTypeOptions.Any(x => x.Equals(conservationType, StringComparison.CurrentCultureIgnoreCase)));

    var conservationPeriod = ConsoleExtension.GetInt("Ingrese periodo de conservación en dias: ");
    var storagePeriod = ConsoleExtension.GetInt("Ingrese periodo de almacenamiento en dias: ");
    var productVolume = ConsoleExtension.GetDecimal("Ingrese volumen en litros: ");

    var storageMeanOptions = new List<string> { "n", "c", "e", "g" };
    string storageMean;

    do
    {
        storageMean = ConsoleExtension.GetValidOptions("Medio de almacenamiento [N]evera, [C]ongelador, [E]stanteria, [G]uacal: ", storageMeanOptions)!;
    } while (!storageMeanOptions.Any(x => x.Equals(storageMean, StringComparison.CurrentCultureIgnoreCase)));

    Console.WriteLine("*** CALCULOS ***");

    var storageCost = CalculateStorageCost(productType, productVolume, purchaseCost, conservationType, conservationPeriod, storagePeriod);
    var productDepreciationRate = ProductDepreciationRateCalculation(storagePeriod);
    var exhibitionCost = ExhibitionCostCalculation(productType, conservationType, storageMean, storageCost);

    var VR_P = CalculateVR_PCost(purchaseCost, storageCost, exhibitionCost, productDepreciationRate); //product value
    var VR_V = CalculateVR_VCost(VR_P, productType); //final product cost

    Console.WriteLine($"Costos de almacenamiento: {storageCost,20:C2}");
    Console.WriteLine($"Porcentaje de depreciación: {productDepreciationRate,20}");
    Console.WriteLine($"Costos de exhibición: {exhibitionCost,20:C2}");
    Console.WriteLine($"Valor de producto: {VR_P,20:C2}");
    Console.WriteLine($"Valor de venta: {VR_V,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game Over :)");

decimal CalculateVR_PCost(decimal purchaseCost, decimal storageCost, decimal exhibitionCost, float productDepreciationRate)
{
    return (purchaseCost + storageCost + exhibitionCost) * (decimal)productDepreciationRate;
}

decimal CalculateVR_VCost(decimal VR_P, string productType)
{
    if (productType == "p")
    {
        return VR_P * 1.4m; //for plus, we add the 1
    }
    else
    {
        return VR_P * 1.2m;
    }
}

decimal ExhibitionCostCalculation(string productType, string conservationType, string storageMean, decimal storageCost)
{
    if (productType == "p")
    {
        if(conservationType == "f" && storageMean == "n")
        {
            return storageCost * 2;
        }

        if (conservationType == "f" && storageMean == "c")
        {
            return storageCost;
        }
    }
    else
    {
        if (storageMean == "e")
        {
            return storageCost * 0.05m;
        }

        if (storageMean == "g")
        {
            return storageCost * 0.07m;
        }
    }

    return 0;
}

float ProductDepreciationRateCalculation(int storagePeriod) //when returning just percentages, always do them with float values, then change their type value
{
    if (storagePeriod <= 0)
    {
        throw new ArgumentOutOfRangeException("Tiene que ser más de 1 dia, intentelo de nuevo.");
    }
    if (storagePeriod < 30)
    {
        return 0.95f;
    }
    
    return 0.85f;
    
}

decimal CalculateStorageCost(string productType, decimal productVolume, decimal purchaseCost, string conservationType, int conservationPeriod, int storagePeriod)
{
    if (productType == "p")
    {
        if (conservationType == "f" && conservationPeriod < 10)
        {
            return purchaseCost * 0.05m;
        }

        if (conservationType == "f" && conservationPeriod >= 10)
        {
            return purchaseCost * 0.1m;
        }

        if (conservationType == "a" &&  storagePeriod < 20)
        {
            return purchaseCost * 0.03m;
        }

        if (conservationType == "a" && storagePeriod > 20)
        {
            return purchaseCost * 0.1m;
        }

        if (conservationType == "a" && storagePeriod == 20)
        {
            return purchaseCost * 0.05m;
        }
        else
        {
            return purchaseCost;
        }

    }
    else
    {
        if (productVolume >= 50)
        {
            return purchaseCost * 0.1m;
        }

        if (productVolume < 50)
        {
            return purchaseCost * 0.2m;
        }
    }

    return 0;
}

