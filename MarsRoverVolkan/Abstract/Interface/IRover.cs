using System.Threading.Tasks;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;

namespace MarsRoverVolkan.Abstract.Interface
{
    public interface IRover
    {
        public Coordinate RoverCoordinate { get; set; }
        
        public Direction RoverDirection { get; set; }

        public Response<bool> Process(string command);
    }
}