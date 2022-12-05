namespace AdventOfCode.Day05;

public class StackList9001
{
    private Stack[] stacks;

    public StackList9001(string[] input, int numStacks)
    {
        stacks = new Stack[numStacks];
        for (int i = 0; i < numStacks; i++){
            stacks[i] = new Stack();
        }

        int lineIndex = 0;
        foreach (var inputLine in input){
            if (!inputLine.Contains("[")) { 
                lineIndex+=2;
                break;
            }
            for (int i = 0; i < inputLine.Length; i+=4){
                var currentCrate = inputLine.Substring(i, 3);
                if (String.IsNullOrWhiteSpace(currentCrate)) {
                    continue;
                }
                var currentStackIndex = i / 4;
                stacks[currentStackIndex].AddBottom(currentCrate);
            }
            lineIndex++;
        }

        string[] moves = input.Skip(lineIndex).ToArray();
        foreach (var move in moves){
            //"move 1 from 2 to 1"
            var split = move.Split(" ");
            var numCrates = int.Parse(split[1]);
            var sourceStack = int.Parse(split[3]);
            var destinationStack = int.Parse(split[5]);
            var crates = stacks[sourceStack-1].Remove(numCrates);
            stacks[destinationStack-1].Add(crates);
        }
    }

    public string TopCrates()
    {
        var result = "";
        foreach(var stack in stacks){
            result += stack.TopCrate();
        }
        return result;
    }
}