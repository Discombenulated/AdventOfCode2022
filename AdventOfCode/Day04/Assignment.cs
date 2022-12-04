namespace AdventOfCode.Day04;

public class Assignment
{
    private SectionID sectionIds1;
    private SectionID sectionIds2;

    public Assignment(string sectionIds1, string sectionIds2)
    {
        this.sectionIds1 = new SectionID(sectionIds1);
        this.sectionIds2 = new SectionID(sectionIds2);
    }

    public bool DoesPairOverlap()
    {
        return IsPairFullyContained() ||
            sectionIds1.OverlapsWith(sectionIds2) ||
                sectionIds2.OverlapsWith(sectionIds1);
    }

    public bool IsPairFullyContained()
    {
        return sectionIds1.FullyContains(sectionIds2) ||
                sectionIds2.FullyContains(sectionIds1);
    }

    private class SectionID
    {
        private int min;
        private int max;

        public SectionID(string sectionIds)
        {
            var ids = sectionIds.Split('-');
            this.min = int.Parse(ids[0]);
            this.max = int.Parse(ids[1]);
        }

        internal bool OverlapsWith(SectionID sectionIds2)
        {
            return (this.min >= sectionIds2.min && 
                    this.min <= sectionIds2.max) ||
                    (this.max >= sectionIds2.min &&
                    this.max <= sectionIds2.max);
        }

        internal bool FullyContains(SectionID sectionIds2)
        {
            return this.min <= sectionIds2.min && 
                    this.max >= sectionIds2.max;
        }
    }
}