public class Solution {
    public int OrangesRotting(int[][] grid) {
        int numRows = grid.Length;
        int numCols = grid[0].Length;
        int fresh = 0;
        int time = 0;
        var q = new Queue<(int r, int c)>();

        for(int r = 0; r < numRows; r++)
        {
            for(int c = 0; c < numCols; c++)
            {
                if(grid[r][c] == 1)
                {
                    fresh++;
                }

                if(grid[r][c] == 2)
                {
                    q.Enqueue((r,c));
                }
            }
        }

        int[][] dirs =[
            [1,0], 
            [-1,0], 
            [0,1], 
            [0, -1]
        ];

        while(fresh > 0 && q.Count > 0)
        {
            int length = q.Count;
            for(int i = 0; i < length; i++)
            {
                var (r,c) = q.Dequeue();
                // travel in every direction
                foreach(var dir in dirs)
                {
                    int row = r + dir[0];
                    int col = c + dir[1];

                    // check to make sure that we're in bounds and on a cell with a fresh fruit
                    if(row >= 0 && col>= 0 && row < numRows && col < numCols && grid[row][col] == 1)
                    {
                        grid[row][col] = 2;
                        fresh--;
                        q.Enqueue((row, col));
                    }
                }
            }
            time++;
        }
        return fresh == 0 ? time : -1;
    }
}
