namespace AdventOfCode.Day07;

public abstract class FileSystemItem{
    protected string Name;

    protected FileSystemItem(string name)
    {
        Name = name;
    }

    public abstract double Size();
}