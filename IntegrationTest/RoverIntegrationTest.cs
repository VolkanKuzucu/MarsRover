using System.Collections.Generic;
using MarsRoverVolkan.Abstract;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Models;
using Xunit;

namespace IntegrationTest
{
    public class RoverIntegrationTest
    {
        [Theory]
        [MemberData(nameof(RoverProcessData))]
        public void RoverProcessTest(PlateauFactory plateauCoordinate, Coordinate roverCoordinate, Direction direction,
            string process, string expected)
        {
            var rover = new Rover(plateauCoordinate, roverCoordinate, direction);
            rover.Process(process);
            var actual = $"{rover.RoverCoordinate.X} {rover.RoverCoordinate.Y} {rover.RoverDirection}";
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> RoverProcessData()
        {
            yield return new object[]
            {
                new PlateauFactory(new Coordinate {X = 5, Y = 5}), new Coordinate {X = 1, Y = 2}, Direction.N,
                "LMLMLMLMM", "1 3 N"
            };
            yield return new object[]
            {
                new PlateauFactory(new Coordinate {X = 5, Y = 5}), new Coordinate {X = 3, Y = 3}, Direction.E,
                "MMRMMRMRRM", "5 1 E"
            };
        }
    }
}