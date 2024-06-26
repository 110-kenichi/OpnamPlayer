using OPNAMPlayer;
using System.Runtime.InteropServices;
using zanac.VGMPlayer;

namespace zanac.VGMPlayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings.Default.Reload();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());

            Settings.Default.Save();
        }
    }
}