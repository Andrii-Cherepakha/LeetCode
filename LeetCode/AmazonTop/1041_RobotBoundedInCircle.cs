namespace LeetCode.AmazonTop
{
    class _1041_RobotBoundedInCircle
    {
        public bool IsRobotBounded(string instructions)
        {
            // there is a cycle if the instructions executed 4 times and a robot appears in initial point
            // it is enougth to executed instruction once
            // the cycle is if 1) a robot in initial point OR 2) a robot does not face N (initial direction)

            int direction = 0; // N=0, E=1, S=2, W=3
            int x = 0;
            int y = 0;

            foreach (char instruction in instructions)
            {
                if (instruction == 'L')
                {
                    direction--;
                    if (direction == -1) direction = 3;
                }
                else if (instruction == 'R')
                {
                    direction++;
                    if (direction == 4) direction = 0;
                }
                else if (instruction == 'G')
                {
                    if (direction == 0) y++;
                    else if (direction == 1) x++;
                    else if (direction == 2) y--;
                    else if (direction == 3) x--;
                }
            }

            return (x == 0 && y == 0) || direction != 0;
        }
    }
}
