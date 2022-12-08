using System.Diagnostics;

namespace AdventOfCode.Day08;

public class Forest
{
    private string[] heights;
    private bool[,] visibleMap;

    private int[,] scenicScores;

    public Forest(string[] input)
    {
        this.heights = input;
    }

    public double CountVisibleTrees()
    {
        var height = heights.Length;
        var width = heights[0].Length;
        visibleMap = new bool[height,width];
        for (int y = 0; y < heights.Length; y++){
            for (int x = 0; x < heights[y].Length; x++){
                if (y == 0 || x ==0 || y == height-1 || x == width-1){
                    visibleMap[y,x] = true;
                    continue;
                }

                var currentTreeHeight = int.Parse(heights[y][x].ToString());

                //Am I the tallest tree from the left?
                var visibleFromLeft = true;
                for (int testX = 0; testX < x; testX++){
                    var leftTreeHeight = int.Parse(heights[y][testX].ToString());
                    if (leftTreeHeight >= currentTreeHeight) {
                        visibleFromLeft = false;
                        break;
                    }
                }
                
                if (visibleFromLeft){
                    visibleMap[y,x] = true;
                    continue;
                }

                //Am I the tallest tree from the top?
                var visibleFromTop = true;
                for (int testY = 0; testY < y; testY++){
                    var topTreeHeight = int.Parse(heights[testY][x].ToString());
                    if (topTreeHeight >= currentTreeHeight) {
                        visibleFromTop = false;
                        break;
                    }
                }

                if (visibleFromTop){
                    visibleMap[y,x] = true;
                    continue;
                }
            }
        }

        for (int y = heights.Length-2; y > 0; y--){
            for (int x = heights[y].Length-2; x > 0; x--){
                var currentTreeHeight = int.Parse(heights[y][x].ToString());

                //Am I the tallest tree from the right?
                var visibleFromRight = true;
                for (int testX = width-1; testX > x; testX--){
                    var rightTreeHeight = int.Parse(heights[y][testX].ToString());
                    if (rightTreeHeight >= currentTreeHeight) {
                        visibleFromRight = false;
                        break;
                    }
                }
                
                if (visibleFromRight){
                    visibleMap[y,x] = true;
                    continue;
                }

                //Am I the tallest tree from the bottom?
                var visibleFromBottom = true;
                for (int testY = height - 1; testY > y; testY--){
                    var bottomTreeHeight = int.Parse(heights[testY][x].ToString());
                    if (bottomTreeHeight >= currentTreeHeight) {
                        visibleFromBottom = false;
                        break;
                    }
                }

                if (visibleFromBottom){
                    visibleMap[y,x] = true;
                    continue;
                }
            }
        }
        
        var visibleCount = 0;
        for (int y = 0; y < heights.Length; y++){
            for (int x = 0; x < heights[y].Length; x++){
                if (visibleMap[y,x] == true) visibleCount++;
            }
        }
        return visibleCount;
    }

    public double HighestScenicScore()
    {
        var height = heights.Length;
        var width = heights[0].Length;
        scenicScores = new int[height,width];
        for (int y = 0; y < heights.Length; y++){
            for (int x = 0; x < heights[y].Length; x++){
                if (y == 0 || x ==0 || y == height-1 || x == width-1){
                    scenicScores[y,x] = 0;
                    continue;
                }

                var currentTreeHeight = int.Parse(heights[y][x].ToString());

                var visibleFromLeft = 0;
                for (int testX = x-1; testX>=0; testX--){
                    visibleFromLeft++;
                    var leftTreeHeight = int.Parse(heights[y][testX].ToString());
                    if (leftTreeHeight >= currentTreeHeight) {
                        break;
                    }
                }
                scenicScores[y,x] = visibleFromLeft;

                var visibleFromTop = 0;
                for (int testY = y-1; testY >= 0; testY--){
                    visibleFromTop++;
                    var topTreeHeight = int.Parse(heights[testY][x].ToString());
                    if (topTreeHeight >= currentTreeHeight) {
                        break;
                    }
                }
                scenicScores[y,x] = scenicScores[y,x] * visibleFromTop;

                var visibleFromRight = 0;
                for (int testX = x+1; testX<width; testX++){
                    visibleFromRight++;
                    var rightTreeHeight = int.Parse(heights[y][testX].ToString());
                    if (rightTreeHeight >= currentTreeHeight) {
                        break;
                    }
                }
                scenicScores[y,x] = scenicScores[y,x] * visibleFromRight;

                var visibleFromBottom = 0;
                for (int testY = y+1; testY < height; testY++){
                    visibleFromBottom++;
                    var bottomTreeHeight = int.Parse(heights[testY][x].ToString());
                    if (bottomTreeHeight >= currentTreeHeight) {
                        break;
                    }
                }
                scenicScores[y,x] = scenicScores[y,x] * visibleFromBottom;
            }
        }

        var maxScenicScore = 0;
        for (int y = 0; y < heights.Length; y++){
            for (int x = 0; x < heights[y].Length; x++){
                var currentScenicScore = scenicScores[y,x];
                if (currentScenicScore > maxScenicScore){
                    maxScenicScore = currentScenicScore;
                }
            }
        }

        return maxScenicScore;
    }

    public void PrintVisibility(){
        for (int y = 0; y < heights.Length; y++){
            for (int x = 0; x < heights[y].Length; x++){
                Console.Write(visibleMap[y,x] ? "1" : "0");
            }
            Console.WriteLine("");
        }
    }
}