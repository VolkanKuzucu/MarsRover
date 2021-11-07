using System;
using MarsRoverVolkan.Abstract.Interface;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;

namespace MarsRoverVolkan.Abstract
{
    public class PlateauFactory : IPlateauFactory
    {
        private readonly Coordinate _coordinate;

        public PlateauFactory(Coordinate coordinate)
        {
            var result = CreatePlateau(coordinate);
            if (result.IsSuccess)
            {
                _coordinate = result.Result;
                Console.WriteLine($"Plateau Created : {_coordinate.X} {_coordinate.Y}");
            }
            else
            {
                throw new Exception("Plateau Coordinates Is Must Greater Than Zero");
            } 
        }

        public Response<Coordinate> CreatePlateau(Coordinate coordinate)
        {
            if (coordinate.X <= 0 || coordinate.Y <= 0)
                // return new Exception("Plateau Coordinates Is Must Greater Than Zero");
                return ErrorMessageCodesEnum.CoordinateIsLessThanZero.Error<Coordinate>();
            var plateau = new Coordinate
            {
                X = coordinate.X,
                Y = coordinate.Y
            };
            return plateau.Ok();
        }

        Coordinate IPlateauFactory.Coordinate => _coordinate;
    }
}