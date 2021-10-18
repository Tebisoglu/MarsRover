using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverDomain.SeedWork
{
    public class CommandSenderBaseEntity
    {
        public int Id { get; set; }
        public ICollection<INotification> senderEvents { get; set; }
        public void AddDomainEvents(INotification notification)
        {
            senderEvents = new List<INotification>();
            senderEvents.Add(notification);
        }
    }
}
