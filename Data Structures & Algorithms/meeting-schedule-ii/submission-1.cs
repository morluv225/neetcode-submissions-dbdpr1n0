/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        // sort intervals by start time in order to compare to the earliest end times
        intervals.Sort((a,b) => a.start.CompareTo(b.start));

        // create min heap to store earliest end times
        var minHeap = new PriorityQueue<int, int>();

        // loop through the intervals
        foreach(var interval in intervals)
        {   
            // if the minHeap is not empty and the current earliest end 
            // time is less than or equal to the start time. then we do not
            // have an overlap and can free up a machine
            if(minHeap.Count > 0 && minHeap.Peek() <= interval.start)
            {
                minHeap.Dequeue();
            }
            minHeap.Enqueue(interval.end, interval.end);
        }

        // whatever intervals are left on the heap overlap thus need different machines
        // so we return the minHeap size
        return minHeap.Count;
        
    }
}
