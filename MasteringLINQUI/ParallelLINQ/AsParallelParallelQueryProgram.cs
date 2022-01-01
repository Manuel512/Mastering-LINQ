using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasteringLINQUI.ParallelLINQ
{
    public class AsParallelParallelQueryProgram
    {
        public static void RunAsParallel()
        {
            const int count = 50;
            var items = Enumerable.Range(1, count).ToArray();
            var results = new int[count];

            items.AsParallel().ForAll(x =>
            {
                int newValue = x * x * x;
                Console.Write($"{newValue} ({Task.CurrentId})\t");
                results[x - 1] = newValue;
            });
            Console.WriteLine();
            Console.WriteLine();

            //foreach (var i in results)
            //    Console.WriteLine($"{i}\t");
            //Console.WriteLine();

            var cubes = items.AsParallel().AsOrdered().Select(x => x * x * x);
            foreach (var i in results)
                Console.Write($"{i}\t");
            Console.WriteLine();
        }

        public static void RunCancellationOrExceptions()
        {
            var cts = new CancellationTokenSource();
            var items = ParallelEnumerable.Range(1, 20);
            var results = items.WithCancellation(cts.Token).Select(i =>
            {
                double result = Math.Log10(i);

                //if (result > 1) throw new InvalidOperationException();

                Console.WriteLine($"i = {i}, tid = {Task.CurrentId}");
                return result;
            });

            try
            {
                foreach (var c in results)
                {
                    if (c > 1)
                        cts.Cancel();

                    Console.WriteLine($"result = {c}");
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                    return true;
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("Canceled");
            }
        }
    }
}
