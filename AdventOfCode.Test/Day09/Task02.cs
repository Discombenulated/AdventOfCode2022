using NUnit.Framework;

namespace AdventOfCode.Test.Day09;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day09/ExampleInput.txt").ReadLines();
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day09/MyInput.txt").ReadLines();
    }
}