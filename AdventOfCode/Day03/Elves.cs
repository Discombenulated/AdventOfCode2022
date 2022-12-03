namespace AdventOfCode.Day03;

public class Elves
{
    private List<Rucksack> rucksacks;
    public Elves(string[] input)
    {
        rucksacks = new List<Rucksack>();
        foreach(string contents in input){
            rucksacks.Add(new Rucksack(contents));
        }
    }

    public int CalculatePriority()
    {
        var priority = 0;
        for (int i = 0; i < rucksacks.Count - 1; i+=3){
            var elfGroup = rucksacks.Skip(i).Take(3).ToArray();
            priority += elfGroup[0].PriorityOfCommonItem(elfGroup.ToArray());
        }
        return priority;
    }
}