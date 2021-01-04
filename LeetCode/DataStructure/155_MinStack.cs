using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure
{
    class _155_MinStack
    {
        private class Storage
        {
            public int Value { get; set; }
            public int Min { get; set; }
        }
        
        private Stack<Storage> _stack = new Stack<Storage>();

        //public MinStack()
        //{

        //}

        public void Push(int x)
        {
            if (_stack.Count == 0)
            {
                _stack.Push(new Storage { Value = x, Min = x });
            }
            else
            {
                int prevMin = GetMin();
                _stack.Push(new Storage { Value = x, Min = Math.Min(x, prevMin) });
            }
        }

        public void Pop()
        {
            if (_stack.Count == 0) return;
            _stack.Pop();
        }

        public int Top()
        {
            return _stack.Peek().Value;
        }

        public int GetMin()
        {
            return _stack.Peek().Min;
        }
    }
}
