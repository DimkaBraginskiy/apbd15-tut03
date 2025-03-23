namespace apbd15_tut03;

public abstract class Container
{
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
                throw new OverfillException($"value: {value} provided is greater than {MaxPayload}");
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

    public Container(decimal mass, decimal height, decimal tareWeight, decimal depth, string serialNumber, decimal maxPayload, string type)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        Type = type;
        SerialNumber = $"KON{type}";
        MaxPayload = maxPayload;
    }


    public virtual void EmptyCargo()
    {
        Mass = 0;
    }

    public virtual void LoadContainer(decimal mass)
    {
        if (mass > 0)
        {
            throw new OverflowException($"The container is already loaded.");
        }

        Mass = mass;
    }
}