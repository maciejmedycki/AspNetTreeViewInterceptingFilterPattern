using System;
using System.Collections.Generic;

namespace TreeViewFilterTest
{
    //TODO: use record instead of class in C# 9
    /// <summary>
    /// Immutable DTO
    /// </summary>
    [Serializable]
    public class ItemModel
    {
        public ItemModel(bool a, bool b, bool c, ItemModel parent)
        {
            Children = new List<ItemModel>();
            Parent = parent;
            A = a;
            B = b;
            C = c;
        }

        public bool A { get; private set; }
        public bool B { get; private set; }
        public bool C { get; private set; }
        public IList<ItemModel> Children { get; private set; }

        public string Name
        {
            get
            {
                var name = "Item ";
                if (A)
                    name += "A";
                if (B)
                    name += "B";
                if (C)
                    name += "C";
                return name;
            }
        }

        public ItemModel Parent { get; private set; }
    }
}