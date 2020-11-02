namespace TreeViewFilterTest.Criterias
{
    public class CriteriaCheckA : ICriteria
    {
        public string Name => "Check A";

        public HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null)
        {
            foreach (HierarchicalItem child in hierarchicalEnumerable)
            {
                var itemViewModel = (ItemViewModel)child.Item;
                if (itemViewModel.Item.A)
                    itemViewModel.Checked = true;
                child.Children = MeetCriteria(child.Children, child);
            }
            return hierarchicalEnumerable;
        }
    }
}