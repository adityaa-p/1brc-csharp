using System.Diagnostics;

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
            Dictionary<string, List<decimal>> stations = [];

            while ((line = reader.ReadLine()) != null)
            {
                string station = line.Split(';')[0];
                decimal temp = decimal.Parse(line.Split(';')[1]);

                if (stations.ContainsKey(station))
                {
                    stations[station].Add(temp);
                }
                else
                {
                    stations.Add(station, [temp]);
                }
            }

            var sortedDictionary = stations.OrderBy(x => x.Key)
                                            .ToDictionary(pair => pair.Key, pair => pair.Value);

            Console.Write("{");
            foreach (var name in sortedDictionary.Keys)
            {
                var tempList = stations[name];
                var min = Math.Round(tempList.Min(), 1);
                var mean = decimal.Round(tempList.Average(), 1);
                var max = decimal.Round(tempList.Max(), 1);

                Console.Write($"{name}={min}/{mean}/{max}, ");
            }
            Console.Write("}");

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Total time taken - ${stopwatch.Elapsed}");
        }
    }
}
