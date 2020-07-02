using BenchmarkDotNet.Running;

namespace GCPressureBenchmarks {

    public class Program {
        
        public static void Main (string[] args) {
            // BenchmarkRunner.Run<Collections> ();
            // BenchmarkRunner.Run<ArrayPool> ();
            // BenchmarkRunner.Run<Struct> ();
            // BenchmarkRunner.Run<Finalizer> ();
            BenchmarkRunner.Run<StackAlloc> ();
            // BenchmarkRunner.Run<Intern> ();
        }
    }
}