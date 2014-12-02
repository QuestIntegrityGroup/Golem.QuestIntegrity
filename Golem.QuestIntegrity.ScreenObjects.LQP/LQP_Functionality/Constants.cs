using System;
using ProtoTest.Golem.Core;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public static class Constants
    {
        public const String DirectionUP = "UP";
        public const String DirectionDOWN = "DOWN";
        public const String DirectionLEFT = "LEFT";
        public const String DirectionRIGHT = "RIGHT";
        public const String GreaterThan = "GREATER";
        public const String LessThan = "LESS";
        public const String EqualToo = "EQUAL";
        public const String METRIC = "METRIC";
        public const String IMPERIAL = "IMPERIAL";

        public static string getProjectName()
        {
            string machine1 = Config.Settings.purpleSettings.Machine1;
            string machine2 = Config.Settings.purpleSettings.Machine2;
            string machine3 = Config.Settings.purpleSettings.Machine3;
            string machine4 = Config.Settings.purpleSettings.Machine4;
            string thismachine = Environment.MachineName;
            string projectName = "MACHINE: " + thismachine +" Is not configured!";
            if (thismachine == machine1)
            {
                projectName = Config.Settings.purpleSettings.ProjectName1;
            }
            if (thismachine == machine2)
            {
                projectName = Config.Settings.purpleSettings.ProjectName2;
            }
            if (thismachine == machine3)
            {
                projectName = Config.Settings.purpleSettings.ProjectName3;
            }
            if (thismachine == machine4)
            {
                projectName = Config.Settings.purpleSettings.ProjectName4;
            }
            return projectName;
        }
        public static string getTestFileLoc()
        {
            string machine1 = Config.Settings.purpleSettings.Machine1;
            string machine2 = Config.Settings.purpleSettings.Machine2;
            string machine3 = Config.Settings.purpleSettings.Machine3;
            string machine4 = Config.Settings.purpleSettings.Machine4;
            string thismachine = Environment.MachineName;
            string TestFileLoc = "MACHINE: " + thismachine + " Is not configured!";
            if (thismachine == machine1)
            {
                TestFileLoc = Config.Settings.purpleSettings.DataSetPath1;
            }
            if (thismachine == machine2)
            {
                TestFileLoc = Config.Settings.purpleSettings.DataSetPath2;
            }
            if (thismachine == machine3)
            {
                TestFileLoc = Config.Settings.purpleSettings.DataSetPath3;
            }
            if (thismachine == machine4)
            {
                TestFileLoc = Config.Settings.purpleSettings.DataSetPath4;
            }
            return TestFileLoc;
        }

        //This is used to set the system we're in during test run time
        public static String UnitSystem = "BLANK";
        
    }
}
