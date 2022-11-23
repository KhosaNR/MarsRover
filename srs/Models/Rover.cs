using Models.TypeValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rover
    {
        public PositionCoordinates Position { get; set; }
        public CompassDirection Direction { get; set; }

        public Rover(int xPosition, int yPosition, char direction)
        {
            Position = new() { X_Position=xPosition,Y_Position=yPosition};
            CompassDirection _direction;
            if(!Enum.TryParse(direction.ToString(), out _direction))
            {
                throw new ArgumentException($"Invalid direction given : '{direction}'.");
            }
            Direction = _direction;
        }

        public void TurnLeft()
        {
            ChangeDirection(false);
        }

        public void TurnRight()
        {
            ChangeDirection(true);
        }

        private void ChangeDirection(bool clockwise = true)
        {
            int clockwiseInt = clockwise ? 1 : -1;
            Direction = (CompassDirection) Math.Abs(((int)Direction + clockwiseInt+4) % 4);
        }

        private PositionCoordinates Move(PositionCoordinates position, CompassDirection direction)
        {
            //Get postion faced
            switch (direction)
            {
                case CompassDirection.N:
                    return MoveNorth(position);
                    //break;
                case CompassDirection.E:
                    return MoveEast(position);
                    //break;
                case CompassDirection.S:
                    return MoveSouth(position);        
                     //break;
                case CompassDirection.W:
                    return MoveWest(position);
                    //break;
                default:
                    throw new Exception($"Tried moving to an unknown direction. {direction.ToString()}");
                    //break;
            }
        }

        public PositionCoordinates GetNextPositionIfMoved()
        {
            return Move(Position.Clone(), Direction);
        }

        public void Move()
        {
            Position = GetNextPositionIfMoved();
        }

        private PositionCoordinates MoveNorth(PositionCoordinates position)
        {
            position.Y_Position++;
            return position;
        }

        private PositionCoordinates MoveSouth(PositionCoordinates position)
        {
            position.Y_Position--;
            return position;
        }

        private PositionCoordinates MoveEast(PositionCoordinates position)
        {
            position.X_Position++;
            return position;
        }

        private PositionCoordinates MoveWest(PositionCoordinates position)
        {
            position.X_Position--;
            return position;
        }
         
        public void Turn(InstructionsAction side)
        {
            if (side == InstructionsAction.L)
            {
                TurnLeft();
            }
            else if (side == InstructionsAction.R)
            {
                TurnRight();
            }
            else
            {
                throw new Exception($"Given turn direection invalid : {side.ToString()}");
            }

        }
    }
}
