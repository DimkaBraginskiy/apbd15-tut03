namespace apbd15_tut03;

public class LiquidContainer : Container, IHazardNotifier 
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(decimal mass, decimal height, decimal tareWeight, decimal depth, decimal maxPayload, string type, bool isHazardous) : base(mass, height, tareWeight, depth, maxPayload, type)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadContainer(decimal mass)
    {
        decimal allowedPayload = IsHazardous ? MaxPayload * 0.5m : MaxPayload * 0.9m;
        
        if (mass > allowedPayload)
        {
            Notify($"Mass {mass} exceeds allowed payload: {allowedPayload} for hazardous caego.", SerialNumber);
            throw new OverfillException($"mass: {mass} provided is greater than {allowedPayload}");
        }

        Mass = mass;
    }
    
    public void Notify(string message, string serialNumber)
    {
        Console.WriteLine($"Hazardous container: {message} Serial number: {serialNumber}");
    }
}