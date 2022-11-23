using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsTests
{
    public static class InputSimulator
    {
        static string inputString = "5 5\r\n\r\n1 2 N\r\n\r\nLMLMLMLMM\r\n\r\n3 3 E\r\n\r\nMMRMMRMRRM";
        public static string expectedOutput = "1 3 N\r\n\r\n5 1 E";
        public static string[] InputLines = inputString.Split("\r\n\r\n");

        public static string ExtractPlateauBoundsString()
        {
            return InputLines[0];
        }
    }
}
