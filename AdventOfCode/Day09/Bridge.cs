namespace AdventOfCode.Day09;

public class Bridge
{
    private int Width;
    private int Height;
    private char[,] Map;
    private (int X,int Y) HeadPosition;
    private (int X,int Y) TailPosition;

    public Bridge(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.Map = new char[width*2,height*2];
        this.HeadPosition = (width-1,height-1);
        this.TailPosition = (width-1,height-1);
        Map[TailPosition.X, TailPosition.Y] = '#';
    }

    public double CountPositionsVisitedByTailFollowing(string[] input)
    {
        foreach(var line in input){
            var instruction = line.Split(" ");
            var direction = instruction[0];
            var steps = int.Parse(instruction[1]);
            Move(direction, steps);
        }

        return CountPositionsVisited();
    }

    private void Move(string direction, int steps)
    {
        for (int i = 0; i < steps; i++){
            if (direction.Equals("R")){
                HeadPosition.X++;
                if (HeadPosition.X - TailPosition.X > 1) {
                    TailPosition.X++;
                    TailPosition.Y = HeadPosition.Y;
                }
            } else if (direction.Equals("U")){
                HeadPosition.Y--;
                if (HeadPosition.Y - TailPosition.Y < -1) {
                    TailPosition.Y--;
                    TailPosition.X = HeadPosition.X;
                }
            } else if (direction.Equals("L")){
                HeadPosition.X--;
                if (HeadPosition.X - TailPosition.X < -1) {
                    TailPosition.X--;
                    TailPosition.Y = HeadPosition.Y;
                }  
            } else if (direction.Equals("D")){
                HeadPosition.Y++;
                if (HeadPosition.Y - TailPosition.Y > 1) {
                    TailPosition.Y++;
                    TailPosition.X = HeadPosition.X;
                }
            }
            Map[TailPosition.X, TailPosition.Y] = '#';
        }
    }

    private double CountPositionsVisited(){
        var positionsVisited = 0;
        for (int x = 0; x < Width*2; x++){
            for (int y = 0; y < Height*2; y++){
                if (Map[x,y] == '#'){
                    positionsVisited++;
                }
            }
        }
        return positionsVisited;
    }

    public static double MaxWidth(string[] input){
        var rightSteps = input.Select(line => new {Direction = line.Split(" ")[0], Steps = line.Split(" ")[1]}).Where(a => a.Direction == "R").Count();
        var leftSteps = input.Select(line => new {Direction = line.Split(" ")[0], Steps = line.Split(" ")[1]}).Where(a => a.Direction == "L").Count();
        return Math.Max(rightSteps, leftSteps);
    }

    public static double MaxHeight(string[] input){
        var rightSteps = input.Select(line => new {Direction = line.Split(" ")[0], Steps = line.Split(" ")[1]}).Where(a => a.Direction == "U").Count();
        var leftSteps = input.Select(line => new {Direction = line.Split(" ")[0], Steps = line.Split(" ")[1]}).Where(a => a.Direction == "D").Count();
        return Math.Max(rightSteps, leftSteps);
    }
}