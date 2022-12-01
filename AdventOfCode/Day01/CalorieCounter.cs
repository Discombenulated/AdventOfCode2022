namespace AdventOfCode.Day01;

public class CalorieCounter
{
    private string[] input;

    public CalorieCounter(string[] input)
    {
        this.input = input;
    }

    private int CountCaloriesOfTopElves(int numberOfElves){
        var elfCalorieCount = new List<int>();
        int sum = 0;
        foreach (string line in input){
            int num = 0;
            if (int.TryParse(line, out num)){
                sum += num;
            } else {
                elfCalorieCount.Add(sum);
                sum = 0;
            }
        }
        elfCalorieCount.Add(sum);
        return elfCalorieCount.OrderByDescending(a => a).Take(numberOfElves).Sum();
    }

    public int CaloriesOfElfWithMostCalories()
    {
        return CountCaloriesOfTopElves(1);
    }

    public int CaloriesOfTop3ElvesWithMostCalories()
    {
        return CountCaloriesOfTopElves(3);
    }
}