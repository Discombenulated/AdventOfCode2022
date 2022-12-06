namespace AdventOfCode.Day05;

public class StackList
{
    private Stack[] stacks;
    private string[] moves;

    public StackList(string[] input, int numStacks)
    {
        this.stacks = new Stack[numStacks];
        for (int i = 0; i < numStacks; i++){
            this.stacks[i] = new Stack();
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
                this.stacks[currentStackIndex].AddBottom(currentCrate);
            }
            lineIndex++;
        }

        this.moves = input.Skip(lineIndex).ToArray();
        MakeMoves();
    }

    protected void MakeMoves(){
        foreach (var move in moves){
            //"move 1 from 2 to 1"
            var split = move.Split(" ");
            var numCrates = int.Parse(split[1]);
            var sourceStack = int.Parse(split[3]);
            var destinationStack = int.Parse(split[5]);
            for (int i = 0; i < numCrates; i++){
                var crate = this.stacks[sourceStack-1].Remove();
                this.stacks[destinationStack-1].Add(crate);
            }
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