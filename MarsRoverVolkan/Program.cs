using System;
using MarsRoverVolkan.Abstract;
using MarsRoverVolkan.Abstract.Interface;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;

namespace MarsRoverVolkan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var plateauCoordinate = new Coordinate
            {
                X = 5,
                Y = 5
            };
            
            var plateauFactory = PlateauFactory(plateauCoordinate);

            if (plateauFactory != null)
            {
                var roverCoordinate1 = new Coordinate
                {
                    X = 1,
                    Y = 2
                };

                var roverCoordinate2 = new Coordinate
                {
                    X = 3,
                    Y = 3
                };
            
                var rover1 = new Rover(plateauFactory, roverCoordinate1, Direction.N);
                var rover2 = new Rover(plateauFactory, roverCoordinate2, Direction.E);

                try
                {
                    rover1.Process("LMLMLMLMM");
                    
                    Console.WriteLine($"Rover Coordinate => {rover1.RoverCoordinate.X} {rover1.RoverCoordinate.Y} {rover1.RoverDirection.ToString()}" );

                    rover2.Process("MMRMMRMRRM");
                    
                    Console.WriteLine($"Rover Coordinate => {rover2.RoverCoordinate.X} {rover2.RoverCoordinate.Y} {rover2.RoverDirection.ToString()}" );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }

        private static PlateauFactory PlateauFactory(Coordinate plateauCoordinate )
        {
            PlateauFactory plateauFactory;

            try
            {
                plateauFactory = new PlateauFactory(plateauCoordinate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }

            return plateauFactory;
        }
    }
}