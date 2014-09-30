using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace LinkedLists
{
    public class LinkedList<T>
    {
        private Node<T> oHead = null;

        public LinkedList(Node<T> pHead)
        {
            oHead = pHead;
        }


    }
}
