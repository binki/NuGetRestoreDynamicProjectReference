using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Runner
{
    [Export]
    public class Program
    {
        [ImportMany]
        protected IEnumerable<IThing> Things { get; set; }

        static int Main(string[] args)
        {
            using (var catalogue = new ApplicationCatalog())
            using (var container = new CompositionContainer(catalogue))
            {
                return container.GetExportedValue<Program>().Run(args);
            }
        }

        int Run(string[] args)
        {
            foreach (var thing in Things)
            {
                Console.WriteLine($"Thing: {thing}");
            }
            var count = Things.Count();
            var expectedCount = 2;
            if (count != expectedCount)
            {
                Console.Error.WriteLine($"Got {count} things when expecting {expectedCount}");
                return 1;
            }
            Console.WriteLine($"Success!");
            return 0;
        }
    }
}
