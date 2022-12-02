namespace AdventOfCode.Day02;

public class RockPaperScissorsStrategy
{
    private readonly Dictionary<string, int> PLAYER_1_PLAYS = new Dictionary<string, int>(){{"A", 1}, {"B", 2}, {"C", 3}};
    private readonly Dictionary<string, int> PLAYER_2_PLAYS = new Dictionary<string, int>(){{"X", 1}, {"Y", 2}, {"Z", 3}};
    private const int SCORE_WIN = 6;
    private const int SCORE_DRAW = 3;

    private string[] input;

    public RockPaperScissorsStrategy(string[] input)
    {
        this.input = input;
    }

    public int CalculateScore()
    {
        int score = 0;
        foreach (var round in input){
            var plays = round.Split(' ');
            if (didWinRound(plays[0], plays[1])){
                score += SCORE_WIN;
            } else if (didDrawRound(plays[0], plays[1])) {
                score += SCORE_DRAW;
            }
            score += pointsForPlay(plays[1]);
        }
        return score;
    }

    private int pointsForPlay(string play)
    {
        return PLAYER_2_PLAYS[play];
    }

    private bool didWinRound(string play1, string play2)
    {
        if (play1 == "A" && play2 == "Y") return true;
        if (play1 == "B" && play2 == "Z") return true;
        if (play1 == "C" && play2 == "X") return true;
        return false;
    }

    private bool didDrawRound(string play1, string play2)
    {
        if (PLAYER_1_PLAYS[play1] == PLAYER_2_PLAYS[play2]) return true;
        return false;
    }
}