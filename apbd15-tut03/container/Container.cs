namespace apbd15_tut03;

public abstract class Container
{
    private static int _idCounter;
    private decimal _mass;
    public decimal Mass
    {
        get
        {
            return _mass;
        }
        set
        {
            if (value > MaxPayload)
            {
                throw new OverfillException($"Mass: {value} provided is greater than max payload: {MaxPayload}");
            }
            
            _mass = value;
        }
    }
    public decimal Height { get; set; }
    public decimal TareWeight { get; set; }
    public decimal Depth { get; set; }
    public String SerialNumber { get; set; }
    public decimal MaxPayload { get; set; }
    public string Type { get; set; }
    
    public decimal TotalMass => TareWeight + Mass;

    public Container(decimal mass, decimal height, decimal tareWeight, decimal depth, decimal maxPayload, string type)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        Type = type;
        SerialNumber = generateSerialNumber(type);
        MaxPayload = maxPayload;
        
        Mass = mass;
    }

    public string generateSerialNumber(string type)
    {
        int id = ++_idCounter;
        return $"KON-{type}-{id}";
    }


    public virtual void EmptyCargo()
    {
        Mass = 0;
    }

    public virtual void LoadContainer(decimal mass)
    {
        Mass = mass;
    }


    public override string ToString()
    {
        return $"Container: [SerialNumber: {SerialNumber}, Type: {Type}, Mass: {Mass}kg, MaxPayload: {MaxPayload}kg]";
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Container Information:");
        Console.WriteLine($"- Serial Number: {SerialNumber}");
        Console.WriteLine($"- Type: {Type}");
        Console.WriteLine($"- Mass: {Mass} kg");
        Console.WriteLine($"- Max Payload: {MaxPayload} kg");
        Console.WriteLine($"- Height: {Height} cm");
        Console.WriteLine($"- Tare Weight: {TareWeight} kg");
        Console.WriteLine($"- Depth: {Depth} cm");
    }
}