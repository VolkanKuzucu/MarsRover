using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;

namespace MarsRoverVolkan.Abstract.Interface
{
    public interface IPlateauFactory
    {
        public Response<Coordinate> CreatePlateau(Coordinate coordinate);

        public Coordinate Coordinate { get;}
    }
}