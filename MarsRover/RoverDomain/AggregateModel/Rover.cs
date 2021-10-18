using RoverDomain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.AggregateModel
{
    public class Rover : RoverBaseEntity, IRover
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Command { get; set; }
        public Position Position { get; set; }

        public Plateau Plateau { get; set; }

        public Rover(string name, string description, string command,Plateau plateau, Position position)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Command = command ?? throw new ArgumentNullException(nameof(command));
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Plateau = plateau;
        }

        public string StartNavigation()
        {
            foreach (var command in Command)
            {
                switch (command)
                {
                    case 'M':
                        MoveForward();
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    default:
                        new Exception("Invalid chracter");
                        break;
                }

                if ((Position.X <0 || Position.X > Plateau.EdgeX) || (Position.Y < 0 || Position.Y > Plateau.EdgeY))
                {
                    throw new Exception("Position must be grather than zero or less than plateau bounderies");
                }

            }

            return $"{Position.X}{Position.Y}{Position.Direction}";

        }

        private void RotateRight()
        {
            switch (Position.Direction)
            {
                case DirectionModel.N:
                    Position.Direction = DirectionModel.E;
                    break;
                case DirectionModel.S:
                    Position.Direction = DirectionModel.W;
                    break;
                case DirectionModel.W:
                    Position.Direction = DirectionModel.N;
                    break;
                case DirectionModel.E:
                    Position.Direction = DirectionModel.S;
                    break;
                default:
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (Position.Direction)
            {
                case DirectionModel.N:
                    Position.Direction = DirectionModel.W;
                    break;
                case DirectionModel.S:
                    Position.Direction = DirectionModel.E;
                    break;
                case DirectionModel.W:
                    Position.Direction = DirectionModel.S;
                    break;
                case DirectionModel.E:
                    Position.Direction = DirectionModel.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveForward()
        {
            switch (Position.Direction)
            {
                case DirectionModel.N:
                    Position.Y++;
                    break;
                case DirectionModel.S:
                    Position.Y--;
                    break;
                case DirectionModel.W:
                    Position.X--;
                    break;
                case DirectionModel.E:
                    Position.X++;
                    break;
                default:
                    break;
            }
        }
    }
}
