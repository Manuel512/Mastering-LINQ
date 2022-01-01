using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasteringLINQUI.Custom_Aggregations
{
    public class CustomAggregationsProgram
    {
        public static void Run()
        {
            //var sum = Enumerable.Range(1, 1000).Sum();

            //var sum = Enumerable.Range(1, 1000)
            //    .Aggregate(0, (i, acc) => i + acc);

            var sum = ParallelEnumerable.Range(1, 1000)
                .Aggregate(
                    0,
                    (partialSum, i) => partialSum += i,
                    (total, subtotal) => total += subtotal,
                    i => i
                );

            Console.WriteLine($"Sum = {sum}");
        }
    }
}
