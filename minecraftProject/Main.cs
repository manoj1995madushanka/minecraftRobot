using System;
using System.Collections;
using minecraftProject.logic;
using minecraftProject.utility;
using System.Text;

namespace minecraftProject
{
    class Program
    {
        /* 
        init point of application
         */
        static void Main(string[] args)
        {
            MinecraftOperation minecraftOperation = new MinecraftOperation();

            try
            {
                // get user input and set minecraft max coordinates
                Console.WriteLine(Constant.COORDINATE_INPUTS);
                String maxCoordinates = Console.ReadLine().Trim();
                minecraftOperation.setMineCraftMaxCoordinates(maxCoordinates);

                // take robots initial position and mining path inputs
                ArrayList robotInitCoordinateWithPathList = getRobotsCoordinateAndPath();
                if (robotInitCoordinateWithPathList.Count % 2 != 0)
                {
                    Console.WriteLine(Constant.ROBOTS_DATA_VALIDATION_FAILED);
                    return;
                }
                else
                {
                    minecraftOperation.startMining(robotInitCoordinateWithPathList);
                }
            }
            // handle array index out of bound exception
            catch (System.ArrayTypeMismatchException arrayIndexException)
            {
                Console.WriteLine(new StringBuilder().Append(Constant.ARRAY_LIMIT_REACHED).Append(arrayIndexException.GetBaseException()).ToString());
            }
            // handle user input exception
            catch (System.IO.IOException inputException)
            {
                Console.WriteLine(new StringBuilder().Append(Constant.INPUT_ERROR).Append(inputException.Message).ToString());
            }
            // handle not defined error when occured
            catch (Exception e)
            {
                Console.WriteLine(new StringBuilder().Append(Constant.ERROR).Append(e.Message).ToString());
            }
        }

        /* method for get user input data for robots initial coordinate and mining path */
        static ArrayList getRobotsCoordinateAndPath()
        {
            ArrayList robotsCoordinateAndPathList = new ArrayList();
            Console.WriteLine(Constant.ROBOT_POSITION_AND_PATH);
            String line = Console.ReadLine().Trim();
            while (!string.Empty.Equals(line))
            {
                robotsCoordinateAndPathList.Add(line);
                line = Console.ReadLine().Trim();
            }
            return robotsCoordinateAndPathList;
        }
    }
}
