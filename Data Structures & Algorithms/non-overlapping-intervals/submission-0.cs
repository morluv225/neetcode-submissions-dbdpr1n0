public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length == 0) return 0;

        // sort by end time
        Array.Sort(intervals, (a,b) => a[1].CompareTo(b[1]));
        int count = 0;
        //store the first end interval's end time
        int lastEnd = intervals[0][1];

        for(int i = 1; i < intervals.Length; i++)
        {   
            // if the next interval's start time is < than the last interval's end time
            // overlap, remove it
            if(intervals[i][0] < lastEnd)
            {
                count++;
            }
            else
            {
                // no overlap, keep it
                lastEnd = intervals[i][1];
            }
        }

        return count;
    }
}
