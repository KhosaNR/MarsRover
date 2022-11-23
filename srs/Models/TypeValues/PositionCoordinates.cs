using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TypeValues
{
    public class PositionCoordinates
    {
        public int X_Position;
        public int Y_Position;

        public PositionCoordinates Clone()
        {
            return (PositionCoordinates)this.MemberwiseClone();
        }
    }
}
