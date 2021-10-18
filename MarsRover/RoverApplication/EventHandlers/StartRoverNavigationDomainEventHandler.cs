using MediatR;
using RoverDomain.AggregateModel;
using RoverDomain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoverApplication.EventHandlers
{
    public class StartRoverNavigationDomainEventHandler : INotificationHandler<StartRoverNavigationDomainEvent>
    {
        public Task Handle(StartRoverNavigationDomainEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                string endPozition = string.Empty;
                if (notification != null)
                {
                    if (notification.CommandSender != null)
                    {
                        var commandSender = notification.CommandSender;
                        var rover = new Rover("Perseverance", "Seek signs of ancient life",  commandSender.Command, commandSender.Plateau, commandSender.StartingPozition);
                        endPozition = rover.StartNavigation();
                    }
                   
                }

                return Task.FromResult(endPozition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
