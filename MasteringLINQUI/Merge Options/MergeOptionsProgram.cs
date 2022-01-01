using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasteringLINQUI.Merge_Options
{
    public class MergeOptionsProgram
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(1, 20).ToArray();

            var results = numbers
                .AsParallel()
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Select(x =>
                {
                    var result = Math.Log10(x);
                    Console.Write($"P {result}\t");
                    return result;
                });

            foreach (var result in results)
            {
                Console.Write($"C {result}\t");
            }
        }
    }
}
