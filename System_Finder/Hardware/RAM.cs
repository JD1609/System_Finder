using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace System_Finder.Hardware
{
    // https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/cim-physicalmemory
    /// <summary>
    /// Returns RAM informations
    /// </summary>
    public static class RAM
    {
        /// <summary>
        /// Returns RAM names separated by ";"
        /// </summary>
        public static string GetName()
        {
            List<string> ramNames = new List<string>();

            using (ManagementObjectSearcher ram = new ManagementObjectSearcher("select Manufacturer from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in ram.Get())
                {
                    ramNames.Add(obj["Manufacturer"].ToString().Trim());
                };
            }

            if (ramNames.Count > 0)
                return String.Join(";", ramNames.Distinct().ToList());
            else
                return null;
        }

        /// <summary>
        /// Returns RAM type
        /// </summary>
        public static string GetType()
        {
            int type = 0;

            ConnectionOptions connection = new ConnectionOptions { Impersonation = ImpersonationLevel.Impersonate };
            ManagementScope scope = new ManagementScope(@"\\.\root\CIMV2", connection);
            scope.Connect();
            ObjectQuery query = new ObjectQuery("select MemoryType from Win32_PhysicalMemory");

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return TypeString(Convert.ToInt32(queryObj["MemoryType"]));
                }
            }

            return null;
        }

        /// <summary>
        /// Returns total RAM capacity (by default in GB) or in MB
        /// </summary>
        /// <param name="inGB">Should be in GB units</param>
        public static Int64? GetCapacity(bool inGB=true)
        {
            using (ManagementObjectSearcher RAMCap = new ManagementObjectSearcher("select TotalPhysicalMemory from Win32_ComputerSystem"))
            {
                foreach (ManagementObject obj in RAMCap.Get())
                {
                    Int64 memory = Int64.Parse(obj["TotalPhysicalMemory"].ToString());
                    if (inGB)
                        return memory / 1060568064; // in GB (must be divided by GiB)
                    else
                        return memory / 1048576; //in MB (must be divided by MiB)
                };
            }

            return null;
        }


        /// <summary>
        /// Returns RAM clock (by default in MHz) or in GHz
        /// </summary>
        public static float? GetClock(bool inMHz=true)
        {
            using (ManagementObjectSearcher RAMClock = new ManagementObjectSearcher("select Speed from CIM_PhysicalMemory"))
            {
                foreach (ManagementObject obj in RAMClock.Get())
                {
                    if (inMHz)
                        return float.Parse(obj["Speed"].ToString());
                    else
                        return float.Parse(obj["Speed"].ToString());
                };
            }

            return null;
        }

        #region RAM type switch
        [Obsolete("Doesn't work propearly")]
        private static string TypeString(int type)
        {
            // There are some known issues with this value and some OS's.
            // It also would appear that it depends on the memory itself
            // and not all memory has the information encoded in its EEPROM.

            // One alternative could be to query the SMBIOS directly.

            string outValue = string.Empty;

            switch (type)
            {
                case 0x0: outValue = "Unknown"; break;
                case 0x1: outValue = "Other"; break;
                case 0x2: outValue = "DRAM"; break;
                case 0x3: outValue = "Synchronous DRAM"; break;
                case 0x4: outValue = "Cache DRAM"; break;
                case 0x5: outValue = "EDO"; break;
                case 0x6: outValue = "EDRAM"; break;
                case 0x7: outValue = "VRAM"; break;
                case 0x8: outValue = "SRAM"; break;
                case 0x9: outValue = "RAM"; break;
                case 0xa: outValue = "ROM"; break;
                case 0xb: outValue = "Flash"; break;
                case 0xc: outValue = "EEPROM"; break;
                case 0xd: outValue = "FEPROM"; break;
                case 0xe: outValue = "EPROM"; break;
                case 0xf: outValue = "CDRAM"; break;
                case 0x10: outValue = "3DRAM"; break;
                case 0x11: outValue = "SDRAM"; break;
                case 0x12: outValue = "SGRAM"; break;
                case 0x13: outValue = "RDRAM"; break;
                case 0x14: outValue = "DDR"; break;
                case 0x15: outValue = "DDR2"; break;
                case 0x16: outValue = "DDR2 FB-DIMM"; break;
                case 0x17: outValue = "Undefined 23"; break;
                case 0x18: outValue = "DDR3"; break;
                case 0x19: outValue = "FBD2"; break;
                case 0x1a: outValue = "DDR4"; break;
                default: outValue = "Undefined"; break;
            }

            return outValue;
        }
        #endregion
    }
}
