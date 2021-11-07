using MarsRoverVolkan.Abstract;
using MarsRoverVolkan.Abstract.Interface;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;
using Moq;
using Ploeh.AutoFixture;
using Xunit;

namespace Test.Abstract
{
    public class RoverTest
    {
        private readonly IRover _rover;
        private readonly Coordinate _coordinate;
        private readonly Direction _direction;
        private Response<Coordinate> _plateauCoordinate;
        private readonly Mock<IPlateauFactory> _plateauFactory;

        public RoverTest()
        {
            var fixture = new Fixture();
            _coordinate = fixture.Create<Coordinate>();
            _plateauCoordinate = fixture.Create<Response<Coordinate>>();
            _direction = fixture.Create<Direction>();
            _plateauFactory = new Mock<IPlateauFactory>(MockBehavior.Strict);
            _rover = new Rover(_plateauFactory.Object, _coordinate, _direction);
        }

        [Fact]
        public void Rover_FalseProcess_Test()
        {
            var actual = _rover.Process("G");
            var expected = ErrorMessageCodesEnum.CoordinateIsLessThanZero.Error<bool>();;
            
            Assert.Equal(expected.IsSuccess,actual.IsSuccess);
        }
        
        [Fact]
        public void Rover_LeftCommandProcess_Test()
        {
            var actual = _rover.Process("L");
            var expected = true;

            Assert.Equal(expected,actual.IsSuccess);
        }
        
        [Fact]
        public void Rover_RightCommandProcess_Test()
        {
            var actual = _rover.Process("R");
            var expected = true;

            Assert.Equal(expected,actual.IsSuccess);
        }
    }
}