public class Solution {
    public int[][] Merge(int[][] intervals) {
        
        if(intervals.Length <= 1)
        {
            return intervals;
        }

        // sort the array in place with custom comparison lambda function
        // a and b are two intervals
        // a[0] and b[0] are the start times of each interval
        // if a[0] < b[0], a comes first, and vice versa
        // now the intervals are in order by start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var result = new List<int[]>();

        // get the first interval in the sorted list
        // add it to the result vector because current should always be the last element in result
        // becuse we're going to update it in place
        int[] current = intervals[0];
        result.Add(current);

        // loop through the interval pairs and compare
        foreach(var interval in intervals)
        {
            // get the start and end times of the current and next intervals
            int currStart = current[0];
            int currEnd = current[1];
            int nextStart = interval[0];
            int nextEnd = interval[1];

            // if the start time of the next interval is <= the end of the current interval
            // there's an overlap so we merge
            if(nextStart <= currEnd)
            {
                // update the end time of the current interval to the end time of the next interval
                current[1] = Math.Max(currEnd, nextEnd);
            }
            else
            { 
                // no overlap, so no merge
                // update the current interval to the previous next interval 
                // add the interval to the result  
                current = interval;
                result.Add(current);
            }
        }
        return result.ToArray();
    }
}
