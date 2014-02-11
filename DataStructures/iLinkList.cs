using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    interface iLinkList
    {
        LinkedListNode<string> Find(string node);
        
        #region Method
        void PositionChange(LinkedListNode<string> nodes);
        void AddFirst(string node);
        void AddLast(string node);
        void Show(LinkedList<string> nodes);
        #endregion
    
    }
}
