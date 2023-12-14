using Rover;
using Rover.Directions;
using System.Diagnostics.Tracing;

namespace RoverConsole.Tracing
{
    internal class RoverEventListner : EventListener
    {
        private RoverSimulationFactory? _roverSimulationFactory;
        private Queue<EventWrittenEventArgs> _queue = new();
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Rover-Exploration")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventId > 0)
            {
                if (eventData.EventId < 4) _queue.Enqueue(eventData);
                if (eventData.EventId == 4) RunSimulation();
                if(eventData.EventId == 5) CompleteSimulation();
            }
        }

        private void CompleteSimulation()
        {
            _roverSimulationFactory = null;
            _queue = new();
        }

        private void InitRoverSimulation(string coordinates) { 
            var infos = coordinates.Split(' ');
            ushort x = Convert.ToUInt16(infos[0]);
            ushort y = Convert.ToUInt16(infos[1]);

            _roverSimulationFactory = new RoverSimulationFactory(new Coordinate(x, y));
        }

        private void AddRover(string roverInfo, string instructions)
        {
            if (_roverSimulationFactory == null)
                throw new InvalidProgramException("Simulation not initialized");

            var infos = roverInfo.Split(' ');
            ushort x = Convert.ToUInt16(infos[0]);
            ushort y = Convert.ToUInt16(infos[1]);
            IDirection direction = _roverSimulationFactory.GetDirection(infos[2].ToCharArray()[0]);

            _roverSimulationFactory.AddRover(new Vehicule.Rover(new Coordinate(x, y), direction), instructions);
        }

        private void RunSimulation() {
            try
            {
                EventWrittenEventArgs? e = null;
                _queue.TryDequeue(out e);
                string? previous = null;

                while (e != null)
                {
                    var value = e.Payload.ToList().First().ToString();

                    if (string.IsNullOrEmpty(value))
                        continue;

                    switch (e.EventId)
                    {
                        case 1:
                            InitRoverSimulation(value);
                            break;
                        case 2:
                            previous = value;
                            break;
                        case 3:
                            if (previous != null)
                            {
                                AddRover(previous, value);
                                previous = null;
                            }
                            else throw new InvalidOperationException("No rover given previously.");
                            break;

                    }

                    _queue.TryDequeue(out e);
                }

                var results = _roverSimulationFactory?.Run();

                foreach (var item in results)
                {
                    Console.WriteLine($"{item.Item1} {item.Item2} {item.Item3}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured : {ex.Message}");
            }
        }
    }

}
