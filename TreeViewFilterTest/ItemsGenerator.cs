using System;
using System.Collections.Generic;

namespace TreeViewFilterTest
{
    /// <summary>
    /// Just to create some example data without API/DB.
    /// </summary>
    public class ItemsGenerator
    {
        private static readonly Random _rnd = new Random();

        public static IEnumerable<ItemModel> GetMainItems()
        {
            var children = CreateChildren(null, 0, 3);
            var data = new List<ItemModel>();
            foreach (var child in children)
            {
                data.Add(child);
            }
            return data;
        }

        private static IEnumerable<ItemModel> CreateChildren(ItemModel parent, int currentLevel, int maxLevel)
        {
            for (var i = 0; i < _rnd.Next(3, 8); i++)
            {
                var child = CreateRandomModel(parent);
                if (currentLevel < maxLevel)
                {
                    var subChildren = CreateChildren(child, currentLevel + 1, maxLevel);
                    foreach (var subChild in subChildren)
                    {
                        child.Children.Add(subChild);
                    }
                }
                yield return child;
            }
        }

        private static ItemModel CreateRandomModel(ItemModel parent)
        {
            bool a = false, b = false, c = false;
            if (_rnd.NextDouble() > 0.5)
                a = true;
            if (_rnd.NextDouble() > 0.5)
                b = true;
            if (_rnd.NextDouble() > 0.5)
                c = true;
            return new ItemModel(a, b, c, parent);
        }
    }
}