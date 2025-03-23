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
                    //AddShip();
                    break;
                /*case 2:
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
                    PrintShipInfo();
                    break;
                case 7:
                    PrintContainerInfo();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Invalid choice. PLease try once more.");
                    break;*/
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
            foreach (var ship in ships)
            {
                Console.WriteLine(ship.ToString());
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
            Console.WriteLine("8. Exit");
        }
    }

    private static void AddShip()
    {
        
    }
}


