using System;
using System.Diagnostics.CodeAnalysis;

namespace PipeLineTests
{
    [ExcludeFromCodeCoverage]
    internal class AContext
    {
        public Int32 Base => 20;

        public Int32 Modifier { get; }

        public AContext(Int32 modifier)
        {
            Modifier = modifier;
        }
    }
}
