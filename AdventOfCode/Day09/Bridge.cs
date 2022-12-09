namespace AdventOfCode.Day09;

public class Bridge
{
    private int Width;
    private int Height;
    private char[,] Map;
    private Position HeadPosition;
    
    private List<Position> TailPositions;

    public Bridge(int width, int height) : this(1, width, height){}

    public Bridge(int numTails, int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.Map = new char[width*2,height*2];
        this.HeadPosition = new Position{X=width-1,Y=height-1};

        this.TailPositions = new List<Position>();
        for (int i = 0; i < numTails; i++){
            this.TailPositions.Add(new Position{X = width-1,Y = height-1});
        }
        Map[TailPositions.Last().X, TailPositions.Last().Y] = '#';
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
            } else if (direction.Equals("U")){
                HeadPosition.Y--;
            } else if (direction.Equals("L")){
                HeadPosition.X--;
            } else if (direction.Equals("D")){
                HeadPosition.Y++;
            }
            
            TailPositions[0] = MoveTail(TailPositions[0], HeadPosition);

            for (int tailIndex = 1; tailIndex < TailPositions.Count; tailIndex++){
                TailPositions[tailIndex] = MoveTail(TailPositions[tailIndex], TailPositions[tailIndex-1]);
            }

            Map[TailPositions.Last().X, TailPositions.Last().Y] = '#';
        }
    }

    private Position MoveTail(Position position, Position headPosition)
    {
        
        if (position.Y == headPosition.Y){
            //Directly Left / Right
            if (position.X - headPosition.X > 1){
                position.X--;
            } else if (headPosition.X - position.X > 1){
                position.X++;
            }
        } else if (position.X == headPosition.X){
            //Directly up / down
            if (position.Y - headPosition.Y > 1){
                position.Y--;
            } else if (headPosition.Y - position.Y > 1){
                position.Y++;
            }
        } else {
            //Diagonal
            if (position.X - headPosition.X > 1){
                position.X--;
                if (position.Y < headPosition.Y){
                    position.Y++;
                } else {
                    position.Y--;
                }
            } else if (headPosition.X - position.X > 1){
                position.X++;
                if (position.Y < headPosition.Y){
                    position.Y++;
                } else {
                    position.Y--;
                }
            } else if (position.Y - headPosition.Y > 1){
                position.Y--;
                if (position.X < headPosition.X){
                    position.X++;
                } else {
                    position.X--;
                }
            } else if (headPosition.Y - position.Y > 1){
                position.Y++;
                if (position.X < headPosition.X){
                    position.X++;
                } else {
                    position.X--;
                }
            }
        }
        return position;
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

    private struct Position{
        public int X;
        public int Y;
    }
}