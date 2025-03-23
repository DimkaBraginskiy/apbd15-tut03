namespace apbd15_tut03;

public class LiquidContainer : Container, IHazardNotifier 
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(decimal mass, decimal height, decimal tareWeight, decimal depth, string serialNumber, decimal maxPayload, string type, bool isHazardous) : base(mass, height, tareWeight, depth, serialNumber, maxPayload, type)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadContainer(decimal mass)
    {
        decimal hazardousMaxPayload = IsHazardous ? MaxPayload *= (decimal)0.5 : MaxPayload *= (decimal)0.9;
        if (mass > hazardousMaxPayload)
        {
            throw new OverfillException($"mass: {mass} provided is greater than {hazardousMaxPayload}");
        }

        Mass = mass;
    }
    
    public void Notify(string message, string serialNumber)
    {
        Console.WriteLine($"Hazardous container: {message} Serial number: {serialNumber}");
    }
}