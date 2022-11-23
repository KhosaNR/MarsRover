using Models.TypeValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Plateau
    {
        public int LowBound { get; set; } = 0;
        public int LeftBound { get; set; } = 0;
        public int RightBound { get; set; }
        public int UpBound { get; set; }
        public List<Rover> Rovers;

        public Plateau(int up, int right)
        {
            UpBound = up;
            RightBound = right;
            Rovers = new List<Rover>();
        }

        public void AddAndMoveRover(int xPosition, 
                                    int yPosition, 
                                    char direction, 
                                    string movementInstructions)
        {
            var rover = new Rover(xPosition, yPosition, direction);
            AddRover(rover);
            MoveLastAddedRover(movementInstructions);
        }

        public ReturnResults AddRover(Rover rover)
        {
            var results = new ReturnResults();
            if(RoverCanBePlacedInPosition(rover.Position, out results))  
                Rovers.Add(rover);
            return results;
        }

        public void MoveLastAddedRover(string movementInstructions)
        {
            //Get last item
            //Move it
            //Get it back to the list? change it while it is on the list
            if (Rovers.Count == 0)
            {
                throw new Exception("There are no rovers no move.");
            }

            var rover = Rovers.LastOrDefault();
            if(rover == null)
            {
                throw new Exception("Last rover is invalid");
            }
            var lastRoverIndex = Rovers.Count() - 1;
            Rovers[lastRoverIndex] = MoveRover(rover, movementInstructions);
        }

        public Rover MoveRover(Rover rover, string movementInstructions)
        {
            //Apply all instructions to rover
            try
            {
                foreach (var instructionChar in movementInstructions)
                {
                    InstructionsAction instructionAct;
                    if (!Enum.TryParse(instructionChar.ToString(), out instructionAct))
                    {
                        throw new Exception($"Invalid instruction given: '{instructionChar}' .");
                    }
                    if (instructionAct == InstructionsAction.L || instructionAct == InstructionsAction.R)
                    {
                        rover.Turn(instructionAct);
                    }
                    if (instructionAct == InstructionsAction.M)
                    {
                        ReturnResults results;
                        if (!RoverCanMoveForward(rover, out results))
                        {
                            break;
                        }
                        rover.Move();
                    }
                }
            }
            catch (Exception e)
            {
                //Should log exception message but return the final position.
                return rover;
            }
            return rover;
        }

        public bool RoverCanMoveForward(Rover rover, out ReturnResults results)
        {
            //calculate new position
            //Check if edge has been reached;
            //check if another rover has occupied the space
            
            var roverNextPosition = rover.GetNextPositionIfMoved();
            return RoverCanBePlacedInPosition(roverNextPosition, out results);
        }

        private bool RoverCanBePlacedInPosition(PositionCoordinates roverPosition, out ReturnResults results)
        {
            results = new();
            if (!RoverPositionIsInsideBoundaries(roverPosition.X_Position, roverPosition.Y_Position))
            {
                results.AddNew(new Result(ResultType.Fail, "Cannot move to this position because rover will be out of plateau bounds."));
                return false;
            }

            if (PositionOccupiedByRover(roverPosition.X_Position, roverPosition.Y_Position))
            {
                results.AddNew(new Result(ResultType.Fail, "Cannot move to this position because another rover already occupies it."));
                return false;
            }
            return true;
        }

        private bool RoverPositionIsInsideBoundaries(int rover_xPosition, int rover_yPosition)
        {
            if (rover_xPosition < LeftBound) return false;
            if (rover_xPosition > RightBound) return false;
            if (rover_yPosition < LowBound) return false;
            if (rover_yPosition > UpBound) return false;
            return true;
        }

        private bool PositionOccupiedByRover(int rover_xPosition, int rover_yPosition)
        {
            //Checks if a rover in the plateau occu[ies the given position
            return Rovers.Any(r => r.Position.X_Position == rover_xPosition
                && r.Position.Y_Position == rover_yPosition);
           
        }
    }
}
