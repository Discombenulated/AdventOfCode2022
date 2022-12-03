using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCode.Test.Day03;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day03/ExampleInput.txt").ReadLines();
        var elves = new Elves(input);
        Assert.AreEqual(70, elves.CalculatePriority());
    }

    [Test]
    public void RucksackCanFindCommonItemWithOtherRucksacks(){
        var rucksack1 = new Rucksack("ABCDCF");
        var rucksack2 = new Rucksack("UVWXBZ");
        Assert.AreEqual('B', rucksack1.CommonItem(rucksack2));
    }

    [Test]
    public void RucksackCanCalculatePriorityOfCommonItem(){
        var rucksack1 = new Rucksack("ABCDCF");
        var rucksack2 = new Rucksack("UVWXBZ");
        Assert.AreEqual(28, rucksack1.PriorityOfCommonItem(rucksack2));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day03/MyInput.txt").ReadLines();
        var elves = new Elves(input);
        Assert.AreEqual(2646, elves.CalculatePriority());
    }
}