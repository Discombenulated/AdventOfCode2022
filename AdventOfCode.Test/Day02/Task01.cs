using NUnit.Framework;

namespace AdventOfCode.Test.Day02;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test()
    {
        var input = new FileInput("Day02/MyInput.txt").ReadLines();
        Assert.Pass();
    }
}