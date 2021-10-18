using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.AggregateModel
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionModel Direction { get; set; }

        public Position()
        {
            X = 0;
            Y = 0;
            Direction = DirectionModel.N;
        }

        public Position(int x, int y, DirectionModel direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
