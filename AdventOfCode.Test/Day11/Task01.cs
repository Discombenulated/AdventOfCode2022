using System.Numerics;
using AdventOfCode.Day11;
using NUnit.Framework;

namespace AdventOfCode.Test.Day11;

public class Task01
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
            d => d % 23 == 0 ? 2 : 3,
            d => d * 19,
            79, 98
        ));
        monkeys.Add(new Monkey(
            d => d % 19 == 0 ? 2 : 0,
            d => d + 6,
            54, 65, 75, 74
        ));
        monkeys.Add(new Monkey(
            d => d % 13 == 0 ? 1 : 3,
            d => d * d,
            79, 60, 97
        ));
        monkeys.Add(new Monkey(
            d => d % 17 == 0 ? 0 : 1,
            d => d + 3,
            74
        ));

        Assert.AreEqual(10605, monkeys.MonkeyBusinessAfterRounds(20));
    }

    [Test]
    public void MonkeyShouldThrowFirstItemToMonkey2(){
        var monkey = new Monkey(d => d % 23 == 0 ? 1 : 2, d => d * 19, 79, 790);
        var instruction = monkey.Inspect();
        Assert.AreEqual(2, instruction.Value.ToMonkeyIndex);
        Assert.AreEqual(new BigInteger(500), instruction.Value.WorryLevel);
    }

    [Test]
    public void MonkeyShouldThrowFirstItemToMonkey1AndSecondItemToMonkey3(){
        var monkey = new Monkey(d => d % 13 == 0 ? 1 : 3, d => d * d, 79, 60);
        var instruction = monkey.Inspect();
        Assert.AreEqual(1, instruction.Value.ToMonkeyIndex);
        Assert.AreEqual(new BigInteger(2080), instruction.Value.WorryLevel);

        instruction = monkey.Inspect();
        Assert.AreEqual(3, instruction.Value.ToMonkeyIndex);
        Assert.AreEqual(new BigInteger(1200), instruction.Value.WorryLevel);
    }

    [Test]
    public void Test_MyData()
    {
        var monkeys = new Monkeys();
        monkeys.Add(new Monkey(
            d => d % 7 == 0 ? 2 : 3,
            d => d * 19,
            57, 58
        ));
        monkeys.Add(new Monkey(
            d => d % 19 == 0 ? 4 : 6,
            d => d + 1,
            66, 52, 59, 79, 94, 73
        ));
        monkeys.Add(new Monkey(
            d => d % 5 == 0 ? 7 : 5,
            d => d + 6,
            80
        ));
        monkeys.Add(new Monkey(
            d => d % 11 == 0 ? 5 : 2,
            d => d + 5,
            82, 81, 68, 66, 71, 83, 75, 97
        ));
        monkeys.Add(new Monkey(
            d => d % 17 == 0 ? 0 : 3,
            d => d * d,
            55, 52, 67, 70, 69, 94, 90
        ));
        monkeys.Add(new Monkey(
            d => d % 13 == 0 ? 1 : 7,
            d => d + 7,
            69, 85, 89, 91
        ));
        monkeys.Add(new Monkey(
            d => d % 2 == 0 ? 0 : 4,
            d => d * 7,
            75, 53, 73, 52, 75
        ));
        monkeys.Add(new Monkey(
            d => d % 3 == 0 ? 1 : 6,
            d => d + 2,
            94, 60, 79
        ));

        Assert.AreEqual(50830, monkeys.MonkeyBusinessAfterRounds(20));
    }
}