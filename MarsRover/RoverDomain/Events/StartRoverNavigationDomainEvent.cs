using MediatR;
using RoverDomain.AggregateModel.CommandSender;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.Events
{
    public class StartRoverNavigationDomainEvent : INotification
    {
        public CommandSender CommandSender { get; set; }

        public StartRoverNavigationDomainEvent(CommandSender commandSender)
        {
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
        }
    }
}
