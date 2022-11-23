using Models.TypeValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void GivenCorrectParameters_When_Instantiate_RoverIsCreated()
        {
             // Arrange
            var xPosition = 0;
            var yPosition = 0;
            var Direction = 'N';

            // Act
            var rover = new Rover(xPosition,yPosition,Direction);

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.N, rover.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
             "Invalid direction given : 'X'.")]
        public void GivenIncorrectDirectionParameter_When_Instantiate_ExceptionIsThrown()
        {
            // Arrange
            var xPosition = 0;
            var yPosition = 0;
            var Direction = 'X';

            // Act
            var rover = new Rover(xPosition, yPosition, Direction);
        }

        [TestMethod]
        public void GivenRoverFacingNorth_When_TurnLeft_Then_DirectionIs_WEST_andPositionRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');

            // Act
            rover.TurnLeft();

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.W, rover.Direction);
        }

        [TestMethod]
        public void GivenRoverFacingNorth_When_TurnLeft4Times_Then_DirectionIs_NORTH_andPositionRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');

            // Act
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.N, rover.Direction);
        }

        [TestMethod]
        public void GivenRoverFacingNorth_When_TurnRight_Then_DirectionIs_EAST_andPositionRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');

            // Act
            rover.TurnRight();

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.E, rover.Direction);
        }

        [TestMethod]
        public void GivenRoverFacingNorth_When_Move_Then_YPOSITION_Is_Increment_andOthersRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');

            // Act
            rover.Move();

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(1, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.N, rover.Direction);
        }

        [TestMethod]
        public void GivenRoverFacingSouth_When_Move_Then_YPOSITION_Is_Reduced_andOthersRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(0, 1, 'S');

            // Act
            rover.Move();

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.S, rover.Direction);
        }

        [TestMethod]
        public void GivenRoverFacingEast_When_Move_Then_XPOSITION_Is_Increment_andOthersRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(0, 0, 'E');

            // Act
            rover.Move();

            // Assert
            Assert.AreEqual(1, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.E, rover.Direction);
        }

        [TestMethod]
        public void GivenRoverFacingWest_When_Move_Then_XPOSITION_Is_Reduced_andOthersRemainsTheSame()
        {
            // Arrange
            var rover = new Rover(1, 0, 'W');

            // Act
            rover.Move();

            // Assert
            Assert.AreEqual(0, rover.Position.X_Position);
            Assert.AreEqual(0, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.W, rover.Direction);
        }
    }
}
