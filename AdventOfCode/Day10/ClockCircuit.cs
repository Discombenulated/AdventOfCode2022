namespace AdventOfCode.Day10;

public class ClockCircuit
{
    private int startCycle;
    private int repeatCycle;

    private int currentCycle = 1;

    private int registerX = 1;

    private int totalSignalStrength;

    private List<string> displayLines;

    private int spritePosition;

    public ClockCircuit(int startCycle, int repeatCycle)
    {
        this.startCycle = startCycle;
        this.repeatCycle = repeatCycle;
    }

    public string[] Draw(string[] instructions)
    {
        currentCycle = 0;
        spritePosition = 0;
        displayLines = new List<string>();
        foreach (var instruction in instructions){
            if (instruction.Equals("noop")){
                completeDrawCycle();
            } else {
                var addX = int.Parse(instruction.Split(" ")[1]);
                completeDrawCycle();
                completeDrawCycle();
                registerX += addX;
            }
        }
        return displayLines.ToArray();
    }

    public double SignalStrength(string[] instructions)
    {
        totalSignalStrength = 0;
        foreach (var instruction in instructions){
            if (instruction.Equals("noop")){
                completeCycle();
            } else {
                var addX = int.Parse(instruction.Split(" ")[1]);
                completeCycle();
                completeCycle();
                registerX += addX;
            }
        }
        return totalSignalStrength;
    }

    private void completeCycle(){
        if ((currentCycle-startCycle) % repeatCycle == 0 ){
            totalSignalStrength += (currentCycle * registerX);
        }
        Console.WriteLine($"Cycle: {currentCycle}, totalSignalStength: {totalSignalStrength}");
        currentCycle++;
    }

    private void completeDrawCycle(){
        var currentCharIndex = (currentCycle-startCycle) % repeatCycle;
        var currentLineIndex = currentCycle / repeatCycle;
        if (displayLines.Count < currentLineIndex+1) {
            displayLines.Add("");
        }
        var line = displayLines[currentLineIndex];
        if (registerX+1 >= currentCharIndex && registerX-1 <= currentCharIndex ){
            
            displayLines[currentLineIndex] = line + "#";
        } else {
            displayLines[currentLineIndex] = line + ".";
        }
        currentCycle++;
    }
}