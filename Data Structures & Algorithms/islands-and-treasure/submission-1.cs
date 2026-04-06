public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        int numRows = grid.Length;
        int numCols = grid[0].Length;
        if(numRows == 0) return;
        var q = new Queue<(int r, int c)>();

        // scan through the grid and find every treasure chest
        // add the cell coordinates to the q. These will be our BFS starting points (multi source)
        for(int rows = 0; rows < numRows; rows++)
        {
            for(int cols = 0; cols < numCols; cols++)
            {
                if(grid[rows][cols] == 0) q.Enqueue((rows,cols));
            }
        }

        // declare a directions array that we will use to loop and search in every direction from each coordinate
        int[][] dirs= [
            [0,1], // right
            [0,-1], // left
            [1,0], // up
            [-1,0] // down
        ];

        // BFS loop
        while(q.Count > 0)
        {   
            // get the coordinates off the top of the q
            var (r,c) = q.Dequeue();

            // now visit every neighbot in every direction from those coordinates
            //
            foreach(var dir in dirs)
            {
                int nr = r + dir[0];
                int nc = c + dir[1];

                // check for out of bounds/if the cell is not land. Continue to the next iteration if so (aka skip)
                // int.MaxValue = INF
                if(nr >= numRows || nc >= numCols || nr < 0 || nc < 0 || grid[nr][nc] != int.MaxValue) continue;

                // update the cell with the distance to the treasure chest
                // grid[r][c] always equals the shortest distance from the treasure chest
                // so adding 1 will be the distance that each propogating neighbor will be from the treasure chest at each wave
                // BFS wave 1: 
                    // grid[r][c] = 0 because we are at a treasure chest, thus the neighboring cells that are INF will be replaced
                    // with 0 + 1 = 1 cell away from the treasure chest
                    // The queue will then be updated with the BFS coordinates results and used in the next wave of BFS
                // BFS wave 2:
                    // grid[r][c] = 1
                    // the neighboring cells will be replaced with 1 + 1 = 2 cells aways from the treasure chest
                grid[nr][nc] = grid[r][c] + 1;
                q.Enqueue((nr,nc));
            }
        }

    }
}
