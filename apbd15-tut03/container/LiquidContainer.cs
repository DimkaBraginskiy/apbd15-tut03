namespace apbd15_tut03;

public class LiquidContainer : Container, IHazardNotifier 
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(decimal mass, decimal height, decimal tareWeight, decimal depth, string serialNumber, decimal maxPayload, string type, bool isHazardous) : base(mass, height, tareWeight, depth, serialNumber, maxPayload, type)
    {
        IsHazardous = isHazardous;
    }
    

    public void Notify(string message, string serialNumber)
    {
        Console.WriteLine($"Hazardous container: {message} Serial number: {serialNumber}");
    }

    public override void LoadContainer(decimal mass)
    {
        if (IsHazardous)
        {
            MaxPayload *= (decimal)0.5;
        }
        else if(!IsHazardous)
        {
            MaxPayload *= (decimal)0.9;
        }
        else if(mass > MaxPayload)
        {
            Notify("Container Rules were violated", "KON-L");
        }
    }
}