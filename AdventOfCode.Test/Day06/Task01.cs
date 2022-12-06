using AdventOfCode.Day06;
using NUnit.Framework;

namespace AdventOfCode.Test.Day06;

public class Task01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var datastream = new Datastream("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
        Assert.AreEqual(7, datastream.FindStartOfPacket());

        datastream = new Datastream("bvwbjplbgvbhsrlpgdmjqwftvncz");
        Assert.AreEqual(5, datastream.FindStartOfPacket());

        datastream = new Datastream("nppdvjthqldpwncqszvftbrmjlhg");
        Assert.AreEqual(6, datastream.FindStartOfPacket());

        datastream = new Datastream("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
        Assert.AreEqual(10, datastream.FindStartOfPacket());

        datastream = new Datastream("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        Assert.AreEqual(11, datastream.FindStartOfPacket());
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day06/MyInput.txt").ReadLines()[0];
        var datastream = new Datastream(input);
        Assert.AreEqual(1582, datastream.FindStartOfPacket());
    }
}