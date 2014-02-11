using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkList:iLinkList
    {
        #region Variable
        /// <summary>
        /// LinkedList Class for string List
        /// </summary>
        public LinkedList<string> _List;
        #endregion

        #region Constractor
        /// <summary>
        /// Default
        /// </summary>
        /// <param name="strings"></param>
        public LinkList(string[] strings)
        {
            _List = new LinkedList<string>(strings);
        }
        #endregion

        #region Method

        /// <summary>
        /// Find in Linked List Str
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public LinkedListNode<string> Find(string node)
        {
            return _List.Find(node);
        }

        /// <summary>
        /// Position Change
        /// </summary>
        /// <param name="node"></param>
        public void PositionChange(LinkedListNode<string> nodes)
        {
            _List.AddLast(nodes);//Sample Last Position Add
        }

        /// <summary>
        /// Adding Linked List First Node
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(string node)
        {
            _List.AddFirst(node);
        }

        /// <summary>
        /// Addding Linked List Last Node
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(string node)
        {
            LinkedListNode<string> _node = Find(node);

            PositionChange(_node);
        }

        /// <summary>
        /// Show Linked List Node
        /// </summary>
        /// <param name="nodes"></param>
        public void Show(LinkedList<string> nodes)
        {
            foreach (string node in nodes)
            {
                Console.WriteLine(node + Environment.NewLine);
            }
        }

        #endregion
     
    }


}