using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Stopwatch stopwatch = new();

        stopwatch.Start();
        string filePath = "/Users/adityapalpattuwar/Projects/personal/1brc/measurements.txt";

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            Dictionary<string, List<double>> stations = [];

            while ((line = reader.ReadLine()) != null)
            {
                string station = line.Split(';')[0];
                double temp = Convert.ToDouble(line.Split(';')[1]);

                if (stations.ContainsKey(station))
                {
                    stations[station].Add(temp);
                }
                else
                {
                    stations.Add(station, [temp]);
                }
            }

            Console.Write("{");
            foreach (var name in stations.Keys)
            {
                var tempList = stations[name];
                var min = double.Round(tempList.Min(), 1);
                var mean = double.Round(tempList.Average(), 1);
                var max = double.Round(tempList.Max(), 1);

                Console.Write($"{name}={min}/{mean}/{max}, ");
            }
            Console.Write("}");

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Total time taken - ${stopwatch.Elapsed}");
        }
    }
}
