using System;
using System.Collections.Generic;
using System.Management;

namespace System_Finder.Hardware
{
    /// <summary>
    /// Returns GPU informations
    /// </summary>
    public static class GPU
    {
        /// <summary>
        /// Returns GPU name
        /// </summary>
        public static IEnumerable<string> GetName()
        {
            using (ManagementObjectSearcher gpu = new ManagementObjectSearcher("select Name from Win32_VideoController"))
            {
                foreach (ManagementObject obj in gpu.Get())
                {
                    Console.WriteLine(obj["Name"].ToString());
                    yield return obj["Name"].ToString().Trim();
                }
            }
        }

        //TODO:
        
        ///// <summary>
        ///// Returns GPU clock
        ///// </summary>
        ///// <param name="inMhz">Should be in Mhz units</param>
        //private static IEnumerable<Int64?> GetClock(bool inMhz = true)
        //{
        //    return null;
        //}


        ///// <summary>
        ///// Returns GPU VRAM
        ///// </summary>
        ///// <param name="inGb">Should be in GB units</param>
        //private static IEnumerable<Int64?> GetVRAM(bool inGb = true)
        //{
        //    //With a little bit of C++ and the d3d11 libraries you can easily get the video adapter
        //    //memory value and the video card description as well as much more for probably under a 100
        //    //lines of code. C# has ported libraries such a SlimDX and SharpDX as well for direct C# usage.
        //    return null;
        //}

        ///// <summary>
        ///// Returns VRAM Type
        ///// </summary>
        //private static IEnumerable<Int64?> GetVRAMType()
        //{
        //    return null;
        //}
    }
}
