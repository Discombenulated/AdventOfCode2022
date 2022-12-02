namespace AdventOfCode.Day02;

public class AlternateRockPaperScissorsStrategy
{
    private readonly Dictionary<string, int> PLAYER_1_PLAYS = new Dictionary<string, int>(){{"A", 1}, {"B", 2}, {"C", 3}};
    private readonly Dictionary<string, int> PLAYER_2_PLAYS = new Dictionary<string, int>(){{"X", 1}, {"Y", 2}, {"Z", 3}};
    private const int SCORE_WIN = 6;
    private const int SCORE_DRAW = 3;

    private string[] input;

    public AlternateRockPaperScissorsStrategy(string[] input)
    {
        this.input = input;
    }

    public int CalculateScore()
    {
        int score = 0;
        foreach (var round in input){
            var plays = round.Split(' ');
            var expectedResult = plays[1];
            if (expectedResult == "Y") {
                score += scoreForDraw(plays[0]);
            } else if (expectedResult == "X"){
                score += scoreForLoss(plays[0]);
            } else {
                score += SCORE_WIN + scoreForWin(plays[0]);
            }
            
        }
        return score;
    }

    private int scoreForDraw(string play)
    {
        return SCORE_DRAW + PLAYER_1_PLAYS[play];
    }

    private int scoreForLoss(string play)
    {
        if (play == "A") return PLAYER_2_PLAYS["Z"];
        if (play == "B") return PLAYER_2_PLAYS["X"];
        return PLAYER_2_PLAYS["Y"];
    }

    private int scoreForWin(string play)
    {
        if (play == "A") return PLAYER_2_PLAYS["Y"];
        if (play == "B") return PLAYER_2_PLAYS["Z"];
        return PLAYER_2_PLAYS["X"];
    }

    private int pointsForPlay(string play)
    {
        return PLAYER_2_PLAYS[play];
    }
}