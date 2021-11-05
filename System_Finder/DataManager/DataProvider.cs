using System.Collections.Generic;
using System_Finder.Hardware;
using System.Linq;
using System.Text;

namespace System_Finder.DataManager
{
    /// <summary>
    /// Dataprovider for string HW representation.
    /// Not optimized for more components of one type!
    /// For more informations about this class see 
    /// <see href="https://github.com/JD1609/System_Finder/blob/main/System_Finder/docs/DataManager/Data%20provider.md">documentation</see>.
    /// </summary>
    public static class DataProvider
    {
        /// <summary>
        /// Returns HW components based on input string. 
        /// For more informations about input string variables see 
        /// <see href="https://github.com/JD1609/System_Finder/blob/main/System_Finder/docs/DataManager/Data%20provider.md">documentation</see>.
        /// </summary>
        /// <param name="dataSource">Component(s) informations in input string</param>
        /// <param name="inputFormat"></param>
        public static string GetHwString(DataSource dataSource, string inputFormat)
        {
            StringBuilder format = new StringBuilder(inputFormat);

            foreach (var variable in GetVariables(dataSource))
            {
                format.Replace(variable.Key, variable.Value);
            }

            return format.ToString();
        }

        private static Dictionary<string, string> GetVariables(DataSource dataSource)
        {
            var varDictionary = new Dictionary<string, string>();

            switch (dataSource)
            {
                case DataSource.Cpu:
                    AddCpuVariables(varDictionary);
                    break;

                case DataSource.Gpu:
                    AddGpuVariables(varDictionary);
                    break;

                case DataSource.Ram:
                    AddRamVariables(varDictionary);
                    break;

                case DataSource.Hdd:
                    AddHddVariables(varDictionary);
                    break;

                case DataSource.Motherboard:
                    AddMotherboardVariables(varDictionary);
                    break;

                case DataSource.Combined:
                    AddCpuVariables(varDictionary);
                    AddGpuVariables(varDictionary);
                    AddRamVariables(varDictionary);
                    AddHddVariables(varDictionary);
                    AddMotherboardVariables(varDictionary);
                    break;
            }

            return varDictionary;
        }

        private static void AddCpuVariables(Dictionary<string, string> dictionary)
        {
            var name = CPU.GetName().ToArray();
            var cores = CPU.GetCores().ToArray();
            var threads = CPU.GetThreads().ToArray();
            var clockMhz = CPU.GetClock(false).ToArray();
            var clockGhz = CPU.GetClock().ToArray();

            for (int i = 0; i < name.Length; i++)
            {
                dictionary.Add("{cpuName}", name[i]);
                dictionary.Add("{cpuCores}", cores[i].ToString());
                dictionary.Add("{cpuThreads}", threads[i].ToString());
                dictionary.Add("{cpuClock}", clockMhz[i].ToString());
                dictionary.Add("{cpuClock=Mhz}", clockMhz[i].ToString());
                dictionary.Add("{cpuClock=Ghz}", clockGhz[i].ToString());
            }
        }

        private static void AddGpuVariables(Dictionary<string, string> dictionary)
        {
            var name = GPU.GetName().ToArray();

            for (int i = 0; i < name.Length; i++)
            {
                dictionary.Add("{gpuName}", name[i]);
            }
        }

        private static void AddRamVariables(Dictionary<string, string> dictionary)
        {
            var name = RAM.GetName();
            var type = RAM.GetType();
            var capacityGB = RAM.GetCapacity();
            var capacityMB = RAM.GetCapacity(false);
            var clockGhz = RAM.GetClock(false);
            var clockMhz = RAM.GetClock();

            dictionary.Add("{ramName}", name);
            dictionary.Add("{ramType}", type);
            dictionary.Add("{ramCapacity}", capacityGB.ToString());
            dictionary.Add("{ramCapacity=MB}", capacityMB.ToString());
            dictionary.Add("{ramCapacity=GB}", capacityGB.ToString());
            dictionary.Add("{ramClock}", clockMhz.ToString());
            dictionary.Add("{ramClock=Mhz}", clockMhz.ToString());
            dictionary.Add("{ramClock=Ghz}", clockGhz.ToString());
        }

        private static void AddHddVariables(Dictionary<string, string> dictionary)
        {
            var name = HDD.GetNames().ToArray();

            dictionary.Add("{hddName}", name[0]);
        }

        private static void AddMotherboardVariables(Dictionary<string, string> dictionary)
        {
            var name = Motherboard.GetName();

            dictionary.Add("{motherboardName}", name);
        }
    }
}
