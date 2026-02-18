//A goods supplier has a rate and discount plan among shipping value for its clients
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };


do
{
    var goodsWeight = ConsoleExtension.GetFloat("Ingrese peso de la mercancia: ");
    var goodsValue = ConsoleExtension.GetDecimal("Ingrese valor de la mercancia: ");
    string isMonday;

    do
    {
        isMonday = ConsoleExtension.GetValidOptions("¿Es Lunes? [S]i [N]o: ", options)!;
    } while (!options.Any(x => x.Equals(isMonday, StringComparison.CurrentCultureIgnoreCase)));

    var payMethods = new List<string> { "e", "t" };
    string payMethod;
    do
    {
        payMethod = ConsoleExtension.GetValidOptions("Tipo de pago [E]fectivo [T]arjeta: ", payMethods)!;
    } while (!payMethods.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));

    var rateValue = CalculateRateValue(goodsWeight);
    var discountValue = CalculateDiscountValue(rateValue, goodsValue);
    decimal promo = 0;
    if (discountValue == 0)
    {
        promo = IfPromotion(rateValue, isMonday, payMethod, goodsValue);
    }

    Console.WriteLine($"Tarifa: {rateValue,20:C2}");
    Console.WriteLine($"Descuento: {discountValue,20:C2}");
    Console.WriteLine($"Promoción: {promo,20:C2}");
    Console.WriteLine($"Total a pagar: {rateValue - discountValue - promo,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Gracias por usar el programa! Game Over :)");

decimal IfPromotion(decimal rateValue, string isMonday, string payMethod, decimal goodsValue)
{
    if (isMonday.ToLower() == "s" && payMethod.ToLower() == "t")
    {
        return rateValue * 0.5m;
    }

    if (payMethod.ToLower() == "e" && goodsValue > 1000000m)
    {
        return rateValue * 0.4m;
    }

    return 0;
}

decimal CalculateDiscountValue(decimal rateValue, decimal goodsValue)
{
    if (goodsValue >= 300000m && goodsValue <= 600000m)
    {
        return rateValue * 0.1m;
    }
    if (goodsValue > 600000m && goodsValue <= 1000000m)
    {
        return rateValue * 0.2m;
    }
    if (goodsValue >= 1000000m)
    {
        return rateValue * 0.3m;
    }
    return 0;
}

decimal CalculateRateValue(float goodsWeight)
{
    if (goodsWeight <= 100)
    {
        return 20000m;
    }
    if (goodsWeight <= 150)
    {
        return 25000m;
    }
    if (goodsWeight <= 200)
    {
        return 30000m;
    }
    int aditional = ((int)goodsWeight - 200) / 10;
    //if weight is more than 200 then the rate is 35000 and for every 10 kgs additional its 2000 more
    return 35000m + aditional * 2000m;
}
