using Models.TypeValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsTests
{
    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void GivenPlateauHasOneRover_When_MovingToAvailblePosition_Then_CanMoveFowardIsTrueAndReturnResultsIsOk()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(0, 0, 'N');
            var returnResults = new ReturnResults();


            // Act
            var roverCanMoveForard = plateau.RoverCanMoveForward(rover, out returnResults);

            // Assert
            Assert.AreEqual(true, roverCanMoveForard);
            Assert.AreEqual(true, returnResults.IsOk());
        }

        [TestMethod]
        public void GivenPlateauHasOneRover_When_CheckingAvailblePosition_Then_RoverPositionAndDirectionHasNotChanged()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(4, 3, 'S');
            var returnResults = new ReturnResults();


            // Act
            var roverCanMoveForard = plateau.RoverCanMoveForward(rover, out returnResults);

            // Assert
            Assert.AreEqual(4, rover.Position.X_Position);
            Assert.AreEqual(3, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.S, rover.Direction);
        }

        [TestMethod]
        public void GivenPlateauHasNoRover_When_AddingANewRoverToAvailblePosition_Then_RoverIsPositioned()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var returnResults = new ReturnResults();


            // Act
            var rover = new Rover(4, 3, 'S');
            plateau.AddRover(rover);

            // Assert
            Assert.AreEqual(4, rover.Position.X_Position);
            Assert.AreEqual(3, rover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.S, rover.Direction);
            Assert.AreEqual(1, plateau.Rovers.Count);
        }

        [TestMethod]
        public void GivenPlateauHasOneRover_When_AddingANewRoverToTakenPosition_Then_RoverIsNotPositioned()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(4, 3, 'S');
            var rover2 = new Rover(4, 3, 'E');
            var returnResults = new ReturnResults();


            // Act
            plateau.AddRover(rover);
            plateau.AddRover(rover2);

            // Assert
            Assert.AreEqual(1, plateau.Rovers.Count);
        }

        [TestMethod]
        public void GivenPlateauHasOneRover_When_AddingANewRoverToAvailablePosition_Then_RoverIsPositionedAndAddedToListOfRovers()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(4, 3, 'S');
            var rover2 = new Rover(2, 1, 'W');
            var returnResults = new ReturnResults();


            // Act
            plateau.AddRover(rover);
            plateau.AddRover(rover2);

            // Assert
            Assert.AreEqual(2, plateau.Rovers.Count);
        }

        [TestMethod]
        public void GivenPlateauHasOneRover_When_AddingANewRoverToTakenPosition_Then_ResultsIsNotOK()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(4, 3, 'S');
            plateau.AddRover(rover);
            var rover2 = new Rover(4, 3, 'W');
            var returnResults = new ReturnResults();
            const string failureMessage = "Cannot move to this position because another rover already occupies it.";


            // Act
            var results = plateau.AddRover(rover2);

            // Assert
            Assert.AreEqual(false, results.IsOk());
            Assert.AreEqual(failureMessage, results.Results.FirstOrDefault().Message);
        }

        [TestMethod]
        public void GivenPlateauWithoutRovers_When_AddingANewRoverBasedOnStringInpu_Then_OutputMatches()
        {
            // Arrange
            var plateau = TestScenarioCreator.CreatePlateauFromInputString();

            // Act
            plateau = TestScenarioCreator.AddRoversAndMove(plateau);
            string outputString = TestScenarioCreator.GetRovesInStringFormat(plateau);

            // Assert

            Assert.AreEqual(InputSimulator.expectedOutput, outputString);
        }


        [TestMethod]
        public void GivenPlateau_When_AddingANewRoverAndInstructions_Then_RoverMoves()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(1, 2, 'N');
            var instructions = "LMLMLMLMM";


            // Act
            plateau.AddRover(rover);
            plateau.MoveLastAddedRover(instructions);


            // Assert
            var MovedRover = plateau.Rovers.LastOrDefault();
            Assert.AreEqual(1, MovedRover.Position.X_Position);
            Assert.AreEqual(3, MovedRover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.N, MovedRover.Direction);
        }

        [TestMethod]
        public void GivenPlateauWithOneRover_When_AddingANewRoverAndInstructions_Then_RoverMoves()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(1, 2, 'N');
            var rover2 = new Rover(3, 3, 'E');
            var instructions = "LMLMLMLMM";
            var instructions2 = "MMRMMRMRRM";
            plateau.AddRover(rover);
            plateau.MoveLastAddedRover(instructions);


            // Act
            plateau.AddRover(rover2);
            plateau.MoveLastAddedRover(instructions2);


            // Assert
            var MovedRover = plateau.Rovers.LastOrDefault();
            Assert.AreEqual(5, MovedRover.Position.X_Position);
            Assert.AreEqual(1, MovedRover.Position.Y_Position);
            Assert.AreEqual(CompassDirection.E, MovedRover.Direction);
        }

    }
}
