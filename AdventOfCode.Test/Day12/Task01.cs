using AdventOfCode.Day12;
using NUnit.Framework;

namespace AdventOfCode.Test.Day12;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day12/ExampleInput.txt").ReadLines();
        var maze = new Maze(input);
        Assert.AreEqual(31, maze.ShortestPath());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day12/MyInput.txt").ReadLines();
        var maze = new Maze(input);
        Assert.AreEqual(490, maze.ShortestPath());
    }
}