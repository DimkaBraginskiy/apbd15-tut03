// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System;
using System.Collections.Generic;
using apbd15_tut03;


public class Program
{
    private static List<Ship> ships = new List<Ship>();
    private static List<Container> containers = new List<Container>();
    
    public static void Main(string[] args)
    {
        while (true)
        {
            DisplayMenu();
            var choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    AddShip();
                    break;
                case 2:
                    RemoveShip();
                    break;
                case 3:
                    AddContainer();
                    break;
                case 4:
                    RemoveContainer();
                    break;
                case 5:
                    LoadContainerToShip();
                    break;
                case 6:
                    PrintShipsInfo();
                    break;
                case 7:
                    PrintContainersInfo();
                    break;
                case 8: 
                    DisplayProductTemperatures();
                    break;
                case 9:
                    TransferContainerBetweenShips();
                    break;
                case 10:
                    return;
                default:
                    Console.WriteLine("Invalid choice. PLease try once more.");
                    break;
            }
        }
    }

    private static int GetUserChoice()
    {
        Console.WriteLine("Enter your choice: ");
        return int.Parse(Console.ReadLine());
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\nList of container ships: ");
        if (ships.Count == 0)
        {
            Console.Write("None");
        }
        else
        {
            foreach (var ship in ships)
            {
                Console.WriteLine(ship.ToString());
            }
        }
        
        Console.WriteLine("\nList of containers: ");
        if (containers.Count == 0)
        {
            Console.Write("None");
        }
        else
        {
            foreach (var container in containers)
            {
                Console.WriteLine(container.ToString());
            }
        }
        
        Console.WriteLine("\nPossible actions:");
        if (ships.Count == 0)
        {
            Console.WriteLine("1. Add a container ship");
        }
        else
        {
            Console.WriteLine("1. Add a container ship");
            Console.WriteLine("2. Remove a container ship");
            Console.WriteLine("3. Add a container");
            Console.WriteLine("4. Remove a container");
            Console.WriteLine("5. Load container to a ship");
            Console.WriteLine("6. Print ships info");
            Console.WriteLine("7. Print containers info");
            Console.WriteLine("8. Show Product - Temperature table for Refrigerated Container.");
            Console.WriteLine("9. Transfer container between 2 ships");
            Console.WriteLine("10. Exit");
        }
    }

    private static void AddShip()
    {
        var maxContainerNum = ReadDecimal("Enter max container number: ");
        var maxSpeed = ReadDecimal("Enter max speed: ");
        var maxContainersWeight = ReadDecimal("Enter max containers weight: ");

        var ship = new Ship(maxContainerNum, maxSpeed, maxContainersWeight);
        ships.Add(ship);
        Console.WriteLine("Ship added successfully.");
    }

    private static void RemoveShip()
    {
        var index = ReadInt("Enter ship index to remove: ");
        if (index >= 0 && index < ships.Count)
        {
            ships.RemoveAt(index);
            Console.WriteLine($"Ship at index {index} has been successfully removed.");
        }
        else
        {
            Console.WriteLine("Invalid ship index.");
        }
    }

    private static void AddContainer()
    {
        var type = ReadString("Enter container type (Liquid - L; Gas - G; Refrigerated - C): ");
        var mass = ReadDecimal("Enter mass value: ");
        var height = ReadDecimal("Enter height value: ");
        var tareWeight = ReadDecimal("Enter tareWeight value: ");
        var depth = ReadDecimal("Enter depth value: ");
        var maxPayload = ReadDecimal("Enter max payload: ");
        
        Container container;
        switch (type.ToLower())
        {
            case "l":
                var isHazardous = ReadBool("Is it hazardous? (true/false): ");
                container = new LiquidContainer(mass, height, tareWeight, depth, maxPayload, type, isHazardous);
                break;
            case "g":
                var pressure = ReadDecimal("Enter pressure: ");
                container = new GasContainer(mass, height, tareWeight, depth, maxPayload, type, pressure);
                break;
            case "c":
                var productType = ReadString("Enter product type: ");
                var temperature = ReadDecimal("Enter temperature: ");
                container = new RefrigeratedContainer(mass, height, tareWeight, depth, maxPayload, type, productType, temperature);
                break;
            default:
                Console.WriteLine("Invalid container type.");
                return;
        }

        containers.Add(container);
        Console.WriteLine("Container added successfully.");
    }

    private static void RemoveContainer()
    {
        var index = ReadInt("Enter container index to remove: ");
        if (index >= 0 && index < containers.Count)
        {
            containers.RemoveAt(index);
            Console.WriteLine($"Container at index {index} has been successfully removed.");
        }
        else
        {
            Console.WriteLine("Invalid container index.");
        }
    }

    private static void LoadContainerToShip()
    {
        var shipIndex = ReadInt("Enter ship index into which you want to load a container: ");
        var containerIndex = ReadInt("Enter container index you want to load: ");

        if (shipIndex >= 0 && containerIndex >= 0 && shipIndex < ships.Count && containerIndex < containers.Count)
        {
            try
            {
                ships[shipIndex].LoadContainer(containers[containerIndex]);
                Console.WriteLine(
                    $"Сontainer of index {containerIndex} has been successfully loaded to a ship of index {shipIndex}.");
            }
            catch (OverfillException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid ship or caontainer index.");
        }
    }

    private static void TransferContainerBetweenShips()
    {
         if (ships.Count < 2)
        {
            Console.WriteLine("You need at least two ships to transfer a container.");
            return;
        }

        Console.WriteLine("Select the source ship (from which the container will be removed):");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine($"{i}. {ships[i]}");
        }
        var sourceShipIndex = ReadInt("Enter source ship index: ");

        Console.WriteLine("Select the target ship (to which the container will be added):");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine($"{i}. {ships[i]}");
        }
        var targetShipIndex = ReadInt("Enter target ship index: ");

        if (sourceShipIndex < 0 || sourceShipIndex >= ships.Count || targetShipIndex < 0 || targetShipIndex >= ships.Count)
        {
            Console.WriteLine("Invalid ship index.");
            return;
        }

        if (sourceShipIndex == targetShipIndex)
        {
            Console.WriteLine("Source and target ships cannot be the same.");
            return;
        }

        Console.WriteLine("Select the container to transfer:");
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine($"{i}. {containers[i]}");
        }
        var containerIndex = ReadInt("Enter container index: ");

        if (containerIndex < 0 || containerIndex >= containers.Count)
        {
            Console.WriteLine("Invalid container index.");
            return;
        }

        try
        {
            ships[sourceShipIndex].TransferContainer(containers[containerIndex], ships[targetShipIndex]);
            Console.WriteLine($"Container {containers[containerIndex]} transferred successfully from Ship {sourceShipIndex} to Ship {targetShipIndex}.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Transfer failed: {ex.Message}");
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Transfer failed: {ex.Message}");
        }
    }


    private static void PrintShipsInfo()
    {
        ships.ForEach(ship => ship.PrintInfo());
    }

    private static void PrintContainersInfo()
    {
        containers.ForEach(container => container.PrintInfo());
    }

    private static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    private static decimal ReadDecimal(string prompt)
    {
        Console.Write(prompt);
        return decimal.Parse(Console.ReadLine());
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }

    private static bool ReadBool(string prompt)
    {
        Console.Write(prompt);
        return bool.Parse(Console.ReadLine());
    }

    private static void DisplayProductTemperatures()
    {
        Console.WriteLine("\nList of products and their required temperatures:");
        Console.WriteLine("| Product        | Temperature |");
        Console.WriteLine("|----------------|-------------|");
        foreach (var product in RefrigeratedContainer.Products)
        {
            Console.WriteLine($"| {product.Key,-14} | {product.Value,11} |");
        }
    }
}


