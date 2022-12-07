namespace AdventOfCode.Day07;

public class FileSystem
{
    private Directory Root;

    public FileSystem(string[] input)
    {
        Root = new Directory("/");
        var directoryStack = new Stack<Directory>();
        directoryStack.Push(Root);
        foreach(string line in input.Skip(1)){
            if (line.StartsWith("dir")){
                var name = line.Substring(4);
                directoryStack.Peek().AddDirectory(new Directory(name));
            } else if (line.StartsWith("$ cd")){
                var name = line.Substring(5);
                if (name.Equals("..")){
                    directoryStack.Pop();
                } else {
                    var newDir = directoryStack.Peek().GetDirectory(name);
                    directoryStack.Push(newDir);
                }
            } else if (line.StartsWith("$ ls")){
                continue;
            } else {
                var fileParams = line.Split(" ");
                var name = fileParams[1];
                var size = double.Parse(fileParams[0]);
                directoryStack.Peek().AddFile(name, size);
            }
        }
    }

    public Directory GetRoot()
    {
        return this.Root;
    }
}