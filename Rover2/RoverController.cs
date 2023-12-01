using Rover.Direction;
using Rover.Exceptions;

namespace Rover
{
    public class RoverController
    {
        public readonly List<char> Instructions;
        public readonly Vehicule.Rover Rover;
        public readonly Dictionary<char, IDirection> Directions;
        private readonly List<char> _authorizedInstructions = ['L', 'R', 'M'];

        public RoverController(string instructions, Vehicule.Rover rover, Dictionary<char, IDirection> directions)
        {
            List<char> tmp = [.. instructions];

            foreach (var item in tmp.Distinct())
            {
                if (!_authorizedInstructions.Contains(item)) {
                    throw new InvalidArguementException($"The instruction {item} is not in the authorized instructions list");
                }
            }
            Instructions = [.. instructions];
            Rover = rover;
            Directions = directions;
        }

        public void Run() {
            Instructions.ForEach(instruction => { 
                switch (instruction)
                {
                    case 'L': Rover.LeftRotation(Directions[Rover.Direction.Previous]);
                        break;
                    case 'R':
                        Rover.RightRotation(Directions[Rover.Direction.Next]);
                        break;
                    case 'M':
                        Rover.Move();
                        break;
                }
                //Console.WriteLine(Rover.ToString());
            });            
        }
    }
}
