namespace AdventOfCode.Day03;

public class RucksackList : List<Rucksack>
{
    public RucksackList(string[] input)
    {
        foreach(string contents in input){
            this.Add(new Rucksack(contents));
        }
    }

    public int CalculatePriority()
    {
        return this.Sum(rucksack => rucksack.Priority());
    }
}