using BenchmarkDotNet.Attributes;

namespace GCPressureBenchmarks {

    public class Finalizer {

        class Simple {
            public int X { get; set; }
        }

        class SimpleWithFinalizer {

            ~SimpleWithFinalizer () { }

            public int X { get; set; }
        }

        private static Simple _instance1;
        private static SimpleWithFinalizer _instance2;

        [Benchmark]
        public void AllocateSimple () {
            for (int i = 0; i < 100000; i++) {
                _instance1 = new Simple ();
            }
        }

        [Benchmark]
        public void AllocateSimpleWithFinalizer () {
            for (int i = 0; i < 100000; i++) {
                _instance2 = new SimpleWithFinalizer ();
            }
        }
    }
}