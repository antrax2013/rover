
using RoverConsole.Tracing;

new RoverEventListner();

Console.Write("To test CI/CD workflow");

Console.WriteLine("Welcome to rover exploration");
Console.WriteLine("Define the area :");

var info = (Console.ReadLine() ?? "").Trim();

if (!String.IsNullOrEmpty(info))
{
    RoverEventSource.Instance.StartInitialization(info);

    while (!String.IsNullOrEmpty(info)) {
        Console.WriteLine("Give rover parameters : [ X : X coordinate, Y : Y coordinate, D : direction { N, E, S, W} ]");
        info = (Console.ReadLine() ?? "").Trim();

        if (!string.IsNullOrWhiteSpace(info))
        {
            RoverEventSource.Instance.AddRover(info);
        }
        else continue;

        Console.WriteLine("Give rover commands : [M : move, L : turn left, R : turn right");
        info = (Console.ReadLine() ?? "").Trim();

        if (!string.IsNullOrWhiteSpace(info))
        {
            RoverEventSource.Instance.AddCommands(info);
        }
    }

    RoverEventSource.Instance.Run();
}
RoverEventSource.Instance.ExplorationCompleted();
Console.WriteLine("Exploration completed");
return 0;

