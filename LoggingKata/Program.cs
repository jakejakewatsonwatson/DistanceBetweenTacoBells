using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            TacoParser tacoParser = new TacoParser();
            var lines = File.ReadAllLines(csvPath);   //This line calls the File class and uses the method 'ReadAllLines' to read all lines of our .csv file

            double distance = 0;    //All of these variables are needed later in the program :)
            double maxDistance = 0;
            string store1 = "";
            string store2 = "";

            var locations = lines.Select(tacoParser.Parse); //This uses each 'var lines' from line 17, and sends them through our TacoParser class

            foreach (var line in locations)  //This foreach loop goes through each of our parsed locations, and assigns them a GeoCoordinate as our 'Origin point'
            {
                GeoCoordinate Geo1 = new GeoCoordinate(); //Create a new instance of the geocoordinate class

                Geo1.Latitude = line.Location.Latitude; //To set up a GeoCoordinate we have to assign the Lat and Lon as seperate values 
                Geo1.Longitude = line.Location.Longitude;
                
                foreach (var line2 in locations) //This foreach loop goes through all of our parsed locations again, to give us a GeoCoordinate to compare to our 'Origin point' on line 26
                {
                    GeoCoordinate Geo2 = new GeoCoordinate();

                    Geo2.Latitude = line2.Location.Latitude;
                    Geo2.Longitude = line2.Location.Longitude;

                    distance = Geo1.GetDistanceTo(Geo2); //This method was in our ReadMe file,and is a part of the GeoCoordinate class

                    if(maxDistance < distance) //This compares our current Largest distance to the distance we just got above.
                    {
                        store1 = line.Name; //If our new distance is greater, we need to update the distance and the stores it was between
                        store2 = line2.Name;

                        maxDistance = distance;
                    }
                }
            }

            Console.WriteLine($"The Taco Bells furthest away from each other are:"); //Possibly a better way to say this? Not sure
            Console.WriteLine($"{store1} and the {store2}, at {maxDistance} meters apart"); //Also, not sure that the distance is in meters, or correct. I checked online the distance betwen the two stores and it was 591.41 kilometers.
            Console.ReadLine();
        }
    }
} 