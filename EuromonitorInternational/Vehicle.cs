using System;
using System.Collections.Generic;
using System.Text;

namespace EuromonitorInternational
{
    
    public class SalesHistory
    {
        public string year { get; }
        public int vehiclesSold { get; }
    }

    public class Vehicle
    {
        public int id { get; 
        public string model { get; }
        public string colour { get; }
        public string manufacturer { get; }
        public SalesHistory[] salesHistory { get; set; }

        public Vehicle(int id, string model, string colour, string manufacturer, SalesHistory[] salesHistory)
        {
            this.id = id;
            this.model = model;
            this.colour = colour;
            this.manufacturer = manufacturer;
            this.salesHistory = salesHistory;
        }
    }

}
