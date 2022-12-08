using AdventOfCode.Day08;
using NUnit.Framework;

namespace AdventOfCode.Test.Day08;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day08/ExampleInput.txt").ReadLines();
        var forest = new Forest(input);
        Assert.AreEqual(21, forest.CountVisibleTrees());
    }

    [Test]
    public void CanCountTreesOnEdge(){
        var forest = new Forest(new string[]{
            "111",
            "101",
            "111"
        });
        Assert.AreEqual(8, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "1111",
            "1001",
            "1111"
        });
        Assert.AreEqual(10, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "1111",
            "1001",
            "1001",
            "1111"
        });
        Assert.AreEqual(12, forest.CountVisibleTrees()); 
    }

    [Test]
    public void CanCountTreesVisibleFromLeft(){
        var forest = new Forest(new string[]{
            "111",
            "121",
            "111"
        });
        Assert.AreEqual(9, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "1111",
            "1211",
            "1111"
        });
        Assert.AreEqual(11, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "1111",
            "1231",
            "1111"
        });
        Assert.AreEqual(12, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "9999",
            "7289",
            "9999"
        });
        Assert.AreEqual(11, forest.CountVisibleTrees()); 
    }

    [Test]
    public void CanCountTreesVisibleFromTop(){
        var forest = new Forest(new string[]{
            "1111",
            "3121",
            "1111",
            "1111"
        });
        Assert.AreEqual(13, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "9799",
            "9299",
            "9899",
            "9999"
        });
        Assert.AreEqual(13, forest.CountVisibleTrees()); 
    }

    [Test]
    public void CanCountTreesVisibleFromRight(){
        var forest = new Forest(new string[]{
            "1131",
            "3121",
            "1111",
            "1111"
        });
        Assert.AreEqual(13, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "9999",
            "9827",
            "9999",
            "9999"
        });
        Assert.AreEqual(13, forest.CountVisibleTrees()); 
    }

    [Test]
    public void CanCountTreesVisibleFromBottom(){
        var forest = new Forest(new string[]{
            "1131",
            "3123",
            "1111"
        });
        Assert.AreEqual(11, forest.CountVisibleTrees()); 

        forest = new Forest(new string[]{
            "9999",
            "9989",
            "9929",
            "9979"
        });
        Assert.AreEqual(13, forest.CountVisibleTrees()); 
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day08/MyInput.txt").ReadLines();
        var forest = new Forest(input);
        Assert.AreEqual(1711, forest.CountVisibleTrees());
    }
}