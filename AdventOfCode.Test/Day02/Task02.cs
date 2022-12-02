using AdventOfCode.Day02;
using NUnit.Framework;

namespace AdventOfCode.Test.Day02;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculateScoreFromStrategy_ExampleData()
    {
        var input = new FileInput("Day02/ExampleInput.txt").ReadLines();
        var strategy = new AlternateRockPaperScissorsStrategy(input);
        Assert.AreEqual(12, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreRockDraw(){
        var input = new string[]{"A Y"};
        var strategy = new AlternateRockPaperScissorsStrategy(input);
        Assert.AreEqual(4, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScorePaperLose(){
        var input = new string[]{"B X"};
        var strategy = new AlternateRockPaperScissorsStrategy(input);
        Assert.AreEqual(1, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreScissorsWin(){
        var input = new string[]{"C Z"};
        var strategy = new AlternateRockPaperScissorsStrategy(input);
        Assert.AreEqual(7, strategy.CalculateScore());
    }

    [Test]
    public void CalculateScoreFromStrategy_MyData()
    {
        var input = new FileInput("Day02/MyInput.txt").ReadLines();
        var strategy = new AlternateRockPaperScissorsStrategy(input);
        Assert.AreEqual(12989, strategy.CalculateScore());
    }
}