using AdventOfCode.Day06;
using NUnit.Framework;

namespace AdventOfCode.Test.Day06;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var datastream = new Datastream("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
        Assert.AreEqual(19, datastream.FindStartOfPacket(14));

        datastream = new Datastream("bvwbjplbgvbhsrlpgdmjqwftvncz");
        Assert.AreEqual(23, datastream.FindStartOfPacket(14));

        datastream = new Datastream("nppdvjthqldpwncqszvftbrmjlhg");
        Assert.AreEqual(23, datastream.FindStartOfPacket(14));

        datastream = new Datastream("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
        Assert.AreEqual(29, datastream.FindStartOfPacket(14));

        datastream = new Datastream("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        Assert.AreEqual(26, datastream.FindStartOfPacket(14));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day06/MyInput.txt").ReadLines()[0];
        var datastream = new Datastream(input);
        Assert.AreEqual(3588, datastream.FindStartOfPacket(14));
    }
}