using System.Web.UI;

namespace TreeViewFilterTest
{
    /// <summary>
    /// IHierarchyData implementation so TreeView DataSource can be used
    /// </summary>
    public class HierarchicalItem : IHierarchyData
    {
        private readonly ItemViewModel _item;
        private readonly HierarchicalItem _parent;

        public HierarchicalItem(ItemViewModel item, HierarchicalItem parent)
        {
            _parent = parent;
            _item = item;
            Children = new HierarchicalEnumerable();
            foreach (var child in item.Children)
            {
                Children.Add(new HierarchicalItem(child, this));
            }
        }

        public HierarchicalEnumerable Children { get; set; }
        public bool HasChildren => Children.Count > 0;
        public object Item => _item;
        public string Name => _item.Name;
        public string Path => string.Empty;
        public string Type => typeof(HierarchicalItem).ToString();
        public bool Visible { get; set; }

        public IHierarchicalEnumerable GetChildren()
        {
            return Children;
        }

        public IHierarchyData GetParent() => _parent;
    }
}