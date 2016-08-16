﻿#region

using System;
using System.Net;
using System.Text.RegularExpressions;
using EloBuddy;
using System.Diagnostics;
using System.IO;

#endregion

namespace NechritoRiven.Load
{
    internal class AssemblyVersion
    {
        private static string DownloadServerVersion
        {
            get
            {
                using (var wC = new WebClient()) return wC.DownloadString("https://raw.githubusercontent.com/Nechrito/Leaguesharp/master/Nechrito%20Riven/Properties/AssemblyInfo.cs");
            }
        }

        public static void CheckVersion()
        {
            try
            {
                var match = new Regex(@"\[assembly\: AssemblyVersion\(""(\d{1,})\.(\d{1,})\.(\d{1,})\.(\d{1,})""\)\]").Match(DownloadServerVersion);

                if (!match.Success) return;
                var gitVersion = new System.Version($"{match.Groups[1]}.{match.Groups[2]}.{match.Groups[3]}.{match.Groups[4]}");

                if (gitVersion <= System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) return;
                Chat.Print("<b><font color=\"#FFFFFF\">[</font></b><b><font color=\"#00e5e5\"> Nechrito Riven</font></b><b><font color=\"#FFFFFF\">]</font></b> <font color=\"#FFFFFF\">Version:</font>{0} Available!", gitVersion);


                
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Environment.SpecialFolder.ApplicationData + "Roaming\\EloBuddy\\Addons\\Libraries\\PortAIO.Common.dll");


                Chat.Print(myFileVersionInfo.FileVersion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Chat.Print("<b><font color=\"#FFFFFF\">[</font></b><b><font color=\"#00e5e5\"> Nechrito Riven</font></b><b><font color=\"#FFFFFF\">]</font></b><b><font color=\"#FFFFFF\"> Unable to fetch latest version</font></b>");
            }
        }
    }
}
