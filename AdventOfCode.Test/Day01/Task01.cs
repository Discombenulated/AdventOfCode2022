using AdventOfCode.Day01;
using NUnit.Framework;

namespace AdventOfCode.Test.Day01;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ElfCarryingMostCalories_ExampleData()
    {
        var input = new FileInput("Day01/ExampleInput.txt").ReadLines();
        var calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(24000, calorieCounter.CaloriesOfElfWithMostCalories());
    }

    [Test]
    public void CanCountSingleElfCalories(){
        var input = new string[]{"100", "200", "300"};
        var calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(600, calorieCounter.CaloriesOfElfWithMostCalories());

        input = new string[]{"400", "300", "300", "50"};
        calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(1050, calorieCounter.CaloriesOfElfWithMostCalories());
    }

    [Test]
    public void CanCountMoreThanOneElfCalories(){
        var input = new string[]{"100", "200", "300", "", "400", "300", "250"};
        var calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(950, calorieCounter.CaloriesOfElfWithMostCalories());
    }

    [Test]
    public void ElfCarryingMostCalories_MyData()
    {
        var input = new FileInput("Day01/MyInput.txt").ReadLines();
        var calorieCounter = new CalorieCounter(input);
        Assert.AreEqual(66616, calorieCounter.CaloriesOfElfWithMostCalories());
    }
}