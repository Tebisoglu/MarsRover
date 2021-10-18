using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverApplication.EventHandlers;
using RoverDomain.AggregateModel;
using RoverDomain.AggregateModel.CommandSender;
using RoverDomain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverInputTest
    {
        [TestMethod]
        public void Check_StartingPozition_12N_And_CommandStirng_LMLMLMLMM()
        {
            var plateau = new Plateau(5, 5);
            var startingPozition = new Position(1, 2, DirectionModel.N);
            string commands = "LMLMLMLMM";
            StartRoverNavigationDomainEvent domainEvent = new StartRoverNavigationDomainEvent(new CommandSender(commands, startingPozition, plateau));
            StartRoverNavigationDomainEventHandler eventHandler = new StartRoverNavigationDomainEventHandler();
            var endingPozition = eventHandler.Handle(domainEvent, CancellationToken.None) as Task<string>;

            var expectedPosition = "13N";

            Assert.AreEqual(endingPozition.Result, expectedPosition);

        }

        [TestMethod]
        public void Check_StartingPozition_33E_And_CommandStirng_MMRMMRMRRM()
        {
            var plateau = new Plateau(5, 5);
            var startingPozition = new Position(3, 3, DirectionModel.E);
            string commands = "MMRMMRMRRM";
            StartRoverNavigationDomainEvent domainEvent = new StartRoverNavigationDomainEvent(new CommandSender(commands, startingPozition, plateau));
            StartRoverNavigationDomainEventHandler eventHandler = new StartRoverNavigationDomainEventHandler();
            var endingPozition = eventHandler.Handle(domainEvent, CancellationToken.None) as Task<string>;

            var expectedPosition = "51E";

            Assert.AreEqual(endingPozition.Result, expectedPosition);

        }
    }
}
