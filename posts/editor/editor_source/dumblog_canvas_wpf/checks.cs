using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dumblog_canvas_wpf
{
    class checks
    {
        static bool runningWhereItShould = false;
        static bool fileSaved = false;

        public static void startUpCheck()
        {

            if (!File.Exists("../archive.lst"))
            {
                MessageBox.Show("You don't seem to be running the editor in the 'editor' folder of your Dumblog install.\n\nI'll save your posts on your desktop!", "Warning");
            }
            else
            {
                setRunningWhereItShould(true);
            }

        }

        public static void exitCheck()
        {
            if (!fileSaved)
            {
                if (MessageBox.Show("Are you sure you want to quit without saving?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static bool timestampExists(string timestamp)
        {
            if(timestamp != null && timestamp.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void setRunningWhereItShould(bool status)
        {
            runningWhereItShould = status;

        }

        public static bool getRunningWhereItShould()
        {
            return runningWhereItShould;
        }

        public static void setFileSaved(bool status)
        {
            fileSaved = status;
        }

        public static bool getFileSaved()
        {
            return fileSaved;
        }

    }
}
