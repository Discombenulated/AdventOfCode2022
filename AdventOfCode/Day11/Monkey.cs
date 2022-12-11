using System.Numerics;

namespace AdventOfCode.Day11;

public partial class Monkey
{
    public delegate int MonkeyTest(BigInteger worryValue);
    public delegate BigInteger MonkeyOperation(BigInteger oldWorryValue);

    private List<BigInteger> items;
    private readonly MonkeyTest test;
    private readonly MonkeyOperation operation;
    private readonly MonkeyOperation bored;

    internal int NumberOfItemsInspected{
        get;
        private set;
    }

    public Monkey(MonkeyTest test, MonkeyOperation operation, params BigInteger[] items) :
    this (test, operation, d => d / 3L, items)
    {
    }

    public Monkey(MonkeyTest test, MonkeyOperation operation, MonkeyOperation bored, params BigInteger[] items){
        this.items = items.ToList();
        this.test = test;
        this.operation = operation;
        this.bored = bored;
        NumberOfItemsInspected = 0;
    }

    public MonkeyInstruction? Inspect()
    {
        if (items.Count == 0) return null;
        NumberOfItemsInspected++;
        var item = items[0];
        items.RemoveAt(0);
        item = operation(item);
        item = bored(item);
        return new MonkeyInstruction{ ToMonkeyIndex = test(item), WorryLevel = item};
    }

    internal void AddItem(BigInteger worryLevel)
    {
        items.Add(worryLevel);
    }
}