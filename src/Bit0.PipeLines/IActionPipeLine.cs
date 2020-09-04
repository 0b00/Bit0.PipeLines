using System;

namespace Bit0.PipeLines
{
    public interface IActionPipeLine<TContext>
    {
        IActionPipeLine<TContext> AddProcess(Action<TContext> process);
        IActionPipeLine<TContext> AddProcess(Int32 index, Action<TContext> process);

        void Execute();
    }
}
