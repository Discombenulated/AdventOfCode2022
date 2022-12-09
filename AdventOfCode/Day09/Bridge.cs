namespace AdventOfCode.Day09;

public class Bridge
{
    private Position HeadPosition;
    
    private List<Position> TailPositions;

    private HashSet<Position> PositionsVisitedByTail;

    public Bridge() : this(1){}

    public Bridge(int numTails)
    {
        this.HeadPosition = new Position(0,0);

        this.TailPositions = new List<Position>();
        for (int i = 0; i < numTails; i++){
            this.TailPositions.Add(new Position(0,0));
        }
        PositionsVisitedByTail = new HashSet<Position>();
        PositionsVisitedByTail.Add(TailPositions.Last().Copy());
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

            PositionsVisitedByTail.Add(TailPositions.Last().Copy());
        }
    }

    private double CountPositionsVisited(){
        return PositionsVisitedByTail.Count();
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

        public Position Copy()
        {
            return new Position(X, Y);
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}