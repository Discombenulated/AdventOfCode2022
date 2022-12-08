using AdventOfCode.Day08;
using NUnit.Framework;

namespace AdventOfCode.Test.Day08;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day08/ExampleInput.txt").ReadLines();
        var forest = new Forest(input);
        Assert.AreEqual(8, forest.HighestScenicScore());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day08/MyInput.txt").ReadLines();
        var forest = new Forest(input);
        Assert.AreEqual(301392, forest.HighestScenicScore());
    }
}