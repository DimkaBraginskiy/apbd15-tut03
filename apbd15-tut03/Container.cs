namespace apbd15_tut03;

public class Container
{
    public decimal Mass { get; set; }
    public decimal Height { get; set; }
    public decimal TareWeight { get; set; }
    public decimal Depth { get; set; }
    public String SerialNumber { get; set; }
    public int MaxPayload { get; set; }
    public string Type { get; set; }

    public Container(decimal mass, decimal height, decimal tareWeight, decimal depth, string serialNumber, int maxPayload, string type)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        Type = type;
        SerialNumber = $"KON{type}-{}";
        MaxPayload = maxPayload;
    }
}