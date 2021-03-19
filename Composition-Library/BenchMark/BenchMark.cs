using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;
using BenchmarkDotNet.Attributes;

namespace BenchMark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchMark
    {
        private static ComponentFactory componentFactory = new ComponentFactory(Assembly.GetExecutingAssembly());

        [Benchmark]
        public void RunEntityCreationWithRelation()
        {
            Code.createEntities(componentFactory);
        }
    }
}
