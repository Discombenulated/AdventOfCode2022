using AdventOfCode.Day07;
using NUnit.Framework;

namespace AdventOfCode.Test.Day07;

public class Task02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_ExampleData()
    {
        var input = new FileInput("Day07/ExampleInput.txt").ReadLines();
        var root = new FileSystem(input).GetRoot();
        Assert.AreEqual(24933642, root.SizeOfSmallestDirectoryToDelete(70000000, 30000000));
    }

    [Test]
    public void SmallestDeletableDirectory(){
        var root = new Directory("/");
        var dir = new Directory("a");
        dir.AddFile("f", 29116);
        dir.AddFile("g", 2557);
        dir.AddFile("h.lst", 62596);
        var dir2 = new Directory("e");
        dir2.AddFile("i", 584);
        dir.AddDirectory(dir2);
        root.AddDirectory(dir);
        root.AddFile("b.txt", 14848514);
        root.AddFile("c.dat", 8504156);
        var dir3 = new Directory("d");
        dir3.AddFile("j", 4060174);
        dir3.AddFile("d.log", 8033020);
        dir3.AddFile("d.ext", 5626152);
        dir3.AddFile("k", 7214296);
        root.AddDirectory(dir3);
        Assert.AreEqual(24933642, root.SizeOfSmallestDirectoryToDelete(70000000, 30000000));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day07/MyInput.txt").ReadLines();
        var root = new FileSystem(input).GetRoot();
        Assert.AreEqual(8278005, root.SizeOfSmallestDirectoryToDelete(70000000, 30000000));
    }
}