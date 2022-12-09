namespace AdventOfCode.Day09;

public class Bridge
{
    private int Width;
    private int Height;
    private char[,] Map;
    private Position HeadPosition;
    
    private List<Position> TailPositions;

    private HashSet<Position> FinalUniqueTailPositions;

    public Bridge(int width, int height) : this(1, width, height){}

    public Bridge(int numTails, int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.Map = new char[width*2,height*2];
        this.HeadPosition = new Position(width-1,height-1);

        this.TailPositions = new List<Position>();
        for (int i = 0; i < numTails; i++){
            this.TailPositions.Add(new Position(width-1,height-1));
        }
        Map[TailPositions.Last().X, TailPositions.Last().Y] = '#';
        FinalUniqueTailPositions = new HashSet<Position>();
        FinalUniqueTailPositions.Add(TailPositions.Last());
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
                HeadPosition.MoveRight();
            } else if (direction.Equals("U")){
                HeadPosition.MoveUp();
            } else if (direction.Equals("L")){
                HeadPosition.MoveLeft();
            } else if (direction.Equals("D")){
                HeadPosition.MoveDown();
            }
            
            TailPositions[0].MoveRelativeTo(HeadPosition);

            for (int tailIndex = 1; tailIndex < TailPositions.Count; tailIndex++){
                TailPositions[tailIndex].MoveRelativeTo(TailPositions[tailIndex-1]);
            }

            Map[TailPositions.Last().X, TailPositions.Last().Y] = '#';
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

    private class Position{
        public int X {
            get;
            private set;
        }
        public int Y {
            get;
            private set;
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position MoveRelativeTo(Position other)
        {
            
            if (this.Y == other.Y){
                //Directly Left / Right
                if (IsRightByMoreThan(other, 1)){
                    MoveLeft();
                } else if (IsLeftByMoreThan(other, 1)){
                    MoveRight();
                }
            } else if (this.X == other.X)
            {
                //Directly up / down
                if (IsBelowByMoreThan(other, 1))
                {
                    MoveUp();
                }
                else if (IsAboveByMoreThan(other, 1))
                {
                    MoveDown();
                }
            }
            else {
                //Diagonal
                if (IsRightByMoreThan(other, 1)){
                    MoveLeft();
                    if (IsAboveByMoreThan(other, 0)){
                        MoveDown();
                    } else {
                        MoveUp();
                    }
                } else if (IsLeftByMoreThan(other, 1)){
                    this.X++;
                    if (IsAboveByMoreThan(other, 0)){
                        MoveDown();
                    } else {
                        MoveUp();
                    }
                } else if (IsBelowByMoreThan(other, 1)){
                    MoveUp();
                    if (this.X < other.X){
                        MoveRight();
                    } else {
                        MoveLeft();
                    }
                } else if (IsAboveByMoreThan(other, 1)){
                    MoveDown();
                    if (this.X < other.X){
                        MoveRight();
                    } else {
                        MoveLeft();
                    }
                }
            }
            return this;
        }

        private bool IsAboveByMoreThan(Position headPosition, int maxStepsAbove)
        {
            return headPosition.Y - this.Y > maxStepsAbove;
        }

        private bool IsBelowByMoreThan(Position headPosition, int maxStepsBelow)
        {
            return this.Y - headPosition.Y > maxStepsBelow;
        }

        private bool IsRightByMoreThan(Position headPosition, int maxStepsToRight)
        {
            return this.X - headPosition.X > maxStepsToRight;
        }

        private bool IsLeftByMoreThan(Position headPosition, int maxStepsToLeft){
            return headPosition.X - this.X > maxStepsToLeft;
        }

        public Position MoveUp(){
            this.Y--;
            return this;
        }

        public Position MoveDown(){
            this.Y++;
            return this;
        }

        public Position MoveLeft(){
            this.X--;
            return this;
        }

        public Position MoveRight(){
            this.X++;
            return this;
        }
    }
}