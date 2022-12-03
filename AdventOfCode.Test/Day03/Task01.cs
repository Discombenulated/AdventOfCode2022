using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCode.Test.Day03;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day03/ExampleInput.txt").ReadLines();
        var rucksacks = new RucksackList(input);
        Assert.AreEqual(157, rucksacks.CalculatePriority());
    }

    [Test]
    public void RusksackCanCalulateItemInBothCompartments(){
        var rucksack = new Rucksack("ABCDCF");
        Assert.AreEqual('C', rucksack.ItemInBothCompartments());

        rucksack = new Rucksack("ABCDBF");
        Assert.AreEqual('B', rucksack.ItemInBothCompartments());
    }

    [Test]
    public void RusksackCanCalulatePriotity(){
        var rucksack = new Rucksack("ABCDCF");
        Assert.AreEqual(29, rucksack.Priority());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day03/MyInput.txt").ReadLines();
        var rucksacks = new RucksackList(input);
        Assert.AreEqual(7446, rucksacks.CalculatePriority());
    }
}