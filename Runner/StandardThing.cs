using Interfaces;
using System.ComponentModel.Composition;

namespace Runner
{
    [Export(typeof(IThing))]
    class StandardThing : IThing
    {
    }
}
