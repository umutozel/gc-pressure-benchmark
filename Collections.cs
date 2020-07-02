using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace GCPressureBenchmarks {

    public class Collections {
        
        [Benchmark]
        public void Dynamic () {
            var list = new List<int> ();
            for (var i = 0; i < 1000; i++) {
                list.Add (i);
            }
        }

        [Benchmark]
        public void Planned () {
            var list = new List<int> (1000);
            for (var i = 0; i < 1000; i++) {
                list.Add (i);
            }
        }
    }
}
