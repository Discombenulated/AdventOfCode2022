using System.Diagnostics;
using System.Collections.Specialized;

namespace AdventOfCode.Day12;

public class Maze
{
    private string[] map;
    private int Width;
    private int Height;

    private const int UNREACHABLE_DESTINATION = int.MaxValue;

    public Maze(string[] map)
    {
        this.map = map;
        this.Height = map.Length;
        this.Width = map[0].Length;
    }

    public int ShortestPath()
    {
        var startAndEnd = FindStartAndEnd();
        var destination = startAndEnd[1];
        var toExplore = new Queue<QueueItem>();
        var visited = new List<Position>();
        toExplore.Enqueue(new QueueItem{Position=startAndEnd[0], Steps=0});
        while (toExplore.Count > 0){
            var currentItem = toExplore.Dequeue();
            var current = currentItem.Position;
            if (visited.Contains(current)) continue;
            visited.Add(current);

            var currentSteps = currentItem.Steps;
            //Console.WriteLine($"Examining: {current.X}, {current.Y}, {GetHeight(current.X, current.Y)} after {currentSteps} steps");
            if (current.Equals(destination)){
                return currentSteps;
            }

            currentSteps++;

            var up = current.Up();
            if (!visited.Contains(up) && CanReach(current, up)) toExplore.Enqueue(new QueueItem{Position=up, Steps=currentSteps});

            var down = current.Down();
            if (!visited.Contains(down) && CanReach(current, down)) toExplore.Enqueue(new QueueItem{Position=down, Steps=currentSteps});

            var left = current.Left();
            if (!visited.Contains(left) && CanReach(current, left)) toExplore.Enqueue(new QueueItem{Position=left, Steps=currentSteps});

            var right = current.Right();
            if (!visited.Contains(right) && CanReach(current, right)) toExplore.Enqueue(new QueueItem{Position=right, Steps=currentSteps});
        }
        return UNREACHABLE_DESTINATION;
        //return ShortestPath_Recursive(startAndEnd[0], startAndEnd[1], visited);
    }

    private int ShortestPath_Recursive(Position current, Position destination, Dictionary<Position, int> visited){
        if (current.Equals(destination)) return visited.Count;
        if (visited.Keys.Contains(current) && visited[current] <= visited.Count) {
            return UNREACHABLE_DESTINATION;
        }

        Debug.WriteLine($"Current Position: {current.X},{current.Y}, pathLength: {visited.Count}");

        if (visited.Keys.Contains(current)){
            visited[current] = visited.Count;
        } else {
            visited.Add(current, visited.Count);
        }

        var nextPositions = current.Neighbours()
                            .Where(p => p.IsInBounds(Width, Height))
                            .Where(p => CanReach(current, p));
        var pathLengths = nextPositions
                                .Select(p => ShortestPath_Recursive(p,destination, visited))
                                .Where(length => length != UNREACHABLE_DESTINATION);

        if (pathLengths.Count() == 0) {
            visited.Remove(current);
            return UNREACHABLE_DESTINATION;
        }
        else return pathLengths.Min();
    }

    private bool CanReach(Position current, Position next)
    {
        if (!next.IsInBounds(Width, Height)) return false;

        var currentHeight = GetHeight(current.X,current.Y);
        var newHeight = GetHeight(next.X,next.Y);
        return newHeight <= currentHeight + 1;
    }

    private int GetHeight(int x, int y){
        var height = map[y][x];
        if (height == 'S') height = 'a';
        if (height == 'E') height = 'z';
        return height;
    }

    private Position[] FindStartAndEnd(){
        Position[] startAndEnd = new Position[2];
        for (int y = 0; y < Height; y++){
            for (int x = 0; x < Width; x++){
                if (map[y][x].Equals('S')) startAndEnd[0] = new Position(x, y);
                if (map[y][x].Equals('E')) startAndEnd[1] = new Position(x, y);
                if (startAndEnd[0] != null && startAndEnd[1] != null) break;
            }
            if (startAndEnd[0] != null && startAndEnd[1] != null) break;
        }
        return startAndEnd;
    }

    private struct QueueItem{
        public Position Position;
        public int Steps;
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

        public Position Up(){
            return new Position(X, Y-1);
        }

        public Position Down(){
            return new Position(X, Y+1);
        }

        public Position Left(){
            return new Position(X-1, Y);
        }

        public Position Right(){
            return new Position(X+1, Y);
        }

        internal bool IsInBounds(int width, int height)
        {
            return this.X < width && this.X >= 0
                && this.Y < height && this.Y >= 0;
        }

        internal Position[] Neighbours()
        {
            return new Position[]{Up(), Down(), Left(), Right()};
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