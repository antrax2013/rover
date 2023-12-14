using System.Diagnostics.Tracing;

namespace RoverConsole.Tracing
{
    [EventSource(Name ="Rover-Exploration")]
    internal sealed class RoverEventSource : EventSource
    {
        public static RoverEventSource Instance { get; } = new();

        public RoverEventSource() { }

        [Event(1, Level = EventLevel.Informational, Message = "New exploration started")]
        public void StartInitialization(string values) => WriteEvent(1, values);

        [Event(2, Level = EventLevel.Informational, Message = "Add new rover")]
        public void AddRover(string values) => WriteEvent(2, values);

        [Event(3, Level = EventLevel.Informational, Message = "Add commands")]
        public void AddCommands(string values) => WriteEvent(3, values);

        [Event(4, Level = EventLevel.Informational, Message = "Exploration running")]
        public void Run()=> WriteEvent(4);

        [Event(5, Level = EventLevel.Informational, Message = "Exploration completed")]
        public void ExplorationCompleted() => WriteEvent(5);
    }
}
