using NUnit.Framework;

namespace AdventOfCode.Test.Day12;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day12/ExampleInput.txt").ReadLines();
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day12/MyInput.txt").ReadLines();
    }
}