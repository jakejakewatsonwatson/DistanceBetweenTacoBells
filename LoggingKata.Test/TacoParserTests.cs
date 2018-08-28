using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            Console.WriteLine("Did something");
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData(33.564151, -84.413382, "Taco Bell Riverdale", "33.564151, -84.413382, Taco Bell Riverdale")]
        public void ShouldParse(int lat, int lon, string name, string csvTest)
        {
            TacoParser taco = new TacoParser();
            Point point = new Point();
            TacoBell bell = new TacoBell();
            point.Latitude = lat;
            point.Longitude = lon;
            bell.Name = name;
            bell.Location = point;
            ITrackable test = taco.Parse(csvTest);
            Assert.Equal(bell.Location.Latitude, test.Location.Latitude);
            Assert.Equal(bell.Location.Longitude, test.Location.Longitude);
            Assert.Equal(bell.Name, test.Name);
            // TODO: Complete Should Parse
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            TacoParser taco = new TacoParser();
            ITrackable answer = taco.Parse(str);
            Assert.Equal(null, answer);
            // TODO: Complete Should Fail Parse
        }
    }
}
