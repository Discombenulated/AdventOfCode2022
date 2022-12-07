using AdventOfCode.Day07;
using NUnit.Framework;

namespace AdventOfCode.Test.Day07;

public class Task01
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
        Assert.AreEqual(95437, root.Size(100000));
        Assert.AreEqual(48381165, root.Size());
    }

    [Test]
    public void DirectoryCanCalculateOwnSizeWithoutDirs(){
        var dir = new Directory("a");
        dir.AddFile("b", 3);
        Assert.AreEqual(3, dir.Size());
        dir.AddFile("c", 5);
        Assert.AreEqual(8, dir.Size());
    }

    [Test]
    public void DirectoryCanCalculateOwnSizeWithDirs(){
        var dir = new Directory("a");
        dir.AddFile("b", 3);
        dir.AddFile("c", 5);
        var dir2 = new Directory("d");
        dir2.AddFile("e", 7);
        dir.AddDirectory(dir2);
        Assert.AreEqual(15, dir.Size());
    }

    [Test]
    public void DirectoryCanCalculateTotalSizeOfDirectoriesLessThanAnAmount(){
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
        Assert.AreEqual(95437, root.Size(100000));
    }

    [Test]
    public void Test_MyData()
    {
        var input = new FileInput("Day07/MyInput.txt").ReadLines();
        var root = new FileSystem(input).GetRoot();
        Assert.AreEqual(1141028, root.Size(100000));
    }
}