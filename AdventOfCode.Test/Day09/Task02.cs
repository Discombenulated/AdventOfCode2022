using AdventOfCode.Day09;
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
        var bridge = new Bridge(9);
        Assert.AreEqual(1, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void Test_Example2Data()
    {
        var input = new FileInput("Day09/Example2Input.txt").ReadLines();
        var bridge = new Bridge(9);
        Assert.AreEqual(36, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesRightFourSteps(){
        var bridge = new Bridge(2);
        var input = new string[]{"R 4"};
        Assert.AreEqual(3, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUpFourSteps(){
        var bridge = new Bridge(2);
        var input = new string[]{"U 4"};
        Assert.AreEqual(3, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day09/MyInput.txt").ReadLines();
        var bridge = new Bridge(9);
        Assert.AreEqual(2460, bridge.CountPositionsVisitedByTailFollowing(input));
    }
}