using AdventOfCode.Day02;
using NUnit.Framework;

namespace AdventOfCode.Test.Day02;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculateScoreFromStrategy_ExampleData()
    {
        var input = new FileInput("Day02/ExampleInput.txt").ReadLines();
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(15, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreRockPaper(){
        var input = new string[]{"A Y"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(8, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScorePaperRock(){
        var input = new string[]{"B X"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(1, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreRockScissors(){
        var input = new string[]{"A Z"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(3, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreScissorsRock(){
        var input = new string[]{"C X"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(7, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreScissorsPaper(){
        var input = new string[]{"C Y"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(2, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScorePaperScissors(){
        var input = new string[]{"B Z"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(9, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateSingleRoundScoreScissorsScissors(){
        var input = new string[]{"C Z"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(6, strategy.CalculateScore());
    }

    [Test]
    public void CanCalulateTwoRoundScoreRockPaper(){
        var input = new string[]{"A Y", "A Y"};
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(16, strategy.CalculateScore());
    }

    [Test]
    public void CalculateScoreFromStrategy_MyData()
    {
        var input = new FileInput("Day02/MyInput.txt").ReadLines();
        var strategy = new RockPaperScissorsStrategy(input);
        Assert.AreEqual(15691, strategy.CalculateScore());
    }
}