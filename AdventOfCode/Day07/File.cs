namespace AdventOfCode.Day07;
public class File{
    private string _Name;
    private double _Size;

    public File(string name, double size){
        this._Name = name;
        this._Size = size;
    }

    public double Size(){
        return this._Size;
    }
}