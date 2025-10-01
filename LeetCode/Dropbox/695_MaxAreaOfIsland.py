import collections

class Solution:
    def get_area(self, grid: List[List[int]], i: int, j: int)  -> int:
        q = collections.deque([])
        q.append((i,j))
        area = 0
        while q:
            ii, jj = q.pop()
            if 0 <= ii < len(grid) and 0 <= jj < len(grid[0]) and grid[ii][jj] == 1:
                area += 1
                grid[ii][jj] = 0
                q.append((ii+1, jj))
                q.append((ii-1, jj))
                q.append((ii, jj-1))
                q.append((ii, jj+1))

        return area


    def maxAreaOfIsland(self, grid: List[List[int]]) -> int:
        if not grid or not grid[0]:
            return 0

        n = len(grid)
        m = len(grid[0])

        max_area = 0
        for i in range(n):
            for j in range(m):
                if grid[i][j] == 1:
                    area = self.get_area(grid, i, j)
                    max_area = max(max_area, area)

        return max_area
        
        