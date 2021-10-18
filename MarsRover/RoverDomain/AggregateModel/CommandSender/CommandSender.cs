using RoverDomain.Events;
using RoverDomain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.AggregateModel.CommandSender
{
    public class CommandSender : CommandSenderBaseEntity
    {
        public string Command { get; set; }
        public Position StartingPozition { get; set; }

        public Plateau Plateau { get; set; }

        public CommandSender(string command, Position startingPozition,Plateau plateau)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
            StartingPozition = startingPozition ?? throw new ArgumentNullException(nameof(startingPozition));
            Plateau = plateau ?? throw new ArgumentNullException(nameof(plateau));
            AddDomainEvents(new StartRoverNavigationDomainEvent(this));
        }
    }
}
