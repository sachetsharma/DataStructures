using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Node<T>
    {
        public Node()
        {
        }
        public Node(T pValue)
        {
            this.Value = pValue;
        }
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }
}
