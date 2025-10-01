import collections

class Solution:
    def queue(self, grid, i, j):
        queue = collections.deque([])
        queue.append((i,j))
        while queue:
            ii, jj = queue.pop()
            if 0 <= ii < len(grid) and 0 <= jj < len(grid[0]) and grid[ii][jj] == '1':
                grid[ii][jj] = '0'
                queue.append((ii-1, jj))
                queue.append((ii+1, jj))
                queue.append((ii, jj-1))
                queue.append((ii, jj+1))


    def numIslands(self, grid: List[List[str]]) -> int:
        if not grid or not grid[0]:
            return 0

        n = len(grid)
        m = len(grid[0])

        islands = 0
        for i in range(n):
            for j in range(m):
                if grid[i][j] == '1':
                    islands += 1
                    self.queue(grid, i, j)

        return islands