using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public abstract class GildedRoseFactory
    {
        protected abstract Item Item { get; }

        public abstract Item UpdateQuality();
    }
}
