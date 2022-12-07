namespace AdventOfCode.Day07;

public class Directory : FileSystemItem
{
    private List<File> Files;
    private List<Directory> Directories;

    public Directory(string name) : base(name)
    {
        this.Files = new List<File>();
        this.Directories = new List<Directory>();
    }

    public void AddDirectory(Directory dir2)
    {
        this.Directories.Add(dir2);
    }

    public void AddFile(string name, double size)
    {
        this.Files.Add(new File(name,size));
    }

    public override double Size()
    {
        return SizeOfFiles() + this.Directories.Sum(d => d.Size());
    }

    private double SizeOfFiles(){
        return this.Files.Sum(f => f.Size());
    }

    public double Size(int limit)
    {
        var mySize = Size();

        var sumOfDirectories = this.Directories.Sum(d => d.Size(limit));
        if (mySize <= limit) return mySize + sumOfDirectories;

        return sumOfDirectories;
    }

    internal Directory GetDirectory(string name)
    {
        return this.Directories.Where(d => d.Name.Equals(name)).First();
    }

    public double SizeOfSmallestDirectoryToDelete(double totalSpace, double spaceRequired)
    {
        var currentUsedSpace = this.Size();
        var currentFreeSpace = totalSpace - currentUsedSpace;
        var minimumDirectorySizeToDelete = spaceRequired - currentFreeSpace;
        return SizeOfSmallestDirectoryToDelete_Internal(minimumDirectorySizeToDelete, this.Size());
    }

    public double SizeOfSmallestDirectoryToDelete_Internal(double minimumDirectorySizeToDelete, double currentBestSize)
    {
        var mySize = this.Size();
        if (mySize > minimumDirectorySizeToDelete && mySize < currentBestSize) currentBestSize = mySize;
        var bestSubDir = this.Directories.Select(d => d.SizeOfSmallestDirectoryToDelete_Internal(minimumDirectorySizeToDelete, currentBestSize));
        if (bestSubDir.Count() > 0){
            return bestSubDir.Min();
        }
        return currentBestSize;
    }
}