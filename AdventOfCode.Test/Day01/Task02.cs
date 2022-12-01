using AdventOfCode.Day01;
using NUnit.Framework;

namespace AdventOfCode.Test.Day01;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Top3ElvesCarryingMostCalories_ExampleData()
    {
        var input = new FileInput("Day01/ExampleInput.txt").ReadLines();
        var calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(45000, calorieCounter.CaloriesOfTop3ElvesWithMostCalories());
    }

    [Test]
    public void Top3ElvesCarryingMostCalories_MyData()
    {
        var input = new FileInput("Day01/MyInput.txt").ReadLines();
        var calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(199172, calorieCounter.CaloriesOfTop3ElvesWithMostCalories());
    }
}