namespace apbd15_tut03;

public class Ship
{
    private List<Container> containers;
    private decimal _maxContainerNum;
    private decimal _maxSpeed;
    private decimal _maxContainersWeight;

    public Ship(decimal maxContainerNum, decimal maxSpeed, decimal maxContainersWeight)
    {
        containers = new List<Container>();
        _maxContainerNum = maxContainerNum;
        _maxSpeed = maxSpeed;
        _maxContainersWeight = maxContainersWeight;
    }

    public void LoadContainer(Container container)
    {
        if (containers.Count >= _maxContainerNum)
        {
            throw new OverfillException($"{container} can not be added. Maximum container number has been reached.");
        }

        decimal containerTonMass = container.TotalMass / 1000;
        
        if (_maxContainersWeight - containerTonMass < 0)
        {
            throw new OverfillException($"{container} can not be added. Maximum container weight has been reached.");
        }
        
        containers.Add(container);
        AdjustWeightAndNum(-containerTonMass, -1);
        Console.WriteLine($"Loaded container of type {container.GetType().Name}");
    }

    public void LoadContainers(List<Container> newContainers)
    {
        decimal totalWeightInTons = newContainers.Sum(container => container.TotalMass / 1000);
        
        if (totalWeightInTons > _maxContainersWeight)
        {
            throw new OverfillException("Weights of provided List of containers to fill has exceeded the maximum capacity weight");
        }

        if (containers.Count + newContainers.Count >= _maxContainerNum)
        {
            throw new OverfillException("Number of provided List of containers to fill has exceeded the maximum capacity number");
        }
        
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
        Console.WriteLine("Containers were added successfully.");
    }

    public void RemoveContainer(Container container)
    {
        if (containers.Contains(container))
        {
            decimal containerWeightInTons = container.TotalMass / 1000;
            
            
            RemoveContainer(container);
            Console.WriteLine($"{container} was removed from the ship");
        }
        else
        {
            Console.WriteLine($"{container} does not exist");
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        Container containerToRemove = containers.Find(container => container.SerialNumber == serialNumber);
        
        if (containerToRemove == null)
        {
            Console.WriteLine($"Can not replace {containerToRemove} with serial number {serialNumber}");
            return;
        }

        decimal containerToRemoveWeightInTons = containerToRemove.TotalMass / 1000;
        decimal containerToAddWeightInTons = newContainer.TotalMass / 1000;
        
        if (_maxContainersWeight + containerToRemoveWeightInTons - containerToAddWeightInTons < 0)
        {
            throw new OverfillException(
                $"Can not replace {containerToRemove} with {newContainer} as the weight of a new container exceeds " +
                $"the maximum container capacity weight.");
        }
        
        RemoveContainer(containerToRemove);
        
        if (_maxContainersWeight - containerToAddWeightInTons >= 0) 
        { 
            LoadContainer(newContainer);
        }
    }

    public void TransferContainer(Container container, Ship targetShip)
    {
        if (!containers.Contains(container))
        {
            throw new InvalidOperationException($"Container: {container} not found");
        }
        
        RemoveContainer(container);
        try
        {
            targetShip.LoadContainer(container);
            Console.WriteLine($"{container} was successfully transferred to {targetShip}");
        }
        catch (OverfillException e)
        {
            LoadContainer(container);
            Console.WriteLine($"loaded container: {container} back as the {targetShip} could not accept it.");
            throw new OverfillException("Transfer failed: " + e.Message);
        }
        
    }

    public void AdjustWeightAndNum(decimal weight, int num)
    {
        _maxContainersWeight+=weight;
        _maxContainerNum += num;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ship Information:");
        Console.WriteLine($"- Max Speed: {_maxSpeed} knots");
        Console.WriteLine($"- Max Containers: {_maxContainerNum}");
        Console.WriteLine($"- Max Weight: {_maxContainersWeight} tons");
        Console.WriteLine($"- Current Containers: {containers.Count}");
        Console.WriteLine("Containers on board:");
        foreach (var container in containers)
        {
            Console.WriteLine(container.ToString());
        }
    }

    public override string ToString()
    {
        return
            $"Ship [MaxSpeed: {_maxSpeed} knots, MaxContainers: {_maxContainerNum}, MaxContainerWeight: {_maxContainersWeight} tons," +
            $"Containers: {containers.Count} ]";
    }
}