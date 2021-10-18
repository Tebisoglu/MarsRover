using RoverApplication.EventHandlers;
using RoverDomain.AggregateModel;
using RoverDomain.AggregateModel.CommandSender;
using RoverDomain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EarthCommandSenderPanel
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please Enter Plateau Size!");
            Console.WriteLine("Please Enter Plateau EdgeX = ");
            int edgeX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Plateau EdgeY = ");
            int edgeY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Starting position!");
            Console.WriteLine("Please Enter Starting X position = ");
            int positionX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Starting Y position = ");
            int positionY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Starting Direction position");
            Enum.TryParse(Console.ReadLine().ToUpper(), out DirectionModel direction);
            Console.WriteLine("Please Enter Command Letters");
            string commands = Console.ReadLine().ToUpper();
            
            StartRoverNavigationDomainEvent domainEvent = new StartRoverNavigationDomainEvent(new CommandSender(commands, new Position(positionX, positionY, direction), new Plateau(edgeX, edgeY)));
            StartRoverNavigationDomainEventHandler eventHandler = new StartRoverNavigationDomainEventHandler();
            var  endingPosition = eventHandler.Handle(domainEvent, CancellationToken.None) as Task<string>;
           
            Console.WriteLine(string.Format("Target position  = {0}",endingPosition.Result));

        }
    }
}
