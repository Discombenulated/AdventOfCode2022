namespace AdventOfCode.Day11;

public class Monkeys
{
    private List<Monkey> monkeys;

    public Monkeys(){
        this.monkeys = new List<Monkey>();
    }

    public void Add(Monkey monkey)
    {
        this.monkeys.Add(monkey);
    }

    public long MonkeyBusinessAfterRounds(int numRounds)
    {
        for (int round = 0; round < numRounds; round++){
            Console.WriteLine($"Round: {round}");
            foreach (var monkey in monkeys){
                var instruction = monkey.Inspect();
                while (instruction.HasValue) {
                    monkeys[instruction.Value.ToMonkeyIndex].AddItem(instruction.Value.WorryLevel);
                    instruction = monkey.Inspect();
                }
            }
        }

        var busyMonkeys = this.monkeys.OrderByDescending(m => m.NumberOfItemsInspected).Take(2);
        return busyMonkeys.First().NumberOfItemsInspected * busyMonkeys.Last().NumberOfItemsInspected;
    }
}