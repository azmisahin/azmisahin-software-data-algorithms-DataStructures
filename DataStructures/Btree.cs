using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class BTree
    {
        public class BTreeNode
        {
            public int keyNumber;
            public int[] keys;
            public bool leaf;
            public BTreeNode[] subNodes;

        }
    }
}
