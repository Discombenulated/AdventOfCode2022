using AdventOfCode.Day05;
using NUnit.Framework;

namespace AdventOfCode.Test.Day05;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day05/ExampleInput.txt").ReadLines();
        var stacks = new StackList(input, 3);
        Assert.AreEqual("CMZ", stacks.TopCrates());
    }

    [Test]
    public void StackCanReportTopCrate(){
        var stack = new Stack();
        stack.Add("[A]");
        Assert.AreEqual("A", stack.TopCrate());
        stack.Add("B");
        Assert.AreEqual("B", stack.TopCrate());
        stack.AddBottom("C");
        Assert.AreEqual("B", stack.TopCrate());
    }

    [Test]
    public void StackListCanReportTopCratesWithoutMovesSingleColumn(){
        var input = new string[]{"[D]", 
                                 "[C]", 
                                 "[M]", 
                                 " 1 ", 
                                 ""};
        var stacks = new StackList(input, 1);
        Assert.AreEqual("D", stacks.TopCrates());
    }

    [Test]
    public void StackListCanReportTopCratesWithoutMoves(){
        var input = new string[]{"    [D]", 
                                 "    [C]", 
                                 "[M] [A]", 
                                 " 1   2 ", 
                                 ""};
        var stacks = new StackList(input, 2);
        Assert.AreEqual("MD", stacks.TopCrates());
    }

    [Test]
    public void StackListCanReportTopCratesWithMoves(){
        var input = new string[]{"    [D]", 
                                 "    [C]", 
                                 "[M] [A]", 
                                 " 1   2 ", 
                                 "",
                                 "move 1 from 2 to 1"};
        var stacks = new StackList(input, 2);
        Assert.AreEqual("DC", stacks.TopCrates());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day05/MyInput.txt").ReadLines();
        var stacks = new StackList(input, 9);
        Assert.AreEqual("LBLVVTVLP", stacks.TopCrates());
    }
}