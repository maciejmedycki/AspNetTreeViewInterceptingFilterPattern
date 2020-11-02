using System.Collections.Generic;

namespace TreeViewFilterTest
{
    /// <summary>
    /// Wrapper for <see cref="ItemModel"/> to add some extra props.
    /// </summary>
    public class ItemViewModel
    {
        public ItemViewModel(ItemModel itemModel)
        {
            Name = itemModel.Name;
            var children = new List<ItemViewModel>();
            foreach (var child in itemModel.Children)
            {
                children.Add(new ItemViewModel(child));
            }
            Children = children;
            Item = itemModel;
        }

        public bool Checked { get; set; }
        public IEnumerable<ItemViewModel> Children { get; set; }
        public ItemModel Item { get; }
        public string Name { get; set; }
    }
}