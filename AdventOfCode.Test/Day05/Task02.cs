using AdventOfCode.Day05;
using NUnit.Framework;

namespace AdventOfCode.Test.Day05;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day05/ExampleInput.txt").ReadLines();
        var stacks = new StackList9001(input, 3);
        Assert.AreEqual("MCD", stacks.TopCrates());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day05/MyInput.txt").ReadLines();
        var stacks = new StackList9001(input, 9);
        Assert.AreEqual("TPFFBDRJD", stacks.TopCrates());
    }
}