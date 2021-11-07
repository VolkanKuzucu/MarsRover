using MarsRoverVolkan.Abstract;
using MarsRoverVolkan.Abstract.Interface;
using MarsRoverVolkan.Enums;
using MarsRoverVolkan.Extensions;
using MarsRoverVolkan.Models;
using Ploeh.AutoFixture;
using Xunit;

namespace Test.Abstract
{
    public class PlateauFactoryTest
    {
        private readonly IPlateauFactory _plateauFactory;
        private readonly Coordinate _coordinate;
        
        public PlateauFactoryTest()
        {
            var fixture = new Fixture();
            _coordinate = fixture.Create<Coordinate>();
            _plateauFactory = new PlateauFactory(_coordinate);
        }
        
        [Fact]
        public void CreatePlateau_CoordinateIsGreaterThanZero_Test()
        {
            var plateau = _plateauFactory.CreatePlateau(_coordinate);
            Assert.True(plateau.IsSuccess);
        }
        
        [Fact]
        public void CreatePlateau_CoordinatesIsNotLessThanZero_Test()
        {
            var coordinate = new Coordinate
            {
                X = -2,
                Y = 3
            };
            var actual = _plateauFactory.CreatePlateau(coordinate);
            var expected = ErrorMessageCodesEnum.CoordinateIsLessThanZero.Error<Coordinate>();
            Assert.Equal(expected.Message, actual.Message);
            Assert.Equal(expected.IsSuccess, actual.IsSuccess);
        }
    }
}