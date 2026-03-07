using System;
using System.Collections.Generic;
using System.Linq;

namespace Day47
{
    internal class Program
    {
        List<List<Container>> containerList;
        public Program(List<List<Container>> cargo)
        {
            containerList = cargo;
        }

        public List<string> FindHeavyContainers(double weightThreshold)
        {
            return containerList.SelectMany(r => r).Where(c => c.Items.Sum(i => i.Weight) > weightThreshold)
                .Select(c => c.ContainerId).ToList();
        }
        public Dictionary<string, int> GetItemCountsByCategory()
        {
            return containerList.SelectMany(r => r).SelectMany(c => c.Items).GroupBy(g => g.Category)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public List<Item> FlattenAndSortShipment()
        {
            return containerList.SelectMany(r => r).SelectMany(c => c.Items).Distinct()
                .OrderBy(i => i.Category).ThenByDescending(i => i.Weight).ToList();
        }
        static void Main(string[] args)
        {
            try
            {
                var cargoBay = new List<List<Container>>
                {
                    new List<Container>
                    {
                        new Container("C001", new List<Item>
                        {
                            new Item("Laptop", 2.5, "Tech"),
                            new Item("Monitor", 5.0, "Tech"),
                            new Item("Smartphone", 0.5, "Tech")
                        }),
                        new Container("C104", new List<Item>
                        {
                            new Item("Server Rack", 45.0, "Tech"),
                            new Item("Cables", 1.2, "Tech")
                        })
                    },

                    new List<Container>
                    {
                        new Container("C002", new List<Item>
                        {
                            new Item("Apple", 0.2, "Food"),
                            new Item("Banana", 0.2, "Food"),
                            new Item("Milk", 1.0, "Food")
                        }),
                        new Container("C003", new List<Item>
                        {
                            new Item("Table", 15.0, "Furniture"),
                            new Item("Chair", 7.5, "Furniture")
                        })
                    },

                    new List<Container>
                    {
                        new Container("C205", new List<Item>
                        {
                            new Item("Vase", 3.0, "Decor"),
                            new Item("Mirror", 12.0, "Decor")
                        }),
                        new Container("C206", new List<Item>())
                    },

                    new List<Container>()
                };

                Program result = new Program(cargoBay);
                var heavy = result.FindHeavyContainers(20);
                foreach (var id in heavy)
                {
                    Console.WriteLine(id);
                }
                Console.WriteLine();
                var counts = result.GetItemCountsByCategory();
                foreach (var v in counts)
                {
                    Console.WriteLine($"{v.Key} : {v.Value}");
                }
                Console.WriteLine();
                var items = result.FlattenAndSortShipment();
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Category} - {item.Weight}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}