using EnumUtilities;
using Interfaces;
using System.ComponentModel.Composition;
using System.IO;

namespace Runner
{
    [Export(typeof(IThing))]
    class StandardThing : IThing
    {
        public StandardThing()
        {
            EnumUtil.GetValues<FileMode>();
        }
    }
}
