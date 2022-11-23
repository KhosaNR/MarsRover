# MarsRover
Running the project:
 
 1. Clone the Git repo
 2. Open the Solution
 3. Restore nugget packages (Tests use the MSTest nugget packages)
 4. Run the tests
 


Assumptions:

A move is 1 unit
East: (x,y) => (x+1,y)
Two rovers cannot share the same position, if one rover is given instruction to move to where another rover is 
positioned then it will stop and not continue (throw an exception)
Negative positions of a rover are allowed as long as they are withing the bounds of the plateau.

Solution approach:

1. Add a rover on a plateau
	The direction of the rover is validated, also, if positions are not valid integers then exceptions will be thrown
	When adding a new rover on the plateau, check if it is within the plateau bounds and also if another rover does not occupy it's place.
2. Move the rover as per the given instructions
	Break the instructions into single instructions and move/turn as requested,
	First check if the location to move to is valid(not out of bound and not taken by another rover)
	Each instruction is validated before moving and if the instruction is invalid then an exception will be thrown
	

Functionality:

There are 2 classes
	1. Rover class for the rover object
		which uses the value types CompassDirection and PositionCoordinates
		To create a rover, one needs the x position, y position and direction the rover faces
		There are functions for turning the rover left/ right and moving the rover with respect to the direction faced.
		Moving the rover will increment/decrease the position according to the direction faced.
		
	2. Plateau class for the plateau object which has it's bounds and also a list of rovers
		A new rover can be added and then a function to move the last rover will move the last rover.
	
	The result pattern is used at times. This helps with making sure the functionality can continue while keeping tabs of the results obtained by running certain functions.
	
	Different value types are available
	1. Return results (Result pattern) 
	2. CompassDirection an enum that stores compass directions North (N), East (E), South (S), West (W)
	3. InstructionsAction an enum for the instructions (Left,Right,Move)
	4. PositionCoordinates for x and y positions of the rover

Tests:
Unit tests have been written using MSTest.
 
 ---------------------
 
 The project has no user interface/API but unit tests are written to test functionality.
 The class named TestScenarioCreator is used for setting up a bit of complex test scenarios.
 The class named InputSimulator is used to simulate input via string and also provides an excepted output for the given input.
 The TestScenarioCreator uses InputSimulator for setting up test data which is used in the function named
 
 The following test run the examples given in the challange:
 GivenPlateauWithOneRover_When_AddingANewRoverAndInstructions_Then_RoverMoves
 GivenPlateauWithoutRovers_When_AddingANewRoverBasedOnStringInpu_Then_OutputMatches
