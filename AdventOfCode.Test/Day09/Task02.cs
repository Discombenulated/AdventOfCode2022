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
        var bridge = new Bridge2(10, 10, 10);
        Assert.AreEqual(1, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void Test_Example2Data()
    {
        var input = new FileInput("Day09/Example2Input.txt").ReadLines();
        var bridge = new Bridge2(9, 100, 100);
        Assert.AreEqual(36, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void Test_ExampleData_WithOneTail()
    {
        var input = new FileInput("Day09/ExampleInput.txt").ReadLines();
        var bridge = new Bridge2(1, 10, 10);
        Assert.AreEqual(13, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesRightFourSteps(){
        var bridge = new Bridge2(2, 10, 10);
        var input = new string[]{"R 4"};
        Assert.AreEqual(3, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUpFourSteps(){
        var bridge = new Bridge2(2, 10, 10);
        var input = new string[]{"U 4"};
        Assert.AreEqual(3, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUpOneStepRightTwoSteps(){
        var bridge = new Bridge2(1, 10, 10);
        var input = new string[]{"U 1", "R 2"};
        Assert.AreEqual(2, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day09/MyInput.txt").ReadLines();
        var bridge = new Bridge2(9, 1000, 1000);
        Assert.AreEqual(2460, bridge.CountPositionsVisitedByTailFollowing(input));
    }
}