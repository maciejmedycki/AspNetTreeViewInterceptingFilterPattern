namespace TreeViewFilterTest.Criterias
{
    public class CriteriaCheckB : ICriteria
    {
        public string Name => "Check B";

        public HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null)
        {
            foreach (HierarchicalItem child in hierarchicalEnumerable)
            {
                var itemViewModel = (ItemViewModel)child.Item;
                if (itemViewModel.Item.B)
                    itemViewModel.Checked = true;
                child.Children = MeetCriteria(child.Children, child);
            }
            return hierarchicalEnumerable;
        }
    }
}