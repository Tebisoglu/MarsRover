using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.AggregateModel
{
    public class Plateau
    {
        public int EdgeX { get; set; }
        public int EdgeY { get; set; }

        public Plateau(int edgeX, int edgeY)
        {
            if (edgeX <= 0 || edgeY <= 0)
            {
                throw new Exception("Plateau edges size must be grather than zero");
            }
            EdgeX = edgeX;
            EdgeY = edgeY;
        }
    }
}
