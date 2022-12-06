namespace AdventOfCode.Day06;

public class Datastream
{
    private string input;

    public Datastream(string input)
    {
        this.input = input;
    }

    public int FindStartOfPacket()
    {
        return FindStartOfPacket(4);
    }

    public int FindStartOfPacket(int markerLength)
    {
        for (int i = 0; i < input.Length - markerLength; i++){
            var marker = input.Substring(i, markerLength);
            if (marker.Distinct().Count() == markerLength) {
                return i+markerLength;
            }
        }
        return input.Length;
    }
}