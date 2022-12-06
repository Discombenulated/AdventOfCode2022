using NUnit.Framework;

namespace AdventOfCode.Test.Day07;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day07/ExampleInput.txt").ReadLines();
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day07/MyInput.txt").ReadLines();
    }
}