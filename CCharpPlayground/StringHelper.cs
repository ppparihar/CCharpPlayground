using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CCharpPlayground
{

    class StringHelper
    {
        //static async Task Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");

 
        //    //ReadDeviceIds();
        //    // DiffList();
        //    // MakeUniqueListDeviceList();
        //    // ReadDeviceIdsCount();
        //    // WrappDoubleQuates();
        //    // MakeUniqueListDeviceList();
        //    //   Console.ReadLine();
        //}

        private static void DiffList()
        {
            var inputPath1 = "Diff1.txt";
            var inputPath2 = "Diff2.txt";
            var outPath = "diff-output.txt";
            var list1 = File.ReadAllLines(inputPath1);
            var list2 = File.ReadAllLines(inputPath2).ToHashSet();
            var list = new List<string>();
            foreach (var item in list1)
            {
                if (!list2.Contains(item))
                {
                    list.Add(item);
                }
            }

            var result = string.Join("\n", list);
            File.WriteAllText(outPath, result);
        }

        private static void WrappDoubleQuates()
        {
            var inputPath = "ActivityIds.txt";
            var outPath = "output.txt";
            var activities = File.ReadAllLines(inputPath);
            var list = new List<string>();
            foreach (var item in activities)
            {
                list.Add("\"" + item + "\"");
            }

            var result = string.Join(",", list);
            File.WriteAllText(outPath, result);
        }

        private static void MakeUniqueListDeviceList()
        {
            var inputPath = "IotHub4.txt";
            var outPath = "output-unique-Device.txt";
            var data = File.ReadAllLines(inputPath);

            List<string> uniqueList = data.Distinct().ToList();

            var result = string.Join("\n", uniqueList);
            File.WriteAllText(outPath, result);
        }

        private static void ReadDeviceIds()
        {
            var inputPath = "Device-count.json";
            var outPath = "output-Device.txt";
            var data = File.ReadAllText(inputPath);

            JArray o = JArray.Parse(data);
            var list = new List<string>();
            foreach (var item in o)
            {
                list.Add("" + item["IoTDeviceId"] + "");
            }

            var result = string.Join("\n", list);
            File.WriteAllText(outPath, result);
        }

        private static void ReadDeviceIdsCount()
        {
            var inputPath = "Device-count.json";
            var outPath = "output-Device-count.txt";
            var data = File.ReadAllText(inputPath);

            JArray o = JArray.Parse(data);
            var list = new List<string>();
            foreach (var item in o.Where(x => x.Value<int>("$1") > 1))
            {
                list.Add("" + item["IoTDeviceId"] + " " + item["$1"]);
            }

            var result = string.Join("\n", list);
            File.WriteAllText(outPath, result);
        }
    }
}
