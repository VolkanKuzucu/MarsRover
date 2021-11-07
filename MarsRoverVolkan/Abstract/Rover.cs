using System;
using System.Threading.Tasks;
using MarsRoverVolkan.Abstract.Interface;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;

namespace MarsRoverVolkan.Abstract
{
    public class Rover : IRover
    {
        private readonly IPlateauFactory _plateauFactory;

        public Coordinate RoverCoordinate { get; set; }

        public Direction RoverDirection { get; set; }

        public Response<bool> Process(string command)
        {
            foreach (var cmd in command)
            {
                switch (cmd)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        return ErrorMessageCodesEnum.InvalidCommand.Error<bool>();
                        throw new Exception($"Invalid Command {cmd}");
                }
            }

            return true.Ok();
        }

        public Rover(IPlateauFactory plateauFactory, Coordinate roverCoordinate, Direction roverDirection)
        {
            _plateauFactory = plateauFactory;
            RoverCoordinate = roverCoordinate;
            RoverDirection = roverDirection;
        }

        private void TurnLeft()
        {
            RoverDirection = (RoverDirection - 1) < Direction.N ? Direction.W : RoverDirection - 1;
        }

        private void TurnRight()
        {
            RoverDirection = (RoverDirection + 1) > Direction.W ? Direction.N : RoverDirection + 1;
        }

        private void Move()
        {
            switch (RoverDirection)
            {
                case Direction.N:
                    RoverCoordinate.Y++;
                    RoverCoordinate.Check(_plateauFactory.Coordinate);
                    break;
                case Direction.E:
                    RoverCoordinate.X++;
                    RoverCoordinate.Check(_plateauFactory.Coordinate);
                    break;
                case Direction.S:
                    RoverCoordinate.Y--;
                    RoverCoordinate.Check(_plateauFactory.Coordinate);
                    break;
                case Direction.W:
                    RoverCoordinate.X--;
                    RoverCoordinate.Check(_plateauFactory.Coordinate);
                    break;
                default:
                    throw new Exception
                        ("Unrecognized value.");
            }
        }
    }
}