using Bit0.PipeLines;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace PipeLineTests
{

    [ExcludeFromCodeCoverage]
    public class ActionPipeLineTests
    {

        [Fact]
        public void ExecutePipeLine()
        {
            var result = new List<Int32>();

            var dict = new Dictionary<String, Action<AContext>>
            {
                { "add", ctx => { result.Add( ctx.Base + ctx.Modifier ); } },
                { "subtract", ctx => { result.Add( ctx.Base - ctx.Modifier ); } },
                { "multiply", ctx => { result.Add( ctx.Base * ctx.Modifier ); } },
                { "divide", ctx => { result.Add( ctx.Base / ctx.Modifier ); } },
            };

            new ActionPipeLine<AContext>(new AContext(10))
                .AddAction(1000, dict["multiply"])
                .AddAction(dict["add"])
                .AddAction(0, dict["divide"])
                .AddAction(0, dict["subtract"])
                .Execute();

            result.Count.Should().Be(4);

            result.First().Should().Be(2);
            result[2].Should().Be(30);
            result.Last().Should().Be(200);
        }
    }
}
