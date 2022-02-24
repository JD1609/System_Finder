using System.Collections.Generic;
using System.Management;

namespace System_Finder.Hardware
{
    /// <summary>
    /// Returns HDD informations
    /// </summary>
    public static class HDD
    {
        /// <summary>
        /// Returns disks names
        /// </summary>
        public static IEnumerable<string> GetNames()
        {
            using (ManagementObjectSearcher HDD = new ManagementObjectSearcher("select Model from Win32_DiskDrive"))
            {
                foreach (ManagementObject mo in HDD.Get())
                {
                    yield return mo["Model"].ToString();
                }
            }
        }
    }
}
