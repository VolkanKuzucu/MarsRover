using System;
using MarsRoverVolkan.Models;

namespace MarsRoverVolkan.Extensions
{
    public static class CheckExtensions
    {
        public static void Check(this Coordinate roverCoordinate, Coordinate plateauCoordinate)
        {
            if (roverCoordinate.X>plateauCoordinate.X || roverCoordinate.Y >plateauCoordinate.Y)
            {
                throw new Exception("Plateau Outside Error");
            }
        }
    }
}