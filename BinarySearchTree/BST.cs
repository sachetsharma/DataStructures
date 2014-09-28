using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BST<T>
    {
        Node<T> oRoot = null;
        Func<T, T, int> oComparer = null;
        public BST(Node<T> pRoot, Func<T, T, int> pComparer)
        {
            oRoot = pRoot;
            oComparer = pComparer;
        }

        public Node<T> Add(Node<T> pNode)
        {
            if (oRoot == null)
            {
                oRoot = pNode;
            }
            Node<T> vParent = FindParent(pNode, oRoot);
            if (oComparer(pNode.Value, vParent.Value) == 1)
            {
                vParent.Right = pNode;
            }
            else
            {
                vParent.Left = pNode;
            }
            return pNode;

        }

        private Node<T> FindParent(Node<T> pNode, Node<T> pStartNode)
        {
            Node<T> vParent = null;
            if (pStartNode.HasDescendents)
            {
                while (pStartNode.HasDescendents)
                {

                }
            }


        }
    }
}
