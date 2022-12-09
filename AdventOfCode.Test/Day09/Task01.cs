using AdventOfCode.Day09;
using NUnit.Framework;

namespace AdventOfCode.Test.Day09;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day09/ExampleInput.txt").ReadLines();
        var bridge = new Bridge();
        Assert.AreEqual(13, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesRightFourSteps(){
        var bridge = new Bridge();
        var input = new string[]{"R 4"};
        Assert.AreEqual(4, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesRightFourStepsThenLeftTwoSteps(){
        var bridge = new Bridge();
        var input = new string[]{"R 4", "L 2"};
        Assert.AreEqual(4, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUpFourSteps(){
        var bridge = new Bridge();
        var input = new string[]{"U 4"};
        Assert.AreEqual(4, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUpOneStepRightOneStep(){
        var bridge = new Bridge();
        var input = new string[]{"U 1", "R 1"};
        Assert.AreEqual(1, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUpOneStepRightTwoSteps(){
        var bridge = new Bridge();
        var input = new string[]{"U 1", "R 2"};
        Assert.AreEqual(2, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesRight4StepsUpTwoStepsLeft3Steps(){
        var bridge = new Bridge();
        var input = new string[]{"R 4", "U 2", "L 3"};
        Assert.AreEqual(7, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void HeadMovesUp4StepsRightTwoStepsDown3Steps(){
        var bridge = new Bridge();
        var input = new string[]{"U 4", "R 2", "D 3"};
        Assert.AreEqual(7, bridge.CountPositionsVisitedByTailFollowing(input));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day09/MyInput.txt").ReadLines();
        var bridge = new Bridge();
        Assert.AreEqual(6209, bridge.CountPositionsVisitedByTailFollowing(input));
    }
}