using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using static EuromonitorInternational.Vehicle;

namespace EuromonitorInternational
{
    /// <summary>
    /// This singleton class represents the database and it is responsible for all database operations.
    /// </summary>
    public sealed class Database
    {
        private static readonly Database instance = new Database();
        static Database() { }
        private Database() { }
        public static Database Instance
        {
            get { 
                return instance; 
            }
        }
        /// <summary>
        /// This method formats the connection string for the database.
        /// </summary>
        /// <returns>A formatted connection string</returns>
        private string connectionString()
        {
            return "Data Source=DESKTOP-0K600UP;Initial Catalog=VehicleInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        //Gets how many of each model were sold throughout between 2011 -2020 
        public List<Vehicle> GetModels()
        {
            List<Vehicle> list = new List<Vehicle>();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString()))
                {
                    SqlDataReader rdr = null;

                    connection.Open();
                    //Query to retrieve how many of each model were sold throughout between 2011 -2020
                    String SQLquery = "Select\"" + DatabaseNames.MODEL + "\", SUM(\"" + DatabaseNames.VEHICLESSOLD + "\") from\"" + DatabaseNames.TABLE_VEHICLE + "\"INNER JOIN\"" + DatabaseNames.TABLE_SALESHISTORY + "\"ON Vehicle.id = SalesHistory.id WHERE\"" + DatabaseNames.YEAR + "\"BETWEEN 2011 AND 2020  GROUP BY Vehicle.model";

                    // Pass the connection to a command object
                    SqlCommand command = new SqlCommand(SQLquery, connection);

                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {

                        //Console.WriteLine(rdr);
                        //list.Add(new Vehicle((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3]));
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.WriteLine(rdr.GetValue(i));
                        }
                        

                        Console.WriteLine();
                    }

                    rdr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }


            return list;
        }

        //Gets which manufacturer sold the most amount between 2011 -2020?
        public List<Vehicle> GetManufacturer()
        {
            //List<Vehicle> list = new List<Vehicle>();
            List<Vehicle> list = new List<Vehicle>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString()))
                {
                    SqlDataReader rdr = null;
                    connection.Open();
                    //Query to retrieve which manufacturer sold the most amount 
                    String SQLquery = "SELECT \"" + DatabaseNames.MANUFACTURER+ "\", SUM(\"" + DatabaseNames.VEHICLESSOLD + "\") FROM\"" + DatabaseNames.TABLE_VEHICLE + "\"INNER JOIN\"" + DatabaseNames.TABLE_SALESHISTORY + "\"ON Vehicle.id = SalesHistory.id WHERE\"" + DatabaseNames.YEAR + "\"BETWEEN 2011 AND 2020  GROUP BY\"" + DatabaseNames.MANUFACTURER+ "\"ORDER BY SUM(\""+DatabaseNames.VEHICLESSOLD+"\") DESC ";

                    // Pass the connection to a command object
                    SqlCommand command = new SqlCommand(SQLquery, connection);

                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        //list.Add(new Vehicle(Number, (string)rdr[1], (string)rdr[2], (string)rdr[3])); 
                        //ist = new Vehicle((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3]);
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.WriteLine(rdr.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                    rdr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }
            return list;
        }

        //Gets the average number of vehicles sold across all manufacturers and models between 2011 -2020
        public Vehicle GetAvgSold()
        {
            Vehicle avgSold = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString()))
                {
                    SqlDataReader rdr = null;
                    connection.Open();
                    //Query to retrieve average number of vehicles sold 
                    String SQLquery = "Select AVG(\""+ DatabaseNames.VEHICLESSOLD +"\") AS 'Average Sold' from\"" + DatabaseNames.TABLE_VEHICLE+ "\" INNER JOIN\"" + DatabaseNames.TABLE_SALESHISTORY + "\"ON Vehicle.id = SalesHistory.id WHERE\"" + DatabaseNames.YEAR + "\"BETWEEN 2011 AND 2020 ";

                    // Pass the connection to a command object
                    SqlCommand command = new SqlCommand(SQLquery, connection);

                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.WriteLine(rdr.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                    rdr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }
            return avgSold;
        }

        //Gets the most common colour of vehicles sold between 2011 -2020
        public Vehicle GetCommonColour()
        {
            Vehicle commonColour = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString()))
                {
                    SqlDataReader rdr = null;
                    connection.Open();

                    //Query to retrieve the most common colour
                    String SQLquery = "SELECT TOP 1\"" + DatabaseNames.COLOUR + "\" from \"" + DatabaseNames.TABLE_VEHICLE + "\" INNER JOIN \"" + DatabaseNames.TABLE_SALESHISTORY + "\" ON Vehicle.id = SalesHistory.id WHERE\"" + DatabaseNames.YEAR + "\"BETWEEN 2011 AND 2020 ORDER BY \"" + DatabaseNames.COLOUR + "\"DESC";

                    // Pass the connection to a command object
                    SqlCommand command = new SqlCommand(SQLquery, connection);
                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            //Displays the database cloumns
                            Console.WriteLine(rdr.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                    rdr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }
            return commonColour;
        }

    }
    public static class DatabaseNames
    {

        /// Database Table Names
        public static readonly string TABLE_VEHICLE = "Vehicle";
        public static readonly string TABLE_SALESHISTORY = "SalesHistory";

        /// Database Field Names
        /// Vehicle Field Names
        public static readonly string ID = "id";
        public static readonly string MODEL = "model";
        public static readonly string COLOUR = "colour";
        public static readonly string MANUFACTURER = "manufacturer";


        /// SalesHistory Field Names
        public static readonly string YEAR = "year";
        public static readonly string VEHICLESSOLD = "vehiclesSold";
        //public static readonly string VID = "id";


    }

}

