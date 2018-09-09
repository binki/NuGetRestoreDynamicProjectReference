using Interfaces;
using System.ComponentModel.Composition;

namespace Injectable
{
    [Export(typeof(IThing))]
    public class InjectedThing : IThing
    {
        (string X, string Y) Value { get; }
    }
}
