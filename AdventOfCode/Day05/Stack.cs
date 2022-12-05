namespace AdventOfCode.Day05;

public class Stack
{
    private List<string> crates;

    public Stack()
    {
        crates = new List<string>();
    }

    public void Add(string v)
    {
        v = v.Replace("[", "").Replace("]", "");
        crates.Add(v);
    }

    public void Add(string[] newCrates)
    {
        crates.AddRange(newCrates);
    }

    public void AddBottom(string v)
    {
        v = v.Replace("[", "").Replace("]", "");
        crates = crates.Prepend(v).ToList();
    }

    public string Remove()
    {
        var crateRemoved = crates.Last();
        crates.RemoveAt(crates.Count - 1);
        return crateRemoved;
    }

    public string[] Remove(int count)
    {
        var startIndex = crates.Count - count;
        var cratesRemoved = crates.Skip(startIndex).ToArray();
        crates.RemoveRange(startIndex, count);
        return cratesRemoved;
    }

    public string TopCrate()
    {
        if (crates.Count == 0) return "";
        return crates.Last();
    }
}