using System;

namespace Bit0.PipeLines
{
    public interface IActionPipeLine<TContext>
    {
        IActionPipeLine<TContext> AddAction(Action<TContext> process);
        IActionPipeLine<TContext> AddAction(Int32 index, Action<TContext> process);

        void Execute();
    }
}
