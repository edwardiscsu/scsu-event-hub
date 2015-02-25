using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubCommon.Tools
{
    public static class PathFactory
    {
        public static string SolutionPath()
        {
            var solutionPath = "";
            var currentDirectory = null != AppDomain.CurrentDomain.RelativeSearchPath
                ? AppDomain.CurrentDomain.RelativeSearchPath : System.Environment.CurrentDirectory;

            var dirSplit = currentDirectory.Split(new string[] { "scsu-event-hub" }, StringSplitOptions.None);
            solutionPath = dirSplit[0] + "scsu-event-hub";

            return solutionPath;
        }

        public static string DatabasePath()
        {
            return System.IO.Path.Combine(PathFactory.SolutionPath(), "SCSUEventHubRepository\\App_Data");
        }
    }
}
