using System;
using AdventOfCode.Day10;
using NUnit.Framework;

namespace AdventOfCode.Test.Day10;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day10/ExampleInput.txt").ReadLines();
        var program = new ClockCircuit(0,40);
        var expected = new string[]{
            "##..##..##..##..##..##..##..##..##..##..",
            "###...###...###...###...###...###...###.",
            "####....####....####....####....####....",
            "#####.....#####.....#####.....#####.....",
            "######......######......######......####",
            "#######.......#######.......#######....."
        };
        var actual = program.Draw(input);
        Console.WriteLine("Start example data");
        foreach(string line in actual){
            Console.WriteLine(line);
        }
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day10/MyInput.txt").ReadLines();
        var program = new ClockCircuit(0,40);
        var actual = program.Draw(input);
        Console.WriteLine("Start my data");
        foreach(string line in actual){
            Console.WriteLine(line);
        }
    }
}