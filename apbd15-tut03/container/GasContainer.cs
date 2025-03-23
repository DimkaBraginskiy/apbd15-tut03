namespace apbd15_tut03;

public class GasContainer : Container, IHazardNotifier
{
    private decimal _pressure;

    public GasContainer(decimal mass, decimal height, decimal tareWeight, decimal depth, string serialNumber, decimal maxPayload, string type, decimal pressure) : base(mass, height, tareWeight, depth, serialNumber, maxPayload, type)
    {
        _pressure = pressure;
    }

    public override void EmptyCargo()
    {
        Mass -= Mass * (decimal)0.95;//leaving 5% by subtracting 95%
    }

    public void Notify(string message, string serialNumber)
    {
        Console.WriteLine($"Hazardous container: {message} Serial number: {serialNumber}");
    }

    public override void LoadContainer(decimal mass)
    {
        if (mass > MaxPayload)
        {
            Notify("Maximum Mass Payload has been exceeded.", "KON-G");
        }
    }
}