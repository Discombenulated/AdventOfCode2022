using AdventOfCode.Day11;
using NUnit.Framework;

namespace AdventOfCode.Test.Day11;

[Ignore("Takes too long")]
public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var monkeys = new Monkeys();
        monkeys.Add(new Monkey(
            d => d % (long)23 == 0 ? 2 : 3,
            d => d * (long)19,
            d => d,
            79, 98
        ));
        monkeys.Add(new Monkey(
            d => d % (long)19 == 0 ? 2 : 0,
            d => d + (long)6,
            d => d,
            54, 65, 75, 74
        ));
        monkeys.Add(new Monkey(
            d => d % (long)13 == 0 ? 1 : 3,
            d => d * d,
            d => d,
            79, 60, 97
        ));
        monkeys.Add(new Monkey(
            d => d % (long)17 == 0 ? 0 : 1,
            d => d + (long)3,
            d => d,
            74
        ));
        
        Assert.AreEqual(2713310158L, monkeys.MonkeyBusinessAfterRounds(10000));
    }

    [Test]
    public void Test_ExampleDataAfterRound20()
    {
        var monkeys = new Monkeys();
        monkeys.Add(new Monkey(
            d => d % 23 == 0 ? 2 : 3,
            d => d * 19,
            d => d,
            79, 98
        ));
        monkeys.Add(new Monkey(
            d => d % 19 == 0 ? 2 : 0,
            d => d + 6,
            d => d,
            54, 65, 75, 74
        ));
        monkeys.Add(new Monkey(
            d => d % 13 == 0 ? 1 : 3,
            d => d * d,
            d => d,
            79, 60, 97
        ));
        monkeys.Add(new Monkey(
            d => d % 17 == 0 ? 0 : 1,
            d => d + 3,
            d => d,
            74
        ));
        
        Assert.AreEqual(99*103, monkeys.MonkeyBusinessAfterRounds(20));
    }

    public void Test_ExampleDataAfterRound1000()
    {
        //700-800 approx 54 seconds (with IsEven)
        //700-800 approx 17 seconds (without IsEven)
        var monkeys = new Monkeys();
        monkeys.Add(new Monkey(
            d => d % 23 == 0 ? 2 : 3,
            d => d * 19,
            d => d,
            79, 98
        ));
        monkeys.Add(new Monkey(
            d => d % 19 == 0 ? 2 : 0,
            d => d + 6,
            d => d,
            54, 65, 75, 74
        ));
        monkeys.Add(new Monkey(
            d => d % 13 == 0 ? 1 : 3,
            d => d * d,
            d => d,
            79, 60, 97
        ));
        monkeys.Add(new Monkey(
            d => d % 17 == 0 ? 0 : 1,
            d => d + 3,
            d => d,
            74
        ));
        
        Assert.AreEqual(27019168, monkeys.MonkeyBusinessAfterRounds(1000));
    }
    
    public void Test_ExampleDataAfterRound5000()
    {
        var monkeys = new Monkeys();
        monkeys.Add(new Monkey(
            d => d % 23 == 0 ? 2 : 3,
            d => d * 19,
            d => d,
            79, 98
        ));
        monkeys.Add(new Monkey(
            d => d % 19 == 0 ? 2 : 0,
            d => d + 6,
            d => d,
            54, 65, 75, 74
        ));
        monkeys.Add(new Monkey(
            d => d % 13 == 0 ? 1 : 3,
            d => d * d,
            d => d,
            79, 60, 97
        ));
        monkeys.Add(new Monkey(
            d => d % 17 == 0 ? 0 : 1,
            d => d + 3,
            d => d,
            74
        ));
        
        Assert.AreEqual(26075L*26000L, monkeys.MonkeyBusinessAfterRounds(5001));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day11/MyInput.txt").ReadLines();
    }
}