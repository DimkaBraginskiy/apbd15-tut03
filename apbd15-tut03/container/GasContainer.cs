namespace apbd15_tut03;

public class GasContainer : Container, IHazardNotifier
{
    private decimal _pressure;

    public GasContainer(decimal mass, decimal height, decimal tareWeight, decimal depth, decimal maxPayload, string type, decimal pressure) : base(mass, height, tareWeight, depth, maxPayload, type)
    {
        _pressure = pressure;
    }

    public override void EmptyCargo()
    {
        Mass -= Mass * (decimal)0.95;//leaving 5% by subtracting 95%
    }
    
    public override void LoadContainer(decimal mass)
    {
        if (mass > MaxPayload)
        {
            Notify("Maximum Mass Payload has been exceeded.", "KON-G");
            throw new OverfillException($"mass: {mass} provided is greater than {MaxPayload}");
        }

        Mass = mass;
    }
    
    public void Notify(string message, string serialNumber)
    {
        Console.WriteLine($"Hazardous container: {message} Serial number: {serialNumber}");
    }
}