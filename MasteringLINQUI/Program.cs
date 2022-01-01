using MasteringLINQUI.Custom_Aggregations;
using MasteringLINQUI.Merge_Options;
using MasteringLINQUI.ParallelLINQ;
using System;

namespace MasteringLINQUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Getting Started
            //GettingStarted.GettingStartedProgram.Run();
            #endregion

            #region ParallelLINQ
            //AsParallelParallelQueryProgram.RunAsParallel();
            //AsParallelParallelQueryProgram.RunCancellationOrExceptions();
            #endregion

            #region Merge Options
            //MergeOptionsProgram.Run();
            #endregion

            #region Custom Aggregations
            CustomAggregationsProgram.Run();
            #endregion
        }
    }
}
