using BenchmarkDotNet.Attributes;

namespace GCPressureBenchmarks {

    public class Intern {
        private readonly string s1 = "Hello";
        private readonly string s2 = " World";

        [Benchmark]
        public void WithoutInterning () {
            var s1 = GetNonLiteral ();
            var s2 = GetNonLiteral ();
            for (var i = 0; i < 1000; i++) {
                var x = s1.Equals (s2);
            }
        }

        [Benchmark]
        public void WithInterning () {
            var s1 = string.Intern (GetNonLiteral ());
            var s2 = string.Intern (GetNonLiteral ());
            for (var i = 0; i < 1000; i++) {
                var x = s1.Equals (s2);
            }
        }

        private string GetNonLiteral () => s1 + s2;
    }
}
