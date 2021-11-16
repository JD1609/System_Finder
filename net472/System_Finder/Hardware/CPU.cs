using System.Collections.Generic;
using System.Management;

namespace System_Finder.Hardware
{
    /// <summary>
    /// Returns CPU informations
    /// </summary>
    public static class CPU
    {
        /// <summary>
        /// Returns CPU names
        /// </summary>
        public static IEnumerable<string> GetName()
        {
            using (ManagementObjectSearcher cpu = new ManagementObjectSearcher("select Name from Win32_Processor"))
            {
                foreach (ManagementObject obj in cpu.Get())
                {
                    yield return obj["Name"].ToString().Trim().Replace("(tm)", string.Empty);
                }
            }
        }


        /// <summary>
        /// Returns CPU cores
        /// </summary>
        public static IEnumerable<int> GetCores()
        {
            using (ManagementObjectSearcher cpu = new ManagementObjectSearcher("select NumberOfEnabledCore from Win32_Processor"))
            {
                foreach (ManagementObject obj in cpu.Get())
                {
                    yield return int.Parse(obj["NumberOfEnabledCore"].ToString().Trim());
                }
            }
        }


        /// <summary>
        /// Returns CPU threads
        /// </summary>
        public static IEnumerable<int> GetThreads()
        {
            using (ManagementObjectSearcher cpu = new ManagementObjectSearcher("select NumberOfLogicalProcessors from Win32_Processor"))
            {
                foreach (ManagementObject obj in cpu.Get())
                {
                    yield return int.Parse(obj["NumberOfLogicalProcessors"].ToString().Trim());
                }
            }
        }


        /// <summary>
        /// Returns CPU clock (by default in GHz) or in MHz
        /// </summary>
        public static IEnumerable<float> GetClock(bool inGHz=true)
        {
            using (ManagementObjectSearcher cpu = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor"))
            {
                foreach (ManagementObject obj in cpu.Get())
                {
                    if(inGHz)
                        yield return float.Parse(obj["MaxClockSpeed"].ToString()) / 1000;
                    else// In Mhz
                        yield return float.Parse(obj["MaxClockSpeed"].ToString());
                }
            }
        }
    }
}
