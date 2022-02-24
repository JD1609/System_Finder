using System.Management;

namespace System_Finder.OperationSystem
{
    /// <summary>
    /// Returns system environment variables
    /// </summary>
    public static class Environment
    {
        /// <summary>
        /// Returns username
        /// </summary>
        public static string GetUser()
        {
            return System.Environment.UserName.ToString();
        }


        /// <summary>
        /// Returns OS name
        /// </summary>
        public static string GetOS()
        {
            string OsName = "";
            using (ManagementObjectSearcher os = new ManagementObjectSearcher("select * from Win32_OperatingSystem"))
            {
                foreach (ManagementObject obj in os.Get())
                {
                    OsName = obj["Caption"].ToString().Trim().Replace("Microsoft ", string.Empty);
                }
            }

            return OsName;
        }
    }
}
