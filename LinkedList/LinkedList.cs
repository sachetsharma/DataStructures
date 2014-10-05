using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace LinkedLists
{
    public class LinkedList<T>
    {
        private Node<T> oHead = null;
        private Func<T,T,int> oFunc = null;
        private Node<T> oCurrent = null;
        private int oCount = 0;
        public int Size
        {
            get
            {
                return oCount;
            }
        }

        public LinkedList(Func<T, T, int> pFunc)
        {
            oFunc = pFunc;
        }
        public LinkedList(Node<T> pHead, Func<T, T, int> pFunc)
        {
            oFunc = pFunc;
            oHead = pHead;
            oCurrent = pHead;
            oCount++;
        }

        public bool Add(T pValue)
        {
            Node<T> vNode = new Node<T>(pValue);
            if (oHead == null)
            {
                oHead = vNode;
                oCurrent = vNode;
            }
            else
            {
                oCurrent.Right = vNode;
                oCurrent = vNode;
            }
            oCount++;
            return true;
        }

        public void Push(T pValue)
        {
            Node<T> vNode = new Node<T>(pValue);
            if (oHead == null)
            {
                oHead = vNode;
                oCount++;
            }
            else
            {
                vNode.Right = oHead;
                oHead = vNode;
                oCount++;
            }
            
        }

        public T Pop()
        {
            if (oHead == null)
            {
                return null;
            }
            else
            {
                
            }

        }

        public bool Delete(T pValue)
        {
            if (oHead == null)
            {
                return false;
            }

            Node<T> vPrevious = null;
            Node<T> vCurrent = oHead;
            if(oFunc(vCurrent.Value, pValue) == 0)
            {
                oHead = null;
                oCount--;
                return true;
            }
            vPrevious = oHead;
            vCurrent = oHead.Right;
            while (vCurrent != null)
            {
                if (oFunc(vCurrent.Value, pValue) == 0)
                {
                    vPrevious.Right = vCurrent.Right;
                    vCurrent = null;
                    oCount--;
                    return true;
                }
                vPrevious = vCurrent;
                vCurrent = vCurrent.Right;
            }
            return false;
        }

        public void Reverse()
        {
            Node<T> vPrev = null, vCurrent = oHead, vNext = null;

            while (vCurrent != null)
            {
                vNext = vCurrent.Right;
                vCurrent.Right = vPrev;
                vPrev = vCurrent;
                vCurrent = vNext;
            }
            oHead = vPrev;
        }


    }
}
