// See https://aka.ms/new-console-template for more information

using System.Numerics;
using apbd15_tut03;
using Container = System.ComponentModel.Container;

public class Program
{
    public static void Main(string[] args)
    {
        var ship = new Ship(25, 50, 1000);
        var container = new LiquidContainer(50, 3, 50, 3,  100, "L", true);
        
        
        ship.LoadContainer(container);
        ship.PrintInfo();
        container.PrintInfo();
        
    }    
}


