namespace TreeViewFilterTest.Criterias
{
    public class CriteriaCheckC : ICriteria
    {
        public string Name => "Check C";

        public HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null)
        {
            foreach (HierarchicalItem child in hierarchicalEnumerable)
            {
                var itemViewModel = (ItemViewModel)child.Item;
                if (itemViewModel.Item.C)
                    itemViewModel.Checked = true;
                child.Children = MeetCriteria(child.Children, child);
            }
            return hierarchicalEnumerable;
        }
    }
}