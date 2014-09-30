using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace BinarySearchTree
{
    public class BST<T>
    {
        //root node for the tree
        private Node<T> oRoot = null;
        //comparer function for the type used in the tree // to be provided in the constructor
        private Func<T, T, int> oComparer = null;

        private int oCount = 0;

        public BST(Func<T, T, int> pComparer)
        {
            oComparer = pComparer;
        }

        public BST(Node<T> pRoot, Func<T, T, int> pComparer)
        {
            oRoot = pRoot;
            oCount++;
            oComparer = pComparer;
        }

        public BST(Node<T> pRoot)
        {
            oCount++;
            oRoot = pRoot;
        }

        public virtual void Clear()
        {
            oRoot = null;
            oCount = 0;
        }

        public Node<T> Root {

            get {
                return oRoot;
            }
            set{
                oRoot = value; 
            }
        }

        /// <summary>
        /// Add a node to the tree
        /// </summary>
        /// <param name="pNode"></param>
        public virtual void Add(Node<T> pNode)
        {
            Node<T> vCurrent = oRoot, vParent = null;
            while (vCurrent != null)
            {
                int vResult = oComparer(oRoot.Value, pNode.Value);
                if (vResult == 0)
                {
                    //if value is alreday present, return 
                    return;
                }
                //if parent node's value is bigger
                if (vResult > 0)
                {
                    //node should be added to the left
                    vParent = vCurrent;
                    vCurrent = vCurrent.Left;
                }
                //if parent node's value is smaller
                if (vResult < 0)
                {
                    //node should be added to the right
                    vParent = vCurrent;
                    vCurrent = vCurrent.Right;
                }
            }
            //if no parent found , make the current node as root
            if (vParent == null)
            {
                oRoot = pNode;
            }
            else
            {
                int vResult = oComparer(vParent.Value, pNode.Value);
                if (vResult > 0)
                {
                    //node should be added to the left
                   vParent.Left = pNode;
                }
                //if parent node's value is smaller
                else
                {
                    //node should be added to the right
                    vParent.Right = pNode;
                }
            }
            oCount++;

        }

        /// <summary>
        /// Finds the Node in the tree which contains the given value.
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public virtual Node<T> Find(T pValue)
        {
            Node<T> vCurrent = oRoot;
            while(vCurrent != null)
            {
                int vResult = oComparer(vCurrent.Value, pValue);
                if(vResult == 0)
                {
                    return vCurrent;
                }
                if(vResult > 0)
                {
                    vCurrent = vCurrent.Left;
                }
                else
                {
                    vCurrent = vCurrent.Right;
                }
                
            }
            return null;

        }

        /// <summary>
        /// Serach whether tree contains the given value
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public bool Contains(T pValue)
        {
            return (Find(pValue) != null);
        }

        //remove a given value from the tree

        public bool Remove(T pValue)
        {
            bool vRemoved = true;
            if (oRoot == null)
            {
                vRemoved = false;
            }
            else
            {
                Node<T> vCurrent = oRoot, vParent = null;
                int vResult = oComparer(vCurrent.Value, pValue);
                while (vResult != 0)
                {
                    //parent'value is larger, so look on the left tree
                    if (vResult > 0)
                    {
                        vParent = vCurrent;
                        vCurrent = vCurrent.Left;
                    }
                    else
                    {
                        vParent = vCurrent;
                        vCurrent = vCurrent.Right;
                    }

                    if (vCurrent == null)
                    {
                        vRemoved = false;
                    }
                    else
                    {
                        vResult = oComparer(vCurrent.Value, pValue);
                    }
                }

                if (vCurrent != null)
                {
                    //we found the node to be removed 
                    vRemoved = true;
                    //case 1  - there is a right child of the node
                    if (vCurrent.Right == null)
                    {
                        if (vParent == null)
                        {
                            Root = vCurrent.Left;
                        }
                        else
                        {
                            vResult = oComparer(vParent.Value, vCurrent.Value);
                            if (vResult > 0)
                            {
                                vParent.Left = vCurrent.Left;
                            }
                            else
                            {
                                vParent.Right = vCurrent.Left;
                            }
                        }
                    }
                    else if (vCurrent.Right.Left == null)
                    {
                        vCurrent.Right.Left = vCurrent.Left;
                        if (vParent == null)
                        {
                            oRoot = vCurrent.Right;
                        }
                        else
                        {
                            vResult = oComparer(vParent.Value, vCurrent.Value);
                            if (vResult > 0)
                            {
                                vParent.Left = vCurrent.Left;
                            }
                            else
                            {
                                vParent.Right = vCurrent.Left;
                            }

                        }

                    }
                    else
                    {
                        Node<T> vLeftMostNode = vCurrent.Right.Left, vLMParent = null;
                        while (vLeftMostNode.Left != null)
                        {
                            vLeftMostNode = vLeftMostNode.Left;
                            vLMParent = vLeftMostNode;
                        }

                        vLMParent.Left = vLeftMostNode.Right;
                        if (vParent == null)
                        {
                            oRoot = vLeftMostNode;
                        }
                        else
                        {
                            vResult = oComparer(vParent.Value, vCurrent.Value);
                            if (vResult > 0)
                            {
                                vParent.Left = vLeftMostNode;
                            }
                            else
                            {
                                vParent.Right = vLeftMostNode;
                            }

                        }



                    }
                }
                if (vRemoved)
                {
                    oCount--;
                }

            }
            return vRemoved;
        }
    }
}
