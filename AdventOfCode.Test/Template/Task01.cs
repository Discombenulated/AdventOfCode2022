using NUnit.Framework;

namespace AdventOfCode.Test.Template;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("DayXX/ExampleInput.txt").ReadLines();
        Assert.Fail();
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("DayXX/MyInput.txt").ReadLines();
        Assert.Fail();
    }
}