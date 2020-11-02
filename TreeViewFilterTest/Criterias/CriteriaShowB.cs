namespace TreeViewFilterTest.Criterias
{
    public class CriteriaShowB : ICriteria
    {
        public string Name => "Must be B";

        public HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null)
        {
            var returnValue = new HierarchicalEnumerable();
            foreach (HierarchicalItem child in hierarchicalEnumerable)
            {
                var item = (ItemViewModel)child.Item;
                if (child.GetParent() == null || (item != null && item.Item.B))
                {
                    var copy = new HierarchicalItem(item, parent);
                    copy.Children = MeetCriteria(child.Children, copy);
                    returnValue.Add(copy);
                }
            }
            return returnValue;
        }
    }
}