using AdventOfCode.Day10;
using NUnit.Framework;

namespace AdventOfCode.Test.Day10;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day10/ExampleInput.txt").ReadLines();
        var program = new ClockCircuit(20, 40);
        Assert.AreEqual(13140, program.SignalStrength(input));
    }

    [Test]
    public void SignalStrengthShouldBeZero(){
        var input = new string[]{"noop", "addx 3", "addx -5"};
        var program = new ClockCircuit(20, 40);
        Assert.AreEqual(0, program.SignalStrength(input));
    }

    [Test]
    public void SignalStrengthShouldBe1(){
        var input = new string[]{"noop"};
        var program = new ClockCircuit(1, 40);
        Assert.AreEqual(1, program.SignalStrength(input));

        input = new string[]{"noop", "addx 3", "addx -5"};
        program = new ClockCircuit(1, 40);
        Assert.AreEqual(1, program.SignalStrength(input));

        input = new string[]{"addx 3"};
        program = new ClockCircuit(1, 40);
        Assert.AreEqual(1, program.SignalStrength(input));

        input = new string[]{"addx 3", "noop"};
        program = new ClockCircuit(2, 40);
        Assert.AreEqual(2, program.SignalStrength(input));
    }

    [Test]
    public void SignalStrengthShouldBeNine(){
        var input = new string[]{"addx 3", "noop"};
        var program = new ClockCircuit(3, 40);
        Assert.AreEqual(12, program.SignalStrength(input));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day10/MyInput.txt").ReadLines();
        var program = new ClockCircuit(20, 40);
        Assert.AreEqual(17180, program.SignalStrength(input));
    }
}