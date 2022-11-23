using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsTests
{
    public static class TestScenarioCreator
    {
        public static Plateau CreatePlateauFromInputString()
        {
            var plateauBounds = InputSimulator.ExtractPlateauBoundsString().Split(' ');
            var plateau = new Plateau(int.Parse(plateauBounds[0]), int.Parse(plateauBounds[1]));
            return plateau;
        }

        public static Plateau AddRoversAndMove(Plateau plateau)
        {
            for (int i = 1; i < InputSimulator.InputLines.Length; i++)
            {
                if (i % 2 != 0)
                {
                    //create rover
                    var roverParameters = InputSimulator.InputLines[i].Split(' ');
                    var rover = new Rover(int.Parse(roverParameters[0]), int.Parse(roverParameters[1]), char.Parse(roverParameters[2]));
                    plateau.AddRover(rover);
                }
                else
                {
                    var instructionString = InputSimulator.InputLines[i];
                    plateau.MoveLastAddedRover(instructionString);
                }
            }
            return plateau;
        }

        public static string GetRovesInStringFormat(Plateau plateau)
        {
            string roversInStringFormat = "";
            foreach(var rover in plateau.Rovers)
            {
                roversInStringFormat += rover.Position.X_Position + " " +
                                rover.Position.Y_Position + " " +
                                rover.Direction.ToString();
                roversInStringFormat += "\r\n\r\n";
            }
            roversInStringFormat = roversInStringFormat.TrimEnd();
            return roversInStringFormat;
        }

    }
}
