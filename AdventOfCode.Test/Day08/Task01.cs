using NUnit.Framework;

namespace AdventOfCode.Test.Day08;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day08/ExampleInput.txt").ReadLines();
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day08/MyInput.txt").ReadLines();
    }
}