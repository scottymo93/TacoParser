using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.113051, -84.56005, Taco Bell Woodstoc...", -84.56005)]
        [InlineData("33.796264,-84.224516,Taco Bell Stone Mountain...", -84.224516)]
        [InlineData("34.7348,-86.633875,Taco Bell Huntsville...", -86.633875)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...",34.073638 )]
        [InlineData("34.113051, -84.56005, Taco Bell Woodstoc...", 34.113051)]
        [InlineData("34.7348,-86.633875,Taco Bell Huntsville...", 34.7348)]
        [InlineData("33.849014,-87.279978,Taco Bell Jasper...", 33.849014)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse(line);
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
