using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public sealed class FibonacciHeap<TKey, TValue>
    {
        private readonly List<Node> Root = new List<Node>();
        
        private int _count;
        private Node Min;

        public void Push(TKey key, TValue value)
        {
            Insert(new Node(key, value));
        }

        public KeyValuePair<TKey, TValue> Peek()
        {
            if (Min == null)
                throw new InvalidOperationException();
            return new KeyValuePair<TKey, TValue>(Min.Key, Min.Value);
        }

        public KeyValuePair<TKey, TValue> Pop()
        {
            if (Min == null)
                throw new InvalidOperationException();
            var min = ExtractMin();
            return new KeyValuePair<TKey, TValue>(min.Key, min.Value);
        }

        private void Insert(Node node)
        {
            _count++;
            Root.Add(node);
            if (Min == null)
            {
                Min = node;
            }
            else if (Comparer<TKey>.Default.Compare(node.Key, Min.Key) < 0)
            {
                Min = node;
            }
        }

        private Node ExtractMin()
        {
            var result = Min;
            if (result == null)
                return null;
            foreach (var child in result.Children)
            {
                child.Parent = null;
               
                Root.Add(child);
            }
            Root.Remove(result);
            if (Root.Count == 0)
            {
                Min = null;
            }
            else
            {
                Min = Root[0];
                Consolidate();
            }
            _count--;
            return result;
        }

       
        private void Consolidate()
        {
            var unlabeledBag = new Node[UpperBound()];
            for (int i = 0; i < Root.Count; i++)
            {
                Node item = Root[i];
                int itemChildren = item.Children.Count;
                while (true)
                {
                    Node child = unlabeledBag[itemChildren];
                    if (child == null)
                        break;
                    if (Comparer<TKey>.Default.Compare(item.Key, child.Key) > 0)
                    {
                        var swap = item;
                        item = child;
                        child = swap;
                    }
                    Root.Remove(child);
                    i--;
                    item.AddChild(child);
                    child.Mark = false;
                    unlabeledBag[itemChildren] = null;
                    itemChildren++;
                }
                unlabeledBag[itemChildren] = item;
            }
            Min = null;
            for (int i = 0; i < unlabeledBag.Length; i++)
            {
                var item = unlabeledBag[i];
                if (item == null)
                    continue;
                if (Min == null)
                {
                    Root.Clear();
                    Min = item;
                }
                else if (Comparer<TKey>.Default.Compare(item.Key, Min.Key) < 0)
                {
                    Min = item;
                }
                Root.Add(item);
            }
        }

        private int UpperBound()
        {
            
            double magicValue = Math.Log(_count, (1.0 + Math.Sqrt(5)) / 2.0);
            return (int)Math.Floor(magicValue) + 1;
        }

       
        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Parent;
            public List<Node> Children = new List<Node>();
            public bool Mark;

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public void AddChild(Node child)
            {
                child.Parent = this;
                Children.Add(child);
            }
        }
    }
}
