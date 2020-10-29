using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DictionaryAndHashmap
{
    class FrequencyQueriesSolution
    {
        private static List<int> freqQuery(List<List<int>> queries)
        {
            var returnList = new List<int>();
            var dictionaryFrequency = new Dictionary<int, int>();
            var dictionaryFreqOccurencies = new Dictionary<int, int>();
            bool found;

            foreach (var q in queries)
            {
                found = dictionaryFrequency.TryGetValue(q[1],out int value);

                switch (q[0])
                {
                    case 1:
                        if(found)
                        {
                            dictionaryFrequency[q[1]]++;
                            dictionaryFreqOccurencies[value]--;

                            if(dictionaryFreqOccurencies.ContainsKey(value + 1))
                                dictionaryFreqOccurencies[value+1]++;
                            else
                                dictionaryFreqOccurencies.Add(value+1,1);

                        }
                        else
                        {
                            dictionaryFrequency.Add(q[1],1);

                            if (dictionaryFreqOccurencies.ContainsKey(1))
                                dictionaryFreqOccurencies[1]++;
                            else
                                dictionaryFreqOccurencies.Add(1, 1);
                        }
                        break;
                    case 2:
                        if(found)
                        {
                            dictionaryFrequency[q[1]]--;
                            dictionaryFreqOccurencies[value]--;

                            if(dictionaryFreqOccurencies.ContainsKey(value - 1))
                                dictionaryFreqOccurencies[value-1]++;
                            else
                                dictionaryFreqOccurencies.Add(value-1,1);

                        }
                        else
                        {
                            dictionaryFrequency.Remove(q[1]);
                            dictionaryFreqOccurencies[value]--;
                        }
                        break;
                    case 3:
                        if(dictionaryFreqOccurencies.ContainsKey(q[1]))
                            returnList.Add(1);
                        else
                            returnList.Add(0);
                        break;
                }

                if (found && dictionaryFreqOccurencies[value] == 0)
                    dictionaryFreqOccurencies.Remove(value);

            }
            return returnList;
        }
        public static void main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            var watch = Stopwatch.StartNew();

            List<int> ans = freqQuery(queries);

            watch.Stop();

            Console.WriteLine(string.Join("\n", ans));

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}