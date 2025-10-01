class Solution:
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
                    q = collections.deque([])
                    q.append((i,j))
                    while q:
                        ii, jj = q.pop()
                        if 0 <= ii < n and 0 <= jj < m and grid[ii][jj] == '1':
                            grid[ii][jj] = '0'
                            q.append((ii-1, jj))
                            q.append((ii+1, jj))
                            q.append((ii, jj-1))
                            q.append((ii, jj+1))                            


        return islands