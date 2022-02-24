using System.Management;

namespace System_Finder.Hardware
{
    /// <summary>
    /// Returns motherboard informations
    /// </summary>
    public static class Motherboard
    {
        /// <summary>
        /// Returns motherboard name
        /// </summary>
        public static string GetName()
        {
            ManagementObjectSearcher MB = new ManagementObjectSearcher("select Product from Win32_BaseBoard");
            foreach (ManagementObject queryObj in MB.Get())
            {
                return queryObj["Product"].ToString();
            }

            return null;
        }
    }
}
