using System.Collections.Specialized;

namespace apbd15_tut03;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    private readonly string _productType;

    private decimal _temperature;
    
    private static readonly Dictionary<string, decimal> products = new()
    {
        {"Frozen pizza", -30 },
        {"Ice cream", -18 },
        {"Meat", -15 },
        {"Fish", 2 },
        {"Sausages", 5 },
        {"Cheese", (decimal)7.2 },
        {"Bananas", (decimal)13.3 },
        {"Chocolate", 18 },
        {"Eggs", 19},
        {"Butter", (decimal)20.5}
    };

    public RefrigeratedContainer(decimal mass, decimal height, decimal tareWeight, decimal depth, string serialNumber, decimal maxPayload, string type, string productType, decimal temperature) : base(mass, height, tareWeight, depth, serialNumber, maxPayload, type)
    {
        _productType = productType;
        setTemperature(temperature);
    }
    
    private void setTemperature(decimal temperature)
    {
        if (products.ContainsKey(_productType))
        {
            decimal requiredTemp = products[_productType];

            if (temperature < requiredTemp)
            {
                Notify($"{temperature} you have set is lower than {requiredTemp} for a product type: {_productType}", "KON-C");
                throw new InvalidOperationException($"temperature: {temperature} is lower than {requiredTemp}.");
            }else if (temperature == requiredTemp)
            {
                _temperature = temperature;
            }
        }
        else
        {
            Notify($"The product type: {_productType} is not supported.", "KON-C");
            throw new InvalidOperationException("The product type is not supported.");
        }
    }
    
    public void Notify(string message, string serialNumber)
    {
        Console.WriteLine($"Hazardous container: {message} Serial number: {serialNumber}");
    }

}