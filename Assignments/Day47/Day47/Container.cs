using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day47
{
    internal class Container
    {
        public string ContainerId { get; set; }

        public List<Item> Items { get; set; }

        public Container(string id, List<Item> items)
        {
            ContainerId = id;
            Items = items;
        }
    }
}
