using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<KeyValue> vHead = new Node<KeyValue>(new KeyValue() { Key = "1", Value = "One" });

            Func<KeyValue, KeyValue, int> vFunc = (T1,T2) => T1.Key.CompareTo(T2.Key);

            LinkedList<KeyValue> vList = new LinkedList<KeyValue>(vHead, vFunc);

            vList.Add(new KeyValue() { Key = "2", Value = "Two" });
            vList.Add(new KeyValue() { Key = "3", Value = "Three" });
            vList.Add(new KeyValue() { Key = "4", Value = "Four" });
            vList.Add(new KeyValue() { Key = "5", Value = "Five" });

            vList.Delete(new KeyValue() { Key = "3", Value = "Three" });

            vList.Reverse();
        }

        public class KeyValue
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
