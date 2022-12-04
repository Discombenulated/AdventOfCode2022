namespace AdventOfCode.Day04;

public class AssignmentList
{
    private List<Assignment> assignments;

    public AssignmentList(string[] input)
    {
        assignments = new List<Assignment>();
        foreach (var assignment in input){
            var sectionIds = assignment.Split(',');
            assignments.Add(new Assignment(sectionIds[0], sectionIds[1]));
        }
    }

    public int CountFullyContainedPairs()
    {
        return assignments.Where(a => a.IsPairFullyContained()).Count();
    }

    public int CountOverlappingPairs()
    {
        return assignments.Where(a => a.DoesPairOverlap()).Count();
    }
}