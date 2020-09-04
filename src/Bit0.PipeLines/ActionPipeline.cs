using System;
using System.Collections.Generic;

namespace Bit0.PipeLines
{
    public class ActionPipeLine<TContext> : IActionPipeLine<TContext>
    {
        private readonly TContext _context;
        private readonly SortedList<Int32, Action<TContext>> _actions = new SortedList<Int32, Action<TContext>>();

        public ActionPipeLine(TContext context)
        {
            _context = context;
        }

        public IActionPipeLine<TContext> AddProcess(Action<TContext> process)
        {
            return AddProcess(_actions.Count * 100, process);
        }

        public IActionPipeLine<TContext> AddProcess(Int32 index, Action<TContext> process)
        {
            if (_actions.ContainsKey(index))
            {
                return AddProcess(index + 1, process);
            }
            _actions.Add(index, process);

            return this;
        }

        public void Execute()
        {
            foreach (var action in _actions.Values)
            {
                action(_context);
            }
        }
    }
}
