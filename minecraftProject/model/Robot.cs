namespace minecraftProject.model
{
    public class Robot
    {
        private int xcoordinate, ycoordinate;
        private string robotHeadDirection, minigPath;

        public Robot()
        {
            
        }
        public Robot(int xcoordinate, int ycoordinate, string robotHeadDirection)
        {
            this.xcoordinate = xcoordinate;
            this.ycoordinate = ycoordinate;
            this.robotHeadDirection = robotHeadDirection;
        }

        public int getXcoordinate()
        {
            return xcoordinate;
        }

        public int getYcoordinate()
        {
            return ycoordinate;
        }

        public void setXcoordinate(int xcoordinate)
        {
            this.xcoordinate = xcoordinate;
        }

        public void setYcoordinate(int ycoordinate)
        {
            this.ycoordinate = ycoordinate;
        }

        public string getRobotHeadDirection()
        {
            return robotHeadDirection;
        }

        public void setRobotHeadDirection(string robotHeadDirection)
        {
            this.robotHeadDirection = robotHeadDirection;
        }

        public string getMiningPath()
        {
            return minigPath;
        }

        public void setMiningPath(string miningPath)
        {
            this.minigPath = minigPath;
        }
    }
}