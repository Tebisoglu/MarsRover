using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.SeedWork
{
    public class RoverBaseEntity
    {
        public int Id { get; set; }
        ICollection<INotification> roverEvents { get; set; }
        ICollection<INotification> RoverEvents => roverEvents;
        
        public void AddRoverEvents(INotification notification)
        {
            roverEvents = new List<INotification>();
            roverEvents.Add(notification);
        }
    }
}
