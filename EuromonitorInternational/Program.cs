using System;
using System.Collections.Generic;
using static EuromonitorInternational.Vehicle;

namespace EuromonitorInternational
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetModel();
            GetManufacture();
            GetAvgSold();
            GetCommonColour();
        }
        static void GetModel()
        {

            Console.WriteLine("Models sold throughout between 2011 - 2020: ");
            List<Vehicle> vehicles = Database.Instance.GetModels();
            Console.WriteLine("********************************************************************************************");
           
        }
        static void GetManufacture()
        {

            Console.WriteLine("The manufacturer that sold the most amount between 2011 -2020: ");
            List<Vehicle> vehicles = Database.Instance.GetManufacturer();
            Console.WriteLine("********************************************************************************************");
            
        }
        static void GetAvgSold()
        {

            Console.WriteLine("The average number of vehicles sold across all manufacturers and models between 2011 -2020 is: ");
            Vehicle vehicles = Database.Instance.GetAvgSold();
            Console.WriteLine("********************************************************************************************");
            
        }
        static void GetCommonColour()
        {

            Console.WriteLine("The most common colour of vehicles sold between 2011 - 2020 is: ");
            Vehicle vehicles = Database.Instance.GetCommonColour();
            Console.WriteLine("********************************************************************************************");

        }
    }
}
