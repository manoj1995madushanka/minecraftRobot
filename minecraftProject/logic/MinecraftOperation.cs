using System;
using System.Collections;
using System.Text;
using minecraftProject.utility;
using minecraftProject.model;

namespace minecraftProject.logic
{
    public class MinecraftOperation
    {
        private int maxXCoordinate, maxYCoordinate;

        /* method for set minecraft max coordinates using user inputs */
        public void setMineCraftMaxCoordinates(string coordinateInput)
        {
            string[] coordinates = coordinateInput.Split(Constant.SEPARATOR);
            this.maxXCoordinate = int.Parse(coordinates[0]);
            this.maxYCoordinate = int.Parse(coordinates[1]);
        }

        /* start point of mining process for each robot */
        public void startMining(ArrayList robotsInitCoordinateWithPathList)
        {
            Robot robot = new Robot();
            try
            {
                for (int robotIndex = 0; robotIndex < robotsInitCoordinateWithPathList.Count; robotIndex++)
                {
                    // if this true need to create new robot instance
                    if (robotIndex % 2 == 0)
                    {
                        if (robotIndex != 0) // first loop does not need to reinitialized robot
                        {
                            robot = new Robot();
                        }
                        setRobotData(robot, robotsInitCoordinateWithPathList[robotIndex].ToString());
                    }
                    else
                    {
                        moveRobot(robot, robotsInitCoordinateWithPathList[robotIndex].ToString());

                        // print robot final coordintes after movement done
                        Console.WriteLine(new StringBuilder().Append(robot.getXcoordinate())
                        .Append(Constant.SEPARATOR)
                        .Append(robot.getYcoordinate())
                        .Append(Constant.SEPARATOR)
                        .Append(robot.getRobotHeadDirection()).ToString());
                    }

                }
            }
            // handle null pointer exception
            catch (System.NullReferenceException nullException)
            {
                Console.WriteLine(new StringBuilder().Append(Constant.SOMETHING_THROWN_NULL).Append(nullException.GetBaseException()).ToString());
            }
            // handle array index out of bound exception
            catch (System.ArrayTypeMismatchException arrayIndexException)
            {
                Console.WriteLine(new StringBuilder().Append(Constant.ARRAY_LIMIT_REACHED).Append(arrayIndexException.GetBaseException()).ToString());
            }
        }


        /* set robot init coordinate and head direction */
        public void setRobotData(Robot robot, string robotposition)
        {
            string[] robotPositionParts = robotposition.Split(Constant.SEPARATOR);
            robot.setXcoordinate(int.Parse(robotPositionParts[0]));
            robot.setYcoordinate(int.Parse(robotPositionParts[1]));
            robot.setRobotHeadDirection(robotPositionParts[2]);
        }

        /* method that contains logic for robot move or change it's head direction path determining*/
        public void moveRobot(Robot robot, string robotPath)
        {
            char[] pathArray = robotPath.ToCharArray();
            foreach (char path in pathArray)
            {

                if (path != Constant.MOVE)
                {
                    moveHeadDirectionOfRobot(robot, path);
                }
                else
                {
                    moveRobot(robot, path);
                }
            }
        }


        /* method that contains logic for set robot head direction */
        private void moveHeadDirectionOfRobot(Robot robot, char path)
        {
            if (robot.getRobotHeadDirection().Equals(Constant.NORTH) && path == Constant.LEFT)
            {
                robot.setRobotHeadDirection(Constant.WEST);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.NORTH) && path == Constant.RIGHT)
            {
                robot.setRobotHeadDirection(Constant.EAST);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.SOUTH) && path == Constant.LEFT)
            {
                robot.setRobotHeadDirection(Constant.EAST);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.SOUTH) && path == Constant.RIGHT)
            {
                robot.setRobotHeadDirection(Constant.WEST);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.EAST) && path == Constant.LEFT)
            {
                robot.setRobotHeadDirection(Constant.NORTH);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.EAST) && path == Constant.RIGHT)
            {
                robot.setRobotHeadDirection(Constant.SOUTH);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.WEST) && path == Constant.LEFT)
            {
                robot.setRobotHeadDirection(Constant.SOUTH);
            }
            else if (robot.getRobotHeadDirection().Equals(Constant.WEST) && path == Constant.RIGHT)
            {
                robot.setRobotHeadDirection(Constant.NORTH);
            }
        }

        /* method that containg move robot logic according to robot's head direction */
        private void moveRobot(Robot robot, char path)
        {
            int x = robot.getXcoordinate();
            int y = robot.getYcoordinate();
            // check robot moving direction is north and robot already reached minefield max y coordinate 
            // if robot in max y coordinate robot can not move north so stay same position until direction change
            if (robot.getRobotHeadDirection().Equals(Constant.NORTH) && (robot.getYcoordinate() != this.maxYCoordinate))
            {
                robot.setYcoordinate(++y);
            }
            // check robot moving direction is south and robot already reached minefield max y coordinate 
            // if robot in max y coordinate robot can not move south so stay same position until direction change
            else if (robot.getRobotHeadDirection().Equals(Constant.SOUTH) && (robot.getYcoordinate() != 0))
            {
                robot.setYcoordinate(--y);
            }
            // check robot moving direction is east and robot already reached minefield max x coordinate 
            // if robot in max x coordinate robot can not move east so stay same position until direction change
            else if (robot.getRobotHeadDirection().Equals(Constant.EAST) && (robot.getXcoordinate() != this.maxXCoordinate))
            {
                robot.setXcoordinate(++x);
            }
            // check robot moving direction is west and robot already reached minefield min x coordinate 
            // if robot in min x coordinate robot can not move west so stay same position until direction change
            else if (robot.getRobotHeadDirection().Equals(Constant.WEST) && (robot.getXcoordinate() != 0))
            {
                robot.setXcoordinate(--x);
            }
        }

    }
}