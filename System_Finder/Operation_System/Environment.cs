using System.Management;

namespace System_Finder.Operation_System
{
    /// <summary>
    /// Returns system environment variables
    /// </summary>
    public static class Environment
    {
        /// <summary>
        /// Returns username optimized for WPF labels - for classic operations use <see cref="System.Environment.UserName"/>
        /// </summary>
        public static string GetUser()
        {
            string user = System.Environment.UserName.ToString();

            if (user.Contains("_"))
                user = "_" + user;

            return user;
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
