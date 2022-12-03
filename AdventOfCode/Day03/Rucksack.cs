namespace AdventOfCode.Day03;

public class Rucksack
{
    private const string PRIORITY_ORDER = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string contents;
    public Rucksack(string contents)
    {
        this.contents = contents;
    }

    public char CommonItem(params Rucksack[] rucksacks)
    {
        return contents.Where(c => {
            foreach (var rucksack in rucksacks){
                if (!rucksack.Contains(c)) return false;
            }
            return true;
        }).First();
    }

    public char ItemInBothCompartments()
    {
        //return contents.GroupBy(a => a).OrderByDescending(g => g.Count()).First().Key;
        var compartment1 = contents.Substring(0,contents.Length / 2).ToCharArray();
        var compartment2 = contents.Substring(contents.Length / 2).ToCharArray();
        return compartment1.Where(item => compartment2.Contains(item)).First();
    }

    public int Priority()
    {
        return PRIORITY_ORDER.IndexOf(ItemInBothCompartments()) + 1;
    }

    public int PriorityOfCommonItem(params Rucksack[] rucksacks)
    {
        return PRIORITY_ORDER.IndexOf(CommonItem(rucksacks)) + 1;
    }

    private bool Contains(char item){
        return contents.Contains(item);
    }
}