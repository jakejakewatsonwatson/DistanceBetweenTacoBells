namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            var cells = line.Split(','); //This splits the line we just recieved from our .csv  file into an array based on where we have a comma
            TacoBell tacoBell = new TacoBell(); //This creates a new TacoBell that we can assign a location and name to

            if (cells.Length != 3) //Checks  to make sure the line we received when split has just 3 elements, Lat, Lon, and a store name
            {
                return null; //I think this is called an 'Early out'
            }

            string lat = cells[0]; //Assigns the first and second element to the Lat and Lon, or first and second element in the array, respectively
            string lon = cells[1];
            string storeName = cells[2]; //Assigns the last element to the TacoBells store name
            
            tacoBell.Name = storeName;
            double.TryParse(lat, out double doubleLat); //Parses the Lat and Lon, which are at first a string, into a double
            double.TryParse(lon, out double doubleLon);

            tacoBell.Location = new Point { Longitude = doubleLon, Latitude = doubleLat }; //This sets the value of our TacoBell location to the parsed Lat and Lon
            
            return tacoBell;
        }
    }
}