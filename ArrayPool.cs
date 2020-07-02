using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace GCPressureBenchmarks {

    public class ArrayPool {

        [Benchmark]
        public void RegularArray () {
            var array = new int[1000];
        }

        [Benchmark]
        public void SharedArray () {
            var pool = ArrayPool<int>.Shared;
            var array = pool.Rent (1000);
            // işimiz bitince diziyi iade ediyoruz
            pool.Return (array);
        }
    }
}