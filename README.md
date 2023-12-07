# The Mars Rover Kata
[see mars-rover-kata ](https://github.com/DanilSuits/mars-rover-kata)

## Inputs
Test Input:
```
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```

Test Output:
```
1 3 N
5 1 E
```

# Objective
- test coverage : 100% 
- mutation score : 100%
- have fun writing code

For the kata is use :
- .Net 8.0
- Nunit
- test coverage : https://github.com/coverlet-coverage/coverlet
- report generator : https://github.com/danielpalme/ReportGenerator
- stryker mutator .Net : https://github.com/stryker-mutator/stryker-net

# Branches :
- master : completed Kata 
- [instrumentalized](https://github.com/antrax2013/rover/tree/instrumentalized-tests) : branche with test coverage, report generator and stryker mutator setted
- [fix-instrumentalized-tests](https://github.com/antrax2013/rover/tree/fix-instrumentalized-tests): branch with a mutation score 100%


# Results
# Mutation Testing Summary

| File                                     | Score   | Killed | Survived | Timeout | No Coverage | Ignored | Compile Errors | Total Detected | Total Undetected | Total Mutants |
| ---------------------------------------- | ------- | ------ | -------- | ------- | ----------- | ------- | -------------- | -------------- | ---------------- | ------------- |
| Coordinate.cs                            | N\/A    | 0      | 0        | 0       | 0           | 0       | 0              | 0              | 0                | 0             |
| Directions\\East.cs                      | 100,00% | 5      | 0        | 0       | 0           | 1       | 0              | 5              | 0                | 6             |
| Directions\\FourCardinalDirections.cs    | 100,00% | 1      | 0        | 0       | 0           | 1       | 0              | 1              | 0                | 2             |
| Directions\\IDirection.cs                | N\/A    | 0      | 0        | 0       | 0           | 0       | 0              | 0              | 0                | 0             |
| Directions\\North.cs                     | 100,00% | 5      | 0        | 0       | 0           | 1       | 0              | 5              | 0                | 6             |
| Directions\\South.cs                     | 100,00% | 5      | 0        | 0       | 0           | 1       | 0              | 5              | 0                | 6             |
| Directions\\West.cs                      | 100,00% | 5      | 0        | 0       | 0           | 1       | 0              | 5              | 0                | 6             |
| Exceptions\\InvalidArguementException.cs | N\/A    | 0      | 0        | 0       | 0           | 0       | 0              | 0              | 0                | 0             |
| Rover.cs                                 | 100,00% | 8      | 0        | 0       | 0           | 3       | 0              | 8              | 0                | 11            |
| RoverCommands\\ARoverRotationCommand.cs  | N\/A    | 0      | 0        | 0       | 0           | 0       | 0              | 0              | 0                | 0             |
| RoverCommands\\IRoverCommand.cs          | N\/A    | 0      | 0        | 0       | 0           | 0       | 0              | 0              | 0                | 0             |
| RoverCommands\\MoveCommand.cs            | 100,00% | 3      | 0        | 0       | 0           | 1       | 0              | 3              | 0                | 4             |
| RoverCommands\\TurnLeftRoverCommand.cs   | 100,00% | 1      | 0        | 0       | 0           | 1       | 0              | 1              | 0                | 2             |
| RoverCommands\\TurnRightRoverCommand.cs  | 100,00% | 1      | 0        | 0       | 0           | 1       | 0              | 1              | 0                | 2             |
| RoverController.cs                       | 100,00% | 7      | 0        | 0       | 0           | 5       | 0              | 7              | 0                | 12            |
| RoverSimulationFactory.cs                | 100,00% | 11     | 0        | 0       | 0           | 5       | 0              | 11             | 0                | 16            |

## The final mutation score is 100,00%

### *Coverage Thresholds: high:80 low:60 break:0*
