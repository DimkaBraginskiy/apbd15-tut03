namespace apbd15_tut03;

public class Ship
{
    private List<Container> containers;
    private decimal _maxContainerNum;
    private decimal _maxSpeed;
    private decimal _maxContainerWeight;

    public Ship(decimal maxContainerNum, decimal maxSpeed, decimal maxContainerWeight)
    {
        containers = new List<Container>();
        _maxContainerNum = maxContainerNum;
        _maxSpeed = maxSpeed;
        _maxContainerWeight = maxContainerWeight;
    }

    private void LoadContainer(Container container)
    {
        if (containers.Count >= _maxContainerNum)
        {
            throw new OverfillException($"{container} can not be added. Maximum container number has been reached.");
        }
        
        if (_maxContainerWeight - container.Mass < 0)
        {
            throw new OverfillException($"{container} can not be added. Maximum container weight has been reached.");
        }
        
        containers.Add(container);
        _maxContainerWeight -= container.Mass;
        _maxContainerNum--;
    }

    private void LoadContainers(List<Container> containers)
    {
        decimal totalWeight = 0;
        foreach (Container container in containers)
        {
            totalWeight += container.Mass;
        }

        if (totalWeight > _maxContainerWeight)
        {
            throw new OverfillException("Weights of provided List of containers to fill has exceeded the maximum capacity weight");
        }

        if (containers.Count >= _maxContainerNum)
        {
            throw new OverfillException("Number of provided List of containers to fill has exceeded the maximum capacity number");
        }


        foreach (Container container in containers)
        {
            LoadContainer(container);
            _maxContainerWeight -= container.Mass;
            _maxContainerNum--;
        }
    }

    private void RemoveContainer(Container container)
    {
        if (containers.Contains(container))
        {
            _maxContainerWeight+=container.Mass;
            _maxContainerNum++;
            containers.Remove(container);
        }
        else
        {
            Console.WriteLine($"{container} does not exist");
        }
    }

    private void ReplaceContainer(string serialNumber, Container container)
    {
        Container containerToRemove = containers.Find(container => container.SerialNumber == serialNumber);
        if (_maxContainerWeight + containerToRemove.Mass - container.Mass < 0)
        {
            throw new OverfillException(
                $"Can not replace {containerToRemove} with {container} as the weight of a new container exceeds " +
                $"the maximum container capacity weight.");
        }

        if (containerToRemove != null)
        {
            _maxContainerWeight += containerToRemove.Mass;
            _maxContainerNum++;
            containers.Remove(containerToRemove);

            if (_maxContainerWeight - container.Mass >= 0)
            {
                _maxContainerWeight -= container.Mass;
                _maxContainerNum--;
                containers.Add(container);
            }
        }
        else
        {
            Console.WriteLine($"Can not replace {containerToRemove} with serial number {serialNumber}");
        }
    }   
}