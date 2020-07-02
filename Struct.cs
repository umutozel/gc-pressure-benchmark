using BenchmarkDotNet.Attributes;

namespace GCPressureBenchmarks {

    public class Struct {
        
        class VectorClass {
            public int X { get; set; }
            public int Y { get; set; }
        }

        struct VectorStruct {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [Benchmark]
        public void WithClass () {
            var vectors = new VectorClass[1000];
            for (int i = 0; i < 1000; i++) {
                // her seferinde Heap üzerinden bellek alınıyor
                vectors[i] = new VectorClass ();
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }

        [Benchmark]
        public void WithStruct () {
            // bu aşamada tüm bellek hazır, tekrar yer istenmiyor
            var vectors = new VectorStruct[1000];
            for (int i = 0; i < 1000; i++) {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }
    }
}