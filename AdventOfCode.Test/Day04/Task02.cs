using AdventOfCode.Day04;
using NUnit.Framework;

namespace AdventOfCode.Test.Day04;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindOveralappingAssignments_ExampleData()
    {
        var input = new FileInput("Day04/ExampleInput.txt").ReadLines();
        var assignments = new AssignmentList(input);
        Assert.AreEqual(4, assignments.CountOverlappingPairs());
    }

    [Test]
    public void PairsDoNotOverlap(){
        var assignment = new Assignment("2-4", "6-8");
        Assert.IsFalse(assignment.DoesPairOverlap());

        assignment = new Assignment("6-8", "2-3");
        Assert.IsFalse(assignment.DoesPairOverlap());
    }

    [Test]
    public void PairsDoOverlap(){
        var assignment = new Assignment("2-7", "6-8");
        Assert.IsTrue(assignment.DoesPairOverlap());

        assignment = new Assignment("6-8", "2-7");
        Assert.IsTrue(assignment.DoesPairOverlap());

        assignment = new Assignment("6-8", "7-9");
        Assert.IsTrue(assignment.DoesPairOverlap());

        assignment = new Assignment("6-8", "7-7");
        Assert.IsTrue(assignment.DoesPairOverlap());
    }

    [Test]
    public void AssignmentPairIsFullyContained(){
        var assignment = new Assignment("2-4", "3-3");
        Assert.IsTrue(assignment.IsPairFullyContained());

        assignment = new Assignment("3-3", "2-4");
        Assert.IsTrue(assignment.IsPairFullyContained());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day04/MyInput.txt").ReadLines();
        var assignments = new AssignmentList(input);
        Assert.AreEqual(924, assignments.CountOverlappingPairs());
    }
}