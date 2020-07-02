using System;
using BenchmarkDotNet.Attributes;

namespace GCPressureBenchmarks {

    public class StackAlloc {

        struct VectorStruct {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [Benchmark]
        public void WithNew () {
            var vectors = new VectorStruct[5];
            for (var i = 0; i < 5; i++) {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }

        [Benchmark]
        public unsafe void WithStackAlloc () {
            var vectors = stackalloc VectorStruct[5];
            for (var i = 0; i < 5; i++) {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }

        [Benchmark]
        public void WithSpan () {
            Span<VectorStruct> vectors = stackalloc VectorStruct[5];
            for (var i = 0; i < 5; i++) {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }
    }
}